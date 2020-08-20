# # 単体実行/呼び出し判別サンプル
# 概要
#   単体実行/呼び出し判別の
#   呼び出しパターン

$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 致命的でないエラーで処理終了設定
$ErrorActionPreference = "Stop"


<# ユーザ入力関数 #>
  # ユーザ入力関数使用
  ..\LogicTemp\UsrInpDecide.ps1 "Test1"