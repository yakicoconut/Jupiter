$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 概要
#   単体実行/呼び出し判別
# 使用法
#   ・本ファイル単体実行の場合、ユーザ入力あり
#   ・引数あり呼び出しの場合、ユーザ入力なし


<# ユーザ入力関数 #>
  # # ユーザ入力関数
  #   引数01:表示文言
  #   返り値:入力文字列
  function UserInput($description)
  {
    # 文言表示
    Write-Host $description
    $USR = (Read-Host 入力してください)
    # 先頭文末ダブルクォーテーション削除
    if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
    if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  
    return $USR
  }


<# 引数判断 #>
  # 引数設定
  $tgt = $Args[0]

  # 引数がない場合
  if($Args.Length -eq 0)
  {
    # ユーザ入力関数使用
    $tgt = UserInput
  }

  # 表示
  Write-Host $tgt