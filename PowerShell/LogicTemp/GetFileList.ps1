$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo 指定フォルダ内ファイル取得
# 概要
#   指定フォルダ内のファイルを一括で取得する


<# ファイル検索関数 #>
  # # ファイル検索
  # 引数01:検索対象フォルダ
  # 返り値:検索結果
  function GetChildItem ($tgtRootPath)
  {
    # ファイル情報を配列で取得
    $items = @(Get-ChildItem $tgtRootPath -Recurse)
    return $items
  }

<# 正規表現ファイル検索関数 #>
  # # 正規表現ファイル検索
  # 引数01:検索対象フォルダ
  # 引数02:正規表現
  # 返り値:検索結果
  function GetChildMatchItem ($tgtRootPath, $regFileName)
  {
    # ファイル情報を配列で取得
    $items = Get-ChildItem $tgtRootPath -Recurse | Where-Object{$_.Name -match "$regFileName"}
    return $items
  }


<# メイン #>
  # # 対象フォルダパス入力
    Write-Host 対象フォルダ入力
    $USR = (Read-Host 入力してください)
    # 先頭文末ダブルクォーテーション削除
    if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
    if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
    $tgtRootPath = $USR

  # ファイル検索関数使用
  $items = GetChildItem $tgtRootPath
  foreach($x in $items)
  {
    # 対象表示
    Write-Host $x.name
  }


  # # 正規表現入力
    Write-Host
    Write-Host 正規表現入力
    $USR = (Read-Host 入力してください)
    # 先頭文末ダブルクォーテーション削除
    if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
    if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
    $regFileName = $USR

  # 正規表現ファイル検索関数使用
  $items = GetChildMatchItem $tgtRootPath $regFileName
  # ねずみ返し_対象ファイルが存在しない場合
  if ($null -eq $items)
  {
    Write-Host 対象ファイルなし
  }
  else
  {
    foreach($x in $items)
    {
      # 対象表示
      Write-Host $x.name
    }
  }