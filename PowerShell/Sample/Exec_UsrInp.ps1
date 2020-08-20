using module "..\OwnLib\UsrInp.psm1"
# # ユーザ入力関連関数クラスサンプル

# タイトル設定
$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 致命的でないエラーで処理終了設定
$ErrorActionPreference = "Stop"


# ユーザ入力関連関数クラスインスタンス生成
$usrInpClass = [UsrInpClass]::new()

Write-Host "--------------------"
# ユーザ入力メソッド使用
$inpData = $usrInpClass.UserInput("文字列-ループオン", $true, "STR")
$inpData
Write-Host

Write-Host "--------------------"
$inpData = $usrInpClass.UserInput("パス-ループオン", $true, "PATH")
$inpData
Write-Host

Write-Host "--------------------"
$inpData = $usrInpClass.UserInput("パス-ループオフ", $false, "PATH")
$inpData
Write-Host