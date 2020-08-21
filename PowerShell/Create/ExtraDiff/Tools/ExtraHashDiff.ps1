using module "..\..\..\OwnLib\UsrInp.psm1"
using module "..\..\..\OwnLib\DiffAry.psm1"
# # ハッシュ一覧から差分抽出

# タイトル設定
$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 致命的でないエラーで処理終了設定
$ErrorActionPreference = "Stop"


<# ハッシュ差分抽出関数 #>
  # # ハッシュ一覧から差分ファイルコピー処理
  #   引数01:今回ハッシュ一覧CSVパス
  #   引数02:前回ハッシュ一覧CSVパス
  #   引数03:コピー元フォルダパス
  #   引数04:コピー先フォルダパス
  #   返り値:なし
  function ExtraDiffFromHash($crCsvPath, $preCsvPath, $copyOrigin, $copyDist)
  {
    # # ねずみ返し_ハッシュ一覧が前回と一致する場合、終了
      $crCsvHash = Get-FileHash -Algorithm SHA1 $crCsvPath
      $preCsvHash = Get-FileHash -Algorithm SHA1 $preCsvPath
      if($preCsvHash.Hash -eq $crCsvHash.Hash)
      {
        Write-Host "ハッシュ一覧が前回と同じため" -ForegroundColor Yellow
        Write-Host "終了します" -ForegroundColor Yellow
        exit
      }

    # # コピー先フォルダ作成
      if (!(Test-Path $copyDist)){New-Item $copyDist -ItemType Directory}

    # # CSV読み込み
      $crCsv = Import-Csv $crCsvPath -Delimiter "," -Encoding Default
      $preCsv = Import-Csv $preCsvPath -Delimiter "," -Encoding Default

    # # 削除ファイル一覧作成
      # 配列差分取得関連クラスインスタンス生成
      $diffAryClass = [DiffAryClass]::new()
      # 削除対象取得
      $delFileList = $diffAryClass.LackDiff($preCsv.Path, $crCsv.Path)

      # 削除対象がある場合
      if($delFileList.Length -ge 1)
      {
        # 削除対象テキスト出力
        $delFileList | out-file -filepath ($copyDist + "\DELTARGET.txt")
        # 削除バッチコピー
        Copy-Item ($PSScriptRoot + "\DelFiles.bat") $copyDist
      }

    # # コピー処理
      # 今回ハッシュ一覧CSVループ
      foreach ($x in $crCsv)
      {
        # 対象パス取得
        $tgtPath = $x.Path

        # 前回CSVからインデックス取得
        $indPrePath = [Array]::IndexOf($preCsv.Path, $tgtPath)

        # # 前回ハッシュ値と同一の場合
          # 存在有無
          if($indPrePath -ge 0)
          {
            # ハッシュが同一
            if($x.Hash -eq $preCsv[$indPrePath].Hash)
            {
              continue
            }
          }

        # # コピー
          # フォルダ作成
          $distDir = $copyDist + (Split-Path -Parent $tgtPath)
          if (!(Test-Path ($distDir))){New-Item $distDir -ItemType Directory}
          # ファイルコピー
          Copy-Item ($copyOrigin + $tgtPath) $distDir
      }

      # CSVコピー
      Copy-Item $crCsvPath $copyDist
      Copy-Item $preCsvPath $copyDist
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
    # 今回ハッシュ一覧CSV入力
    $retData = $usrInpClass.UserInput("今回ハッシュ一覧CSVパス", $true, "PATH")
    $crCsvPath = $retData[0]
    # コピー元フォルダパス入力
    $retData = $usrInpClass.UserInput("コピー元フォルダパス", $true, "PATH")
    $copyOrigin = $retData[0]

    # コピー先フォルダパス設定
    $crDateTime = Get-Date -Format "yyyyMMddHHmmss"
    $copyDist = "Diff_" + $crDateTime
    # 入力省略のため前回ハッシュ一覧CSVファイル名を作成
    $preCsvPath = (Split-Path -Parent $crCsvPath) + "\" + [System.IO.Path]::GetFileNameWithoutExtension($crCsvPath) + "_PRE" + [System.IO.Path]::GetExtension($crCsvPath)

    # 返却用カスタムオブジェクト配列
    $ret = @()
    $ret += $crCsvPath
    $ret += $preCsvPath
    $ret += $copyOrigin
    $ret += $copyDist

    return $ret
  }


<# 呼び出し判断 #>
  # 呼び出し元情報取得
  $callstack = Get-PsCallStack

  # 単体実行(本ファイル+スクリプトブロックの二つ)の場合
  if($callstack.Length -eq 2)
  {
    Write-Host "ハッシュ一覧から差分ファイルコピースクリプト"
    # 単体呼び出し処理関数使用
    $arg = SingleExec
    # ハッシュ差分抽出関数使用
    ExtraDiffFromHash $arg[0] $arg[1] $arg[2] $arg[3]
  }