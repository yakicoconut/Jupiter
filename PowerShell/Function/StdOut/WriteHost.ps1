$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 概要
#   「Write-Host」は画面表示のみ行う
#   「Write-Output」とは動作が異なる
# サイト
#   Write-HostとWrite-Outputの違い - しばたテックブログ
#   	https://blog.shibata.tech/entry/2016/01/11/151201


<# Write-Host #>
  Write-Host "--------------------"
  Write-Host "画面表示"
  Write-Host "--------------------"
  Write-Host "色指定" -ForegroundColor red
  Write-Host "--------------------"
  Write-Host "背景色指定" -ForegroundColor black -BackgroundColor yellow
