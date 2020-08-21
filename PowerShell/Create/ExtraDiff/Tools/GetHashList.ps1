using module "..\..\..\OwnLib\UsrInp.psm1"
using module "..\..\..\OwnLib\GetHash.psm1"
# # ハッシュ一覧作成

# タイトル設定
$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 致命的でないエラーで処理終了設定
$ErrorActionPreference = "Stop"


<# 差分比較用ハッシュ一覧作成関数 #>
  # # 差分比較用ハッシュ一覧作成
  #   引数01:既存ファイルハッシュ一覧存在フラグ
  #   引数02:対象フォルダパス
  #   引数03:出力ファイル名称
  #   引数04:前回識別子(規定値:_PRE)
  #   返り値:なし
  function Cre8DiffHashList($isExistPreFile, $tgtRoot, $outFileName, $preIdentifier = "_PRE")
  {
    # ハッシュ一覧CSV作成関連クラスインスタンス生成
    $getHashClass = [GetHashClass]::new()

    # ファイルハッシュ一覧CSVが既に存在する場合
    if ($isExistPreFile)
    {
      # 前回識別子を付ける
      $preFileName = [System.IO.Path]::GetFileNameWithoutExtension($outFileName) + $preIdentifier + [System.IO.Path]::GetExtension($outFileName)
      # 前々回ファイル削除
      if (Test-Path $preFileName){Remove-Item $preFileName -Force}
      # 退避
      Rename-Item $outFileName $preFileName
    }

    Write-Host "GetFileHashList関数"
    # ファイルハッシュ一覧作成メソッド使用
    $getHashClass.GetFileHashList($tgtRoot, $outFileName, "SHA1")
  }


<# 単体呼び出し処理関数 #>
  # # 単体呼び出しでのみ実行する処理
  #   引数01:なし
  #   返り値:なし
  function SingleExec()
  {
    # ユーザ入力関連関数クラスインスタンス生成
    $usrInpClass = [UsrInpClass]::new()
    # ユーザ入力メソッド使用
    # 対象フォルダパス入力
    $retData = $usrInpClass.UserInput("対象フォルダパス", $true, "PATH")
    $tgtRoot = $retData[0]
    # 出力ファイル名称入力
    $retData = $usrInpClass.UserInput("ハッシュファイル名(要拡張子)", $false, "PATH")
    $outFileName = $retData[0]
    $isExistPreFile = [system.convert]::ToBoolean($retData[1])

    # 入力省略のため前回識別子は規定設定
    $preIdentifier = "_PRE"

    # 返却用カスタムオブジェクト配列
    $ret = @()
    $ret += $tgtRoot
    $ret += $outFileName
    $ret += $isExistPreFile
    $ret += $preIdentifier

    return $ret
  }


<# 呼び出し判断 #>
  # 呼び出し元情報取得
  $callstack = Get-PsCallStack

  # 単体実行(本ファイル+スクリプトブロックの二つ)の場合
  if($callstack.Length -eq 2)
  {
    Write-Host "ハッシュ一覧作成スクリプト"
    # 単体呼び出し処理関数使用
    $arg = SingleExec
    # 差分比較用ハッシュ一覧作成関数使用
    Cre8DiffHashList $arg[0] $arg[1] $arg[2] $arg[3]
  }