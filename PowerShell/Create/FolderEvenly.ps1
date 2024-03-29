$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo フォルダ内のファイルを閾値の容量で分割する
# PowerShell で フォルダの容量一覧を取得したい - tech.guitarrapc.c?m
#   http://tech.guitarrapc.com/entry/2013/09/26/071905
# PowerShellでPSCustomObjectに複数のObjectを追加する - tech.guitarrapc.c?m
#   http://tech.guitarrapc.com/entry/2013/06/25/230640


<# 事前準備 #>
  # 閾値(MB)
  # 1B=0.000001MB、1KB=0.001MB、1000MB=1GB
  $thresholdMB = 0.1
  $threshold = $thresholdMB * 1000KB

  # 処理先フォルダ名
  $destFolderName = "TestDest_"
  # 先フォルダ番号
  $Script:destFolderNum = 1
  # 先フォルダ管理配列
  $Script:destDirMgr = @()
  $Script:destDirMgr += [PSCustomObject]@{
    DirName = $destFolderName + $Script:destFolderNum # フォルダ名
    DirSize = 0                                       # 現在フォルダサイズ
    CanAdd = $True                                    # 追加可能フラグ
  }


<# 直下ファイル情報取得関数 #>
 # 引数01:対象フォルダパス
 # 戻り値:ファイル情報
function GetDirectlyFileInfo($targetPath)
{
  Write-Host $targetPath
  # 対象フォルダ内のファイルをサイズ順に並び替え
  # # -Force:通常+隠しファイル
  # # ファイルのみ
  # # Length:サイズ
  # # サイズでソート
  $fileInfo = Get-ChildItem $targetPath -Force `
    | ? { -not $_.PSIsContainer } `
    | Select-Object fullname, Length `
    # | Sort-Object -Descending fullname # ソート(デフォルトは昇順)

  return $fileInfo
}


<# 直下フォルダ情報取得関数 #>
 # 引数01:対象フォルダパス
 # 戻り値:フォルダ情報
 function GetDirectlyFolderInfo($targetPath)
{
  # 対象フォルダ内のフォルダサイズを全て取得
  # # 対象フォルダ内を回帰的に処理
  # # フォルダのみフィルタ
  # # オブジェクトとして値をFullnameとMBカラムに設定
  # # KB列でソート
  $folderInfo = Get-ChildItem $targetPath -Force `
    | where PSIsContainer `
    | %{
         # 対象を変数に格納
         $x=$_
         # フォルダサイズ計算
         $subFolderItems = (Get-ChildItem $x.FullName -Force -Recurse | where Length | measure Length -sum)

         # PSオブジェクトに変換
         [PSCustomObject]@{
           Fullname = $x.FullName
           KB = $subFolderItems.sum
         }
       } `
  #  | sort Fullname -Descending ` # ソート(デフォルトで昇順)
  #  | format-Table -AutoSize # 表示を見やすくする(これを入れると配列としてアクセスできなくなる)
  #          MB = [decimal]("{0:N2}" -f ($subFolderItems.sum / 1MB)) # KBをMBに変換

  return $folderInfo
}


<# 新規フォルダ作成関数 #>
 # 引数01:対象サイズ
 # 引数02:追加可能フラグ
 # 戻り値:新規先フォルダ名
 # 注意:呼び出し元関数に渡された参照渡し引数使用
function CreateNewFolder($targetSize, $isCanAdd)
{
  # 先フォルダ番号インクリメント
  $Script:destFolderNum += 1

  # 先フォルダ名作成
  $destRoot = $destFolderName + $Script:destFolderNum

  # 先フォルダ管理配列に新しいフォルダを追加
  $Script:destDirMgr += [PSCustomObject]@{
    DirName = $destRoot
    DirSize = $targetSize
    CanAdd = $isCanAdd
  }

  # 物理先フォルダ作成
  New-Item -Path $destRoot\ -ItemType Directory -Force

  return $destRoot
}


<# 階層コピー関数 #>
 # 引数01:処理対象パス
 # 引数02:処理先フォルダ
 # 引数03:ディレクトリ構造
function CopyHierarchie($sourceFile, $destRootFolder, $destHierarchie)
{
  # 処理先ファイルパス作成
  $destFilePath = $destRootFolder + $destHierarchie
  # 親フォルダパス作成
  $destParentPath = Split-Path $destFilePath -Parent

  # フォルダ構成作成
  New-Item -Path $destParentPath -ItemType Directory -Force
  # 対象ファイルコピー
  Copy-Item -Path $source -Destination $destParentPath -Force
}


<# ファイル処理関数 #>
 # 引数01:対象フォルダパス
