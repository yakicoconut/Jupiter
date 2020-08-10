$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 概要
#  クラス継承
# サイト
#   超簡単な PowerShell Class の使い方(その4/継承)
#   	http://www.vwnet.jp/Windows/PowerShell/2017082301/PSv5Class04.htm


<# 基底クラス #>
  # クラス定義
  class BaseClass
  {
    <# コンストラクタ #>
      # # コンストラクタ
      #   引数01:数値
      #   返り値:なし
      BaseClass()
      {
        Write-Host "基底クラスコンストラクタ"
      }

    <# 引数・返り値なしメソッド #>
      # # 引数・返り値なし
      #   引数01:なし
      #   返り値:なし
      [void] TestMeth01()
      {
        Write-Host "基底クラスメソッド"
        return
      }
  }


<# 派生クラス #>
  # クラス定義
  class SubClass : BaseClass
  {
    <# コンストラクタ #>
      # # コンストラクタ
      #   引数01:数値
      #   返り値:なし
      SubClass() : Base()
      {
        Write-Host "派生クラスコンストラクタ"
      }

    <# オーバーライドメソッド #>
      # # オーバーライド
      #   基底クラスの同名メソッドを定義
      #   引数01:なし
      #   返り値:なし
      [void] TestMeth01()
      {
        Write-Host "メソッドオーバーライド"
        Write-Host "  基底クラスのメソッドと"
        Write-Host "  同名のメソッド"
        return
      }

    <# 基底クラスメソッド呼び出しメソッド #>
      # # 基底クラスメソッド呼び出し
      #   引数01:なし
      #   返り値:なし
      [void] TestMeth02()
      {
        Write-Host "派生クラスメソッド"
        Write-Host "  派生クラスから基底クラスの"
        Write-Host "  メソッドを呼び出す"
        ([BaseClass]$this).TestMeth01()
        return
      }
  }

<# メイン #>
  # # インスタンス生成
    Write-Host "--------------------"
    Write-Host "基底クラスのコンストラクタを"
    Write-Host "オーバーライドすると呼び出し順は"
    Write-Host "『基底→派生』となる"
    Write-Host
    # テストクラスインスタンス生成
    $TestObject1 = [SubClass]::new()

  # # 基底クラスメソッド呼び出し
    Write-Host "--------------------"
    # 基底クラスメソッド呼び出しメソッド使用
    $TestObject1.TestMeth02()
    Write-Host

  # # オーバーライド
    Write-Host "--------------------"
    # オーバーライドメソッド使用
    $TestObject1.TestMeth01()
    Write-Host