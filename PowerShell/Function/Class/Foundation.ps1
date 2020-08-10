$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 概要
#  クラス基礎
#    ・定義
#    ・プロパティ
#    ・コンストラクタ
#    ・メソッド
#    ・インスタンス
#    ・hidden
#    ・オーバーロード
#    ・static
# サイト
#   超簡単な PowerShell Class の使い方(その1)
#   	https://www.vwnet.jp/Windows/PowerShell/2017082001/PSv5Class01.htm
#   PowerShellのコンストラクタまとめ - Qiita
#   	https://qiita.com/nimzo6689/items/06b0fc08448ad1aab8ed
#   PowerShell v5の新機能と、実戦で使ってほしい機能 - Build Insider
#     https://www.buildinsider.net/enterprise/powershelldsc/03


<# テストクラス #>
  # クラス定義
  class TestClass
  {
    <# プロパティ #>
      $Prop01
      $Prop02
      hidden $Prop03
      static $Prop04

    <# コンストラクタ #>
      # # コンストラクタ
      #   引数01:型指定なし
      TestClass($arg)
      {
        # プロパティ設定
        $this.Prop01 = $arg
      }

    <# 引数・返り値ありメソッド #>
      # # 引数・返り値あり
      #   引数01:型指定なし
      #   返り値:文字列
      [string] TestMeth01($str)
      {
        return $str + $this.Prop01 + $this.Prop02
      }

    <# 引数・返り値なしメソッド #>
      # # 引数・返り値なし
      #   引数01:なし
      #   返り値:なし
      [void] TestMeth02()
      {
        Write-Host "引数・返り値なし"
        return
      }

    <# ローカルメソッド呼び出しメソッド #>
      # # ローカルメソッド呼び出し
      #   引数01:なし
      #   返り値:なし
      [void] TestMeth03()
      {
        Write-Host "ローカルメソッド呼び出し"
        $this.TestMeth02()
        return
      }

    <# オーバーロードメソッド #>
      # # オーバーロード1
      #   引数01:文字列
      #   返り値:なし
      [void] TestMeth04([string]$arg)
      {
        Write-Host $arg
        return
      }

      # # オーバーロード1
      #   引数01:数値
      #   返り値:なし
      [void] TestMeth04([int]$arg)
      {
        Write-Host $arg.GetType()
        return
      }

    <# static #>
      # # static指定メソッド
      #   引数01:なし
      #   返り値:なし
      static [void] TestMeth05()
      {
        Write-Host "静的メソッド"
        return
      }

      # # staticプロパティ操作メソッド
      #   引数01:なし
      #   返り値:なし
      [void] TestMeth06()
      {
        [TestClass]::Prop04 += 1
        Write-Host ([TestClass]::Prop04)
        return
      }

    <# hidden検証メソッド #>
      # # hidden検証
      #   引数01:なし
      #   返り値:文字列
      hidden [string] HiddenTestMeth()
      {
        return "hidden検証" + $this.Prop03
      }
  }


<# メイン #>
  # # New-Objectコマンドレット
    # テストクラスインスタンス生成
    $TestObject1 = New-Object TestClass -ArgumentList "123"
    # プロパティアクセス
    $TestObject1.Prop02 = "def"
    # テストメソッド実行
    $ret01 = $TestObject1.TestMeth01("abc")
    Write-Host "--------------------"
    Write-Host $ret01
    Write-Host

  # # newメソッド
    # テストクラスインスタンス生成
    $TestObject2 = [TestClass]::new("456")
    # テストメソッド使用
    $ret02 = $TestObject2.TestMeth01("ghi")
    Write-Host "--------------------"
    Write-Host $ret02
    Write-Host
    Write-Host "--------------------"
    $TestObject2.TestMeth02()
    Write-Host

  # # hidden検証
    # hiddenキーワードを用いたメンバは
    # インテリセンスやGet-Memeberで閲覧出来なくなる
    Write-Host "--------------------"
    Write-Host "「HiddenTestMeth」と「Prop03」は表示されない"
    $member = Get-Member -InputObject $TestObject1
    Write-Host $member.Name
    Write-Host

    Write-Host "--------------------"
    Write-Host "C#のprivateのようにアクセスが出来なくなるわけではない"
    $TestObject3 = [TestClass]::new("")
    # hiddenプロパティアクセス
    $TestObject3.Prop03 = "jkl"
    # テストメソッド使用
    $ret03 = $TestObject3.HiddenTestMeth()
    Write-Host $ret03
    Write-Host

  # # ローカルメソッド
    Write-Host "--------------------"
    Write-Host "クラス内でローカルメソッドを呼び出すのは"
    Write-Host "「`$this」変数を指定する"
    # ローカルメソッド呼び出しメソッド使用
    $TestObject3.TestMeth03()
    Write-Host

  # # オーバーロード
    Write-Host "--------------------"
    Write-Host "メソッドはオーバーロードが"
    Write-Host "可能(関数では不可)"
    # ローカルメソッド呼び出しメソッド使用
    $TestObject3.TestMeth04("123")
    $TestObject3.TestMeth04(123)
    Write-Host

  # # 静的メンバ
    Write-Host "--------------------"
    Write-Host "静的メソッドはクラスを"
    Write-Host "インスタンス化せずに使用可能"
    [TestClass]::TestMeth05()
    Write-Host

    Write-Host "--------------------"
    Write-Host "静的プロパティ"
    Write-Host "インスタンス化せずに使用"
    [TestClass]::Prop04 = 1
    Write-Host ([TestClass]::Prop04)

    Write-Host "--------------------"
    Write-Host "インスタンスを跨いで使用可能"
    # インスタンス生成×2
    $TestObject4 = [TestClass]::new("")
    $TestObject5 = [TestClass]::new("")

    # staticプロパティ操作メソッド使用
    Write-Host $TestObject4.TestMeth06()
    Write-Host $TestObject5.TestMeth06()
    Write-Host