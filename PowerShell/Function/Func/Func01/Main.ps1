$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
Write-Host "関数テスト01_メイン"
Write-Host
# Powershellで引数を受け取る | マイクロソフ党ブログ
# 	https://microsoftou.com/ps-arguments/


<# エラーパターン #>
  try
  {
    # テスト関数01使用
    FnNoArg "abc"
  }
  catch
  {
    # エラー内容
    Write-Host "-----------------"
    Write-Host "宣言前関数使用"
    Write-Host "  エラーパターン"
    Write-Host "  ※関数宣言前に呼び出し記述を行うとエラーとなる"
    Write-Host
    Write-Host "  $error[0]"
    Write-Host
  }


<# 関数宣言 #>
  # # 引数設定なし関数
  #   引数01:なし
  #   返り値:なし
  function FnNoArg
  {
    Write-Host
    Write-Host $Args[0]
    Write-Host $Args[1]
    Write-Host
  }

  # # 引数設定あり関数
  #   引数01:型指定なし
  #   返り値:なし
  #   
  function FnOneArg ($arg01)
  {
    Write-Host
    Write-Host $arg01
    Write-Host
  }

  # # 引数設定複数関数
  #   引数01:型指定なし
  #   引数02:型指定なし
  #   返り値:なし
  #   
  function FnMultiArg ($arg01, $arg02 = "abc")
  {
    Write-Host
    Write-Host $arg01
    Write-Host $arg02
    Write-Host
  }
  
  # # Param引数設定関数
  #   引数01:型指定なし
  #   引数02:型指定なし
  #   返り値:なし
  function FnParam
  {
    # 引数設定
    param ($arg01, $arg02)

    Write-Host
    Write-Host $arg01
    Write-Host $arg02
    Write-Host
  }

  # # 引数型設定関数
  #   引数01:int16型
  #   返り値:なし
  function FnTypeSet ([int16]$arg01)
  {
    Write-Host
    Write-Host $arg01
    Write-Host
  }

  # # 引数デフォルト値設定関数
  #   引数01:型指定なし
  #   返り値:なし
  function FnDefValSet ($arg01 = "DefaultValue")
  {
    Write-Host
    Write-Host $arg01
    Write-Host
  }

  # # 引数必須設定関数
  #   引数01:型指定なし
  #   引数02:型指定なし
  #   返り値:なし
  function FnMandatorySet ($arg01, [parameter(mandatory)]$arg02)
  {
    Write-Host
    Write-Host $arg01
    Write-Host $arg02
    Write-Host
  }

  # # 引数値指定設定関数
  #   引数01:型指定なし
  #   引数02:型指定なし
  #   返り値:なし
  function FnValSet ([ValidateSet("abc","def")]$arg01)
  {
    Write-Host
    Write-Host $arg01
    Write-Host
  }


  # # 単数返り値関数
  #   引数01:型指定なし
  #   引数02:型指定なし
  #   返り値:返り値
  function FnOneRet ($arg01, $arg02)
  {
    # 値複合
    $retVal = "$arg01" + "$arg02"

    return $retVal
  }

  # # 複数返り値関数
  #   引数01:型指定なし
  #   引数02:型指定なし
  #   返り値:返り値配列
  function FnMultiRet ($arg01, $arg02)
  {
    # 値複合
    $retVal1 = "$arg01" + "+" + "$arg02"
    $retVal2 = "$arg01" + "-" + "$arg02"

    # 返却配列追加
    $ret = @()
    $ret += $retVal1
    $ret += $retVal2

    return $ret
  }


<# 関数使用 #>
  # カウンタ初期化
  $counter = 0

  Write-Host "-----------------"
    Write-Host "引数なし関数に引数を渡す"
    Write-Host "  関数には引数設定を行っていないが"
    Write-Host "  引数はArgs変数に配列として格納される"
    $counter++
    # 関数使用
    FnNoArg $counter "str$counter"

  Write-Host "-----------------"
    Write-Host "引数設定あり関数に引数を渡す"
    $counter++
    FnOneArg $counter
 
  Write-Host "-----------------"
    Write-Host "引数複数設定関数に引数を複数渡す"
    $counter++
    FnMultiArg $counter "str$counter"

  Write-Host "-----------------"
    Write-Host "引数複数設定関数に引数を複数渡す"
    Write-Host "  関数使用時にオプションとして"
    Write-Host "  引数名を指定可能"
    $counter++
    FnMultiArg -arg02 $counter -arg01 "str$counter"

  Write-Host "-----------------"
    Write-Host "param引数設定"
    $counter++
    FnParam $counter "str$counter"

  Write-Host "-----------------"
    Write-Host "引数型設定設定"
    Write-Host "  エラーパターン"
    Write-Host "  ※設定されている型に変換できない値を渡すとエラーとなる"
    $counter++
    try
    {
      FnTypeSet "str$counter"
    }
    catch
    {
      Write-Host
      Write-Host "  $error[0]"
      Write-Host
    }
    
  Write-Host "-----------------"
    Write-Host "引数デフォルト値設定"
    FnDefValSet

  Write-Host "-----------------"
    Write-Host "必須設定引数"
    Write-Host "  エラーパターン"
    Write-Host "  ※必須設定引数が渡されない場合、エラー"
    $counter++
    try
    {
      FnMandatorySet $counter
    }
    catch
    {
      Write-Host
      Write-Host "  $error[0]"
      Write-Host
    }

  Write-Host "-----------------"
    Write-Host "引数値指定設定"
    Write-Host "  エラーパターン"
    Write-Host "  ※指定の値以外を渡した場合、エラー"
    $counter++
    try
    {
      FnValSet $counter
    }
    catch
    {
      Write-Host
      Write-Host "  $error[0]"
      Write-Host
    }

  Write-Host "-----------------"
    Write-Host "単数返り値"
    $counter++
    $var = FnOneRet $counter "str$counter"
    Write-Host
    Write-Host $var
    Write-Host
  
  Write-Host "-----------------"
    Write-Host "複数返り値"
    $counter++
    $var = FnMultiRet $counter "str$counter"
    Write-Host
    foreach ($x in $var)
    {
      Write-Host $x
    }
    Write-Host