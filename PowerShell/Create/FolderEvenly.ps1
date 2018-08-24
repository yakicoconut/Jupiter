$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo フォルダ内のファイルを閾値の容量で分割する
# PowerShell で フォルダの容量一覧を取得したい - tech.guitarrapc.c?m
#   http://tech.guitarrapc.com/entry/2013/09/26/071905
# PowerShellでPSCustomObjectに複数のObjectを追加する - tech.guitarrapc.c?m
#   http://tech.guitarrapc.com/entry/2013/06/25/230640


<# 事前準備 #>
  # 閾値(KB)
  # 1B=0.000001MB、1KB=0.001MB、1000MB=1GB
  $thresholdMB = 10
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


<# ファイル処理関数 #>
 # 引数01:対象フォルダパス
function ProcessFile($targetFolderPath)
{
  # 直下ファイル情報取得関数使用
  $directlyFiles = GetDirectlyFileInfo $targetFolderPath

  # ファイル処理
  foreach($x in $directlyFiles)
  {
    # 対象ファイルサイズが閾値を越す場合
    if ($x.Length -gt $threshold)
    {
      # 処理対象パス
      $source = $x.FullName

      # 新規フォルダ作成関数使用
      $destRootFolder = CreateNewFolder $x.Length $False

      # 対象ファイルパスからディレクトリ構造を取得
      $destHierarchie = $source -replace $targetRootPathRep, ""
      # 処理先ファイルパス作成
      $destFilePath = $destRootFolder[1] + $destHierarchie

      # 親フォルダパス作成
      $destParentPath = Split-Path $destFilePath -Parent

      # フォルダ構成作成
      New-Item -Path $destParentPath -ItemType Directory -Force
      # 対象ファイルコピー
      Copy-Item -Path $source -Destination $destParentPath -Force

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
      # 処理対象パス
      $source = $x.FullName
      $destRoot = $y.DirName
      # 対象ファイルパスからディレクトリ構造を取得
      $destHierarchie = $source -replace $targetRootPathRep, ""
      # 処理先ファイルパス作成
      $destFilePath = $destRoot + $destHierarchie
      # 親フォルダパス作成
      $destParentPath = Split-Path $destFilePath -Parent

      # フォルダ構成作成
      New-Item -Path $destParentPath -ItemType Directory -Force
      # 対象ファイルコピー
      Copy-Item -Path $x.FullName -Destination $destRoot$destHierarchie -Force
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
    # 処理対象パス
    $source = $x.FullName
    # 新規フォルダ作成関数使用
    $destRootFolder = CreateNewFolder $x.Length $True

    # 対象ファイルパスからディレクトリ構造を取得
    $destHierarchie = $source -replace $targetRootPathRep, ""
    # 処理先ファイルパス作成
    $destFilePath = $destRootFolder[1] + $destHierarchie
    # 親フォルダパス作成
    $destParentPath = Split-Path $destFilePath -Parent

    # フォルダ構成作成
    New-Item -Path $destParentPath -ItemType Directory -Force
    # 対象ファイルコピー
    Copy-Item -Path $source -Destination $destParentPath -Force
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
    # ねずみ返し_対象フォルダサイズが0の場合
    if ([String]::IsNullOrEmpty($x.KB))
    {
      # 空フォルダ作成
      # 処理対象パス
      $source = $x.FullName
      # 処理先は先フォルダ1に固定
      $destRoot = $Script:destDirMgr[0].DirName

      # 対象ファイルパスからディレクトリ構造を取得
      $destHierarchie = $source -replace $targetRootPathRep, ""
      # 処理先ファイルパス作成
      $destBlunkFolderPath = $destRoot + $destHierarchie

      # フォルダ作成
      New-Item -Path $destBlunkFolderPath -ItemType Directory -Force

      continue
    }

    # 対象フォルダサイズが閾値を越す場合
    if ($x.KB -gt $threshold)
    {
      # 自身を回帰的に呼び出す
      ProcessFolder $x.Fullname

      # ファイル処理関数使用
      ProcessFile $x.Fullname

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
      if ($y.DirSize + $x.KB -gt $threshold)
      {
        continue
      }

      # # 容量が空いている先フォルダに処理
      # 処理対象パス
      $source = $x.FullName
      $destRoot = $y.DirName

      # 対象ファイルパスからディレクトリ構造を取得
      $destHierarchie = $source -replace $targetRootPathRep, ""
      # 処理先ファイルパス作成
      $destFilePath = $destRoot + $destHierarchie

      # 対象フォルダを全てコピー
      Copy-Item -Path $x.Fullname -Destination $destFilePath -Recurse
      # 移動後サイズ計上
      $y.DirSize += $x.KB
      # 完了フラグを立てる
      $isComp = $True
    }

    # ねずみ返し_完了フラグが真
    if ($isComp)
    {
      continue
    }

    # # 空いているフォルダがない場合、新しいフォルダに処理する
    # 処理対象パス
    $source = $x.FullName

    # 新規フォルダ作成関数使用
    $destRootFolder = CreateNewFolder $x.KB $True

    # 対象ファイルパスからディレクトリ構造を取得
    $destHierarchie = $source -replace $targetRootPathRep, ""
    # 処理先ファイルパス作成
    $destFilePath = $destRootFolder[1] + $destHierarchie
    # 対象ファイルコピー
    Copy-Item -Path $source -Destination $destFilePath -Force -Recurse
  }
}


<# 対象フォルダ入力 #>
  # 対象フォルダパス入力
  Write-Host("対象フォルダ入力してください")
  $targetRootPath = (Read-Host 入力してください)

<# ダブルクォーテーション判断 #>
  # 一文字目が「"」の場合
  if ($targetRootPath.Substring(0, 1) -eq "`"" )
  {
    # 先頭のダブルクォートを取る
    $targetRootPath = $targetRootPath.Substring(1, $targetRootPath.Length - 1)
  }
  # 文末が「"」の場合
  if ($targetRootPath.Substring($targetRootPath.Length - 1, 1) -eq "`"" )
  {
    # 末尾のダブルクォートを取る
    $targetRootPath = $targetRootPath.Substring(0, $targetRootPath.Length - 1)
  }


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