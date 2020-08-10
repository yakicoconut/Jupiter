$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo 指定フォルダ内ファイル取得
# 概要
#   ・指定フォルダ内のファイルを一括で取得する
#   ・powershellはWinでファイル名に指定可能な
#     「[]」がワイルドカードなため「Get-ChildItem」の
#     「-Path」オプションでは予期せぬ動きとなるため
#     「-literalpath」を使用する
# サイト
#   PowerShellの、パス指定まわりのややこしい話 Get-ChildItem (dir/ls) 編 : みかみのてきとーログ
#   	https://kanamiyuki.exblog.jp/9447561/
#   PowerShellのメモ～PathとLiteralPathパラメータについて - Qiita
#     https://qiita.com/mima_ita/items/486566b717743e9d2626


<# ファイル検索関数 #>
  # # ファイル検索
  # 引数01:検索対象フォルダ
  # 返り値:検索結果
  function GetChildItem ($tgtRootPath)
  {
    # ファイル情報を配列で取得
    # Get-ChildItem
    #       -Path:対象パス記述(省略可)
    #             ワイルドカードを受け付ける
    #   -literal~:ワイルドカードを受け付けない対象パス
    #    -Recurse:回帰的
    $items = @(Get-ChildItem -LiteralPath $tgtRootPath -Recurse)
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
    $items = Get-ChildItem -LiteralPath $tgtRootPath -Recurse | Where-Object{$_.Name -match "$regFileName"}
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