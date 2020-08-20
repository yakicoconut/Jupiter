$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# # 配列差分取得関連クラス


class DiffAryClass
{
  <# コンストラクタ #>
    # # コンストラクタ
    DiffAryClass()
    {

    }

  <# 配列欠如抽出メソッド #>
    # # 二つの配列から欠如している項目を抽出
    #   引数01:対象配列
    #   引数02:比較配列
    #   返り値:結果
    [object] LackDiff([object] $tgtAry, [object] $compAry)
    {
      # 比較配列にないものを取得
      $lack = $tgtAry | Where-Object { $compAry -notcontains $_ }
      # 対象がない場合、return時エラーとなるため?nullを明示的に設定
      if($null -eq $lack){$lack = $null}

      return $lack
    }}