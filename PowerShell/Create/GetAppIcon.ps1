$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo アプリのアイコンを取得する
# PowerShell でプログラムのアイコンを抽出する
# 	https://www.vwnet.jp/Windows/PowerShell/2017122001/ExtractionIcon.htm


<# 対象ファイル入力 #>
  Write-Host ""
  Write-Host 対象App入力
  $USR = (Read-Host 入力してください)
  # 先頭文末ダブルクォーテーション削除
  if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
  if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  $targetAppPath = $USR


<# 事前準備 #>
  # ファイル名のみ取得
  $createFileName = $(Get-ChildItem $targetAppPath).Name + ".ico"


<# アイコン取得 #>
  # アセンブリロード
  Add-Type -AssemblyName System.Drawing
  # 対象アプリのアイコンデータ抽出
  $iconData = [System.Drawing.Icon]::ExtractAssociatedIcon( $targetAppPath )

  # 出力用ファイルストリーム
  $fs = New-Object System.IO.FileStream($createFileName, [System.IO.FileMode]::Create)

  # 保存
  $iconData.Save( $fs )
  # オブジェクト始末
  $fs.Close()
  $fs.Dispose()
  $iconData.Dispose()


echo ""
echo 処理が完了しました