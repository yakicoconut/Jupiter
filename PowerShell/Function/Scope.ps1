$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 概要
#   スコープ
# サイト
#   超簡単な PowerShell Class の使い方(その5/スコープ)
#   	http://www.vwnet.jp/Windows/PowerShell/2017082302/PSv5Class05.htm
#   変数のスコープ
#   	http://suyamasoft.blue.coocan.jp/PowerShell/Tutorial/Scope/index.html#Script


<# スクリプト変数 #>
  # スクリプト内がスコープ
  $scriptVar1
  $scriptVar2


<# 検証用関数 #>
  # #
  #   引数01:なし
  #   返り値:なし
  function FnTest()
  {
    <# 関数変数 #>
      # 関数内がスコープ
      $fnVar = "関数変数"
      # スクリプト変数設定
      $scriptVar1 = "スクリプト変数1_関数内設定"
      $Script:scriptVar2 = "スクリプト変数2_関数内設定"
  }


<# 検証用クラス #>
  # #
  class TestClass
  {
    <# プロパティ #>
      #
      $ClsProp

    <# 検証メソッド #>
      # #
      #   引数01:なし
      #   返り値:なし
      [void] TestMeth01()
      {
        # スクリプトがスコープ
        $this.ClsProp = "クラスプロパティ"

        # メソッドがスコープ
        $methVar = "メソッド変数"

        # スクリプト変数設定
        $scriptVar1 = "スクリプト変数1_クラス内設定"
        $Script:scriptVar2 = "スクリプト変数2_クラス内設定"

        return
      }
  }


<# メイン #>
  # # スクリプト変数
    Write-Host "--------------------"
    Write-Host "スクリプト変数を"
    Write-Host "スクリプト内で設定"
    Write-Host
    $scriptVar1 = "スクリプト変数1"
    $scriptVar2 = "スクリプト変数2"
    Write-Host $scriptVar1
    Write-Host $scriptVar2
    Write-Host

  # # 関数
    FnTest
    Write-Host "--------------------"
    Write-Host "関数変数は関数内のみ使用可能"
    Write-Host
    Write-Host $fnVar
    Write-Host
    Write-Host "--------------------"
    Write-Host "スクリプト変数は別スコープで"
    Write-Host "単純には使用できない"
    Write-Host
    Write-Host $scriptVar1
    Write-Host
    Write-Host "--------------------"
    Write-Host "スクリプト変数を別スコープで"
    Write-Host "使用する場合、「`$Script:」をつける"
    Write-Host
    Write-Host $scriptVar2
    Write-Host

  # # クラス
    # 検証用クラスインスタンス生成
    $TestObject = [TestClass]::new()
    # テストメソッド使用
    $TestObject.TestMeth01()
    Write-Host "--------------------"
    Write-Host "クラスプロパティは"
    Write-Host "スコープ外でも使用可能"
    Write-Host
    Write-Host $TestObject.ClsProp
    Write-Host
    Write-Host "--------------------"
    Write-Host "メソッド変数はメソッド内のみ有効"
    Write-Host
    Write-Host $TestObject.$methVar
    Write-Host
    Write-Host "--------------------"
    Write-Host "スクリプト変数「`$Script:」なし"
    Write-Host
    Write-Host $scriptVar1
    Write-Host
    Write-Host "--------------------"
    Write-Host "スクリプト変数「`$Script:」あり"
    Write-Host
    Write-Host $scriptVar2
    Write-Host