$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# エラー発生時の挙動設定
# $ErrorActionPreference
#   Continue        :既定、エラー表示、続行
#   Stop            :エラー表示、停止
#   Inquire         :エラー表示、続行確認
#   Suspend         :さらなる調査のため、ワークフロー ジョブを自動的に中断します。
#                    調査の後で、ワークフローを再開できます。
#   SilentlyContinue:エラー表示なし、中断なし
# サイト
#   PowerShellでのエラーハンドリングについて - Qiita
#   	https://qiita.com/toshihirock/items/936b33f0c15723565dce


<# エラー用関数 #>
  # # エラー用関数
  #   引数01:カウンタ
  #   返り値:カウンタ
  function ErrorOccur
  {
    # 引数設定
    param ($i)
    Write-Host "-----------------"

    # エラー前表示
    $i++
    Write-Host $i

    # 致命的でないエラー発生
    Get-ChildItem "ABC:\"

    # エラー後表示
    $i++
    Write-Host $i

    return $i
  }


<# 設定 #>
  # カウンタ
  $counter = 0


<# Continue(規定値) #>
  # 設定なしの場合、Continueとなる
  # エラー用関数使用
  $counter = ErrorOccur($counter)

<# Inquire #>
  # エラー表示、続行確認
  $ErrorActionPreference = "Inquire"
  # エラー用関数使用
  $counter = ErrorOccur($counter)

<# Inquire #>
  # 要調査
  $ErrorActionPreference = "Suspend"
  # エラー用関数使用
  $counter = ErrorOccur($counter)

<# SilentlyContinue #>
  # エラー表示なし、中断なし
  $ErrorActionPreference = "SilentlyContinue"
  # エラー用関数使用
  $counter = ErrorOccur($counter)

<# Stop #>
  # 致命的でないエラーで処理終了設定
  $ErrorActionPreference = "Stop"
  # エラー用関数使用
  $counter = ErrorOccur($counter)