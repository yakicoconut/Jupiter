$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# # ユーザ入力関連関数クラス

class UsrInpClass
{
  <# コンストラクタ #>
    # # コンストラクタ
    UsrInpClass()
    {

    }

  <# ユーザ入力メソッド #>
    # # ユーザ入力
    #   引数
    #     01:表示文言
    #     02:不正入力ループ
    #     03:判断モード
    #   返り値
    #     01:入力値(文字列)
    #     02:判断結果(文字列)
    #          0   :判断失敗
    #          1   :判断成功
    #          以外:該当判断の返り値
    [Object] UserInput([string] $description, [bool] $isInvalidLoop, [string] $mode)
    {
      # # 事前準備
        # 返却用入力値初期化
        $usr = ""
        # 返却用判定結果初期化(1:成功)
        $jdgResult = 1
        # 入力処理実行フラグ初期化
        $isExec = $true
        # 表示文字列
        $desc = $description

      # # 回帰実行ループ
        while ($isExec)
        {
          # 入力処理メソッド使用
          $inpData = $this.ExecInput($desc, $isInvalidLoop, $mode)
          # 再入力フラグ
          $isExec = $inpData[0]
          if($isExec)
          {
            # 表示文言更新
            $desc = $inpData[1]
            continue
          }

          # 入力文字列設定
          $usr = $inpData[1]
          # 返却用判定結果設定
          $jdgResult = $inpData[2]
        }

      # 返却配列追加
      $ret = @()
      $ret += $usr
      $ret += $jdgResult

      return $ret
    }

  <# 入力処理メソッド #>
    # # ユーザ入力処理
    #   引数
    #     01:表示文言
    #     02:不正入力ループ
    #     03:判断モード
    #   返り値
    #     01:再入力フラグ(bool)
    #          真:再入力する
    #          偽:再入力しない
    #     02:※以下いずれか
    #        表示文言(string)
    #        入力値
    #     03:
    [object] ExecInput([string] $description, [bool] $isInvalidLoop, [string] $mode)
    {
      # # 事前準備
        # 返却用配列
        $ret = @()
        # 再入力フラグ初期化
        $reInpFlg = $isInvalidLoop
        # 返却用判定結果初期化(1:成功)
        $jdgResult = 1

      # # 入力処理
        # 文言表示
        Write-Host $description
        $usr = (Read-Host 入力してください)
        Write-Host
        # ねずみ返し_無入力の場合
        if($usr.length -eq 0)
        {
          # 返却配列追加
          $ret += $reInpFlg
          $ret += "入力値がありません"
          return $ret
        }

      # # 先頭文末Wクォート削除
        if($usr.Substring(0, 1) -eq "`""){ $usr = $usr.Substring(1, $usr.Length - 1) }
        if($usr.Substring($usr.Length - 1, 1) -eq "`""){ $usr = $usr.Substring(0, $usr.Length - 1) }
    
      # # モードスイッチ
        switch ($mode)
        {
          "STR"
          {
            # 文字列の場合、不正入力ループフラグは
            # 使用されない
          }
          "PATH"
          {
            # パス存在フラグ設定
            $isExist = Test-Path($usr)
            # 存在しない
            if(-not $isExist)
            {
              # 不正入力ループ有効
              IF($reInpFlg)
              {
                # 返却配列追加
                $ret += $reInpFlg
                $ret += "対象パスが存在しません"
                return $ret
                # 上記以外のパターン(以下)はすべてねずみ返しする必要がない
                # ・パスが存在する
                # ・不正入力ループが無効な場合
              }

              # 返却用判定結果を失敗に設定
              $jdgResult = 0
            }
          }
          "NUM"
          {

          }
          "DATE"
          {

          }
          "TIME"
          {

          }
  
          default
          {
            Write-Host "モード引数の値が定義と異なるため" -ForegroundColor red
            Write-Host "終了します" -ForegroundColor red
            exit
          }
        }
  
      # 返却配列追加
      $ret += $false
      $ret += $usr
      $ret += $jdgResult
  
      return $ret
    }
  }