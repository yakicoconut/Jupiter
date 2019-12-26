$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
Write-Host "関数テスト01_メイン"
Write-Host
# 関数機能


<# エラーパターン #>
  try
  {
    # テスト関数01使用
    Test01 "abc"
  }
  catch
  {
    # エラー内容
    Write-Host "エラーパターン"
    Write-Host "※関数宣言前に呼び出し記述を行うとエラーとなる"
   Write-Host "  $error[0]"
    Write-Host
  }


<# 関数宣言 #>
  # # テスト関数01
  #   引数01:
  #   返り値:
  function Test01
  {
    # 引数設定
    param ($arg01)

    Write-Host "テスト関数01"
    Write-Host $arg01
    Write-Host
  }

  # テスト関数02
  #   引数01:
  #   返り値:
  function Test02 ($arg01)
  {
    # 引数設定を「param」キーワードなしで行う
    Write-Host "テスト関数02"
    Write-Host $arg01
    Write-Host
  }

  # # テスト関数03
  # #   引数01:
  # #   返り値:
  # function Test03 ([string]$arg01)
  # {
  #   # 引数に型を設定
  #   $calc = $arg01 / 2
  #   Write-Host "テスト関数02"
  #   Write-Host $calc
  #   Write-Host
  # }


<# 関数使用 #>
  # テスト関数01使用
  Test01 "def"
  # テスト関数02使用
  Test02 "ghi"
  # # テスト関数03使用
  # Test03 "4"
  # Test03 4