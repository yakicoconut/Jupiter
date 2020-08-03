Write-Host ウィンドウタイトルにファイルタイトルを設定

# ウィンドウタイトルにファイルタイトルを設定
$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name