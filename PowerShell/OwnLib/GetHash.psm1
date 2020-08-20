$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# ハッシュ一覧CSV作成関連クラス


class GetHashClass
{
  <# コンストラクタ #>
    # # デフォルトコンストラクタ
    #   引数01:なし
    GetHashClass()
    {

    }

  <# ファイルハッシュ一覧作成メソッド #>
    # # ファイルのハッシュ値一覧をCSVとして出力
    #   引数01:対象フォルダパス
    #   引数02:出力ファイル名称
    #   引数03:ハッシュ計算アルゴリズム
    #   返り値:成否フラグ
    [bool] GetFileHashList($tgtRoot, $outFileName, $alg)
    {
      # # 設定
        # 出力用カスタムオブジェクト配列
        $outCsvs = @()

      # # 対象ファイル処理
        $items = Get-ChildItem $tgtRoot -Recurse
        foreach($x in $items)
        {
          # ハッシュ変数初期化
          $tgtHash = $null

          # 配列データからカスタムオブジェクト作成
          $obj = [PSCustomObject]@{
            # 相対パス変換
            Path = $x.Fullname.Replace($tgtRoot, "")
            # カラム初期化
            Hash = ""
            Algorithm = ""
          }

          # ねずみ返し_フォルダの場合
          if($x.PSIsContainer)
          {
            # ハッシュ項目を設定せずにオブジェクト追加
            $outCsvs += $obj
            continue
          }

          # # ハッシュ値取得
            # -Algorithm:SHA1、SHA256、SHA384、SHA512、MACTripleDES、MD5、RIPEMD160
            #            デフォルトはSHA256
            $tgtHash = Get-FileHash -Algorithm $alg $x.Fullname

            # ハッシュ項目設定
            $obj.Hash = $tgtHash.Hash
            $obj.Algorithm = $tgtHash.Algorithm
            $outCsvs += $obj
        }

      # # CSV出力
        $outCsvs | Export-Csv $outFileName -Encoding Default -NoTypeInformation

      return $true
    }
}