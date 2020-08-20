$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 概要
#   ユーザ入力関連関数集


<# ユーザ入力関数 #>
  # # ユーザ入力関数
  #     引数01:表示文言
  #     引数02:不正入力ループ
  #     引数03:判断モード
  #   返り値01:入力値
  #   返り値02:判断結果
  function UserInput($description, $isInvalidLoop, $mode)
  {
    # 文言表示
    Write-Host $description
    $USR = (Read-Host 入力してください)
    # 先頭文末ダブルクォーテーション削除
    if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
    if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
    Write-Host

    # 返却配列追加
    $ret = @()
    $ret += $USR
    $ret += $jdgResult

    return $ret
  }