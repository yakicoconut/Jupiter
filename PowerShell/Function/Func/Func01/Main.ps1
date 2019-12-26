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
  #   返り値:なし
  function Test01
  {
    # 引数設定
    param ($arg01)

    Write-Host "テスト関数01_通常"
    Write-Host $arg01
    Write-Host
  }

  # # テスト関数02
  #   引数01:
  #   返り値:なし
  function Test02 ($arg01)
  {
    Write-Host "テスト関数02_「param」引数設定"
    Write-Host $arg01
    Write-Host
  }

  # # テスト関数03
  #   引数01:int16型
  #   返り値:なし
  function Test03 ([int16]$arg01)
  {
    Write-Host "テスト関数02_引数型設定"
    Write-Host $arg01
    Write-Host
  }

  # # テスト関数04
  #   引数01:
  #   引数02:
  #   返り値:引数を計算した値
  function Test04 ($arg01, $arg02)
  {
    # 値計算
    $calc = $arg01 + $arg02
    Write-Host "テスト関数04_返り値あり"
    Write-Host "$arg01 + $arg02"

    return $calc
  }

  # # テスト関数05
  #   引数01:
  #   引数02:
  #   返り値:引数を計算した配列
  function Test05 ($arg01, $arg02)
  {
    # 値計算
    $plus = $arg01 + $arg02
    $minus = $arg01 - $arg02
    Write-Host "テスト関数05_複数返り値"
    Write-Host "$arg01 + $arg02"
    Write-Host "$arg01 - $arg02"

    # 返却配列追加
    $ret = @()
    $ret += $plus
    $ret += $minus

    return $ret
  }


<# 関数使用 #>
  # テスト関数01使用
  Test01 "def"
  # テスト関数02使用
  Test02 "ghi"
  # テスト関数03使用
  try
  {
    Test03 "jkl"
  }
  catch
  {
    # エラー内容
    Write-Host "エラーパターン"
    Write-Host "※設定されている型に変換できない値を渡すとエラーとなる"
    Write-Host "  $error[0]"
    Write-Host
  }
  # テスト関数04使用
  $test04Answer = Test04 1 2
  Write-Host "テスト関数04の結果:$test04Answer"
  Write-Host
  # テスト関数05使用
  $test05Answer = Test05 1 2
  Write-Host "テスト関数05の結果:"
  foreach ($x in $test05Answer)
  {
    Write-Host "  "$x
  }
  Write-Host
