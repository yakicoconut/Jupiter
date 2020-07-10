$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo 指定フォルダ内ファイル取得
# 概要
#   指定フォルダ内のファイルを一括で取得する


<# ユーザ入力 #>
  Write-Host 対象フォルダ入力
  $USR = (Read-Host 入力してください)
  # 先頭文末ダブルクォーテーション削除
  if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
  if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  $tgtRootPath = $USR


<# 事前処理 #>
  # ファイル情報を配列で取得
  $items = @(Get-ChildItem $tgtRootPath -Recurse)


<# 本処理 #>
  foreach($x in $items)
  {
    # 対象表示
    Write-Host
    Write-Host $x.name
  }