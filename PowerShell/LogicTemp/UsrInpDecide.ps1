$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 概要
#   単体実行/呼び出し判別
# 使用法
#   ・本ファイル単体実行の場合、ユーザ入力あり
#   ・引数あり呼び出しの場合、ユーザ入力なし


<# 文字表示関数 #>
  # # 文字表示
  #   引数01:表示文言
  #   返り値:なし
  function EchoDesc($description)
  {
    # 文言表示
    Write-Host $description
  }

<# 単体呼び出し処理関数 #>
  # # 単体呼び出しでのみ実行する処理
  #   引数01:なし
  #   返り値:なし
  function SingleExec()
  {
    Write-Host "単体実行"
    Write-Host "表示文言入力"
    $USR = (Read-Host 入力してください)
    Write-Host
    # スクリプト変数に値設定
    $script:desc = $USR
  }

<# 呼び出し判断 #>
  # 呼び出し元情報取得
  $callstack = Get-PsCallStack
  # 引数設定
  $desc = $Args[0]

  # 単体実行(本ファイル+スクリプトブロックの二つ)の場合
  if($callstack.Length -eq 2)
  {
    # 単体呼び出し処理関数使用
    SingleExec
  }

  # 文字表示関数使用
  EchoDesc $desc