function ProcessFile($targetFolderPath)
{
  # 直下ファイル情報取得関数使用
  $directlyFiles = GetDirectlyFileInfo $targetFolderPath

  # ファイル処理
  foreach($x in $directlyFiles)
  {
    # 処理対象パス
    $source = $x.FullName
    # 対象ファイルパスからディレクトリ構造を取得
    $destHierarchie = $source -replace $targetRootPathRep, ""

    # 対象ファイルサイズが閾値を越す場合
    if ($x.Length -gt $threshold)
    {
      # 新規フォルダ作成関数使用
      $destRootFolder = CreateNewFolder $x.Length $False

      # 階層込みファイルコピー関数使用
      CopyHierarchie $source $destRootFolder[1] $destHierarchie

      continue
    }

    # 先フォルダ管理配列ループ
    $isComp = $False
    foreach($y in $Script:destDirMgr)
    {
      # ねずみ返し_完了フラグが真
      if ($isComp)
      {
        break
      }
      # ねずみ返し_追加可能フラグが不可
      if (-not $y.CanAdd)
      {
        continue
      }
      # ねずみ返し_処理後計算フォルダサイズが閾値を超える場合
      if ($y.DirSize + $x.Length -gt $threshold)
      {
        continue
      }

      # # 容量が空いている先フォルダに処理
      # 階層込みファイルコピー関数使用
      CopyHierarchie $source $y.DirName $destHierarchie

      # 移動後サイズ計上
      $y.DirSize += $x.Length
      # 完了フラグを立てる
      $isComp = $True
    }

    # ねずみ返し_完了フラグが真
    if ($isComp)
    {
      continue
    }

    # # 空いているフォルダがない場合、新しいフォルダに処理する
    # 新規フォルダ作成関数使用
    $destRootFolder = CreateNewFolder $x.Length $True

    # 階層込みファイルコピー関数使用
    CopyHierarchie $source $destRootFolder[1] $destHierarchie
  }
}


<# フォルダ処理関数 #>
 # 引数01:対象フォルダパス
function ProcessFolder($targetFolderPath)
{
  # 直下フォルダ情報取得関数使用
  $directlyFolders = GetDirectlyFolderInfo($targetFolderPath)

  # フォルダ処理
  foreach($x in $directlyFolders)
  {
    # 処理対象パス
    $source = $x.FullName
    # 対象ファイルサイズ
    $targetFileSize = $x.KB
    # 対象ファイルパスからディレクトリ構造を取得
    $destHierarchie = $source -replace $targetRootPathRep, ""

    # 対象フォルダサイズが0の場合
    if ([String]::IsNullOrEmpty($targetFileSize))
    {
      # 空フォルダ作成
      # 処理先は先フォルダ1に固定
      $destRoot = $Script:destDirMgr[0].DirName
      # 処理先ファイルパス作成
      $destBlunkFolderPath = $destRoot + $destHierarchie

      # フォルダ作成
      New-Item -Path $destBlunkFolderPath -ItemType Directory -Force

      continue
    }

    # 対象フォルダサイズが閾値を越す場合
    if ($targetFileSize -gt $threshold)
    {
      # 自身を回帰的に呼び出す
      ProcessFolder $source

      # ファイル処理関数使用
      ProcessFile $source

      continue
    }

    # 先フォルダ管理配列ループ
    $isComp = $False
    foreach($y in $Script:destDirMgr)
    {
      # ねずみ返し_完了フラグが真
      if ($isComp)
      {
        break
      }
      # ねずみ返し_追加可能フラグが不可
      if (-not $y.CanAdd)
      {
        continue
      }
      # ねずみ返し_処理後計算フォルダサイズが閾値を超える場合
      if ($y.DirSize + $targetFileSize -gt $threshold)
      {
        continue
      }

      # # 容量が空いている先フォルダに処理
      # 処理対象パス
      $destRoot = $y.DirName

      # 処理先ファイルパス作成
      $destFilePath = $destRoot + $destHierarchie

      # 対象フォルダを全てコピー
      Copy-Item -Path $source -Destination $destFilePath -Recurse
      # 移動後サイズ計上
      $y.DirSize += $targetFileSize
      # 完了フラグを立てる
      $isComp = $True
    }

    # ねずみ返し_完了フラグが真
    if ($isComp)
    {
      continue
    }

    # # 空いているフォルダがない場合、新しいフォルダに処理する
    # 新規フォルダ作成関数使用
    $destRootFolder = CreateNewFolder $targetFileSize $True

    # 処理先ファイルパス作成
    $destFilePath = $destRootFolder[1] + $destHierarchie
    # 対象ファイルコピー
    Copy-Item -Path $source -Destination $destFilePath -Force -Recurse
  }
}


<# 対象フォルダ入力 #>
  # 対象フォルダパス入力
  Write-Host("対象フォルダ指定してください")
  $USR = (Read-Host 入力してください)
  # 先頭文末ダブルクォーテーション削除
  if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
  if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  $targetRootPath = $USR


<# 本処理 #>
  # パスでは置換が行えないので円マークをエスケープ
  $targetRootPathRep = $targetRootPath -replace "\\", "\\"

  # 一つ目の先フォルダ作成
  $destRoot = $destFolderName + $Script:destFolderNum
  New-Item -Path $destRoot\ -ItemType Directory -Force

  # フォルダ処理関数使用
  ProcessFolder $targetRootPath
  # ファイル処理関数使用
  ProcessFile $targetRootPath


  echo ""
  echo $threshold
  echo $destDirMgr
  echo 処理が完了しました