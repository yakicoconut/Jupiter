$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 概要
#   「Write-Output」は標準出力への出力を行い、
#   パイプラインの最後のコマンドの場合、画面表示がされる
# サイト
#   Write-HostとWrite-Outputの違い - しばたテックブログ
#   	https://blog.shibata.tech/entry/2016/01/11/151201
#   Powershellでの関数のreturnとクラスでのreturnの違い - Qiita
#   	https://qiita.com/sunoko/items/7c6e936fdf82a69a0ee6


<# Write-Output検証関数 #>
  # # Write-Output
  #   引数01:なし
  #   引数02:なし
  #   返り値:なし
  function TestWriteOut
  {
    Write-Host "表示1"
    Write-Output "abc"
    echo "def"
    "ghi"
    Write-Host "表示2"
    return "jkl"
  }


<# テストクラス #>
  # クラス定義
  class TestClass
  {
    <# Write-Output検証メソッド #>
      # # Write-Output検証
      #   引数01:なし
      #   返り値:文字列
      [string] TestMeth()
      {
        Write-Host "表示1"
        Write-Output "abc"
        echo "def"
        "ghi"
        Write-Host "表示2"
        return "jkl"
      }
  }


<# 関数使用 #>
  Write-Host "--------------------"
  Write-Host "・関数の返り値を受けない場合、"
  Write-Host "  画面出力される"
  Write-Host "・「echo」は「Write-Output」のエイリアス"
  Write-Host "・コマンドなしで値を記述した場合も同様の動作となる"
  Write-Host
  # Write-Output検証関数使用
  TestWriteOut

  Write-Host "--------------------"
  Write-Host "返り値を受け取る場合は"
  Write-Host "画面出力されず、"
  Write-Host "Write-Outputとreturnの併用は"
  Write-Host "返り値も複数になる"
  Write-Host
  $ret = TestWriteOut
  Write-Host
  Write-Host $ret

  Write-Host "--------------------"
  Write-Host "メソッドではreturnに"
  Write-Host "指定されたものだけ返される"
  Write-Host
  $TestObject = [TestClass]::new()
  $TestObject.TestMeth()
  Write-Host "----------"
  $ret2 = $TestObject.TestMeth()
  Write-Host $ret2
