$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo ショートカットアイコン変更PS
echo ※アイコンフォルダは本スクリプトの「\MyResorce\Icon」に配置
# powershellでショートカットのリンク先変更 - Qiita
# 	https://qiita.com/z0189/items/e661185477888e6e0025


<# 事前設定 #>
  # 続行可能エラーでもコマンドを終了する設定
  $ErrorActionPreference = "Stop"


<# 対象ファイル入力 #>
  Write-Host ""
  Write-Host 対象CSV入力
  $USR = (Read-Host 入力してください)
  # 先頭文末ダブルクォーテーション削除
  if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
  if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  $targetCsvPath = $USR


<# 事前処理 #>
  # CSVファイル読み込み
  $csv = Import-Csv $targetCsvPath -Delimiter "," -Encoding Default
  # アイコンフォルダパス作成(アイコンは絶対パスの必要がある)
  $iconDirPath = (Split-Path( & { $myInvocation.ScriptName } ) -parent) + "\MyResorce\Icon\"
  # シェル変数生成
  $wshShell = New-Object -comObject WScript.Shell


<# CSVファイル内容ループ #>
  Write-Host("")
  Write-Host("")
  Write-Host("ショートカットアイコン変更")

  Write-Host("")
  foreach($x in $csv)
  {
    try
    {
      # csvから実際のファイルを検索
      $targetFile = Get-ChildItem $x.パス
      # ねずみ返し_対象ファイルが存在しない場合
      if ($targetFile -eq "")
      {
        continue
      }

      # ファイルからショートカットオブジェクト生成
      $shortcut=$wshShell.createshortcut($targetFile)
      # アイコン設定
      $shortcut.IconLocation = ($iconDirPath + $x.アイコン)

      # 保存
      $shortcut.Save()
    }
    catch
    {
      Write-Host("")
      Write-Host("【エラー】")
      Write-Host("$x")
      Write-Host("  " + $error[0])
      Write-Host("")
      continue
    }
  }