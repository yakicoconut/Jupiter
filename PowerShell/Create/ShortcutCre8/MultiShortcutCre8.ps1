$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo ショートカット作成PS
echo ※アイコンフォルダは本スクリプトの「\MyResorce\Icon」に配置


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
  Write-Host("ショートカット作成")

  Write-Host("")
  foreach($x in $csv)
  {
    try
    {
      Write-Host($x.名称)

      <# ショートカット作成 #>
        # 出力フォルダ指定がある場合
        $outFolder=$x.出力フォルダ
        if($outFolder -ne "") {
          # 文末が「\」でない場合
          if($outFolder.Substring($outFolder.Length - 1, 1) -ne "\") {
            # 「\」追記
            $outFolder = $outFolder + "\"
          }

          # 出力先フォルダがない場合
          if(-Not(Test-Path $outFolder)){
            # フォルダ作成
            New-Item $outFolder -ItemType Directory
          }
        }

        # ねずみ返し_名称の設定がない場合
        if($x.名称 -eq "") {
          # 上記処理のフォルダ作成は実行する
          continue
        }

        # ショートカットファイル作成
        $shortcut = $wshShell.CreateShortcut($outFolder + $x.名称 + "-ShortCut.lnk")

        # 相対パスで作成する場合
        if($x.相対フラグ -eq $true) {
          # ショートカット先設定
          $shortcut.TargetPath = "%windir%\explorer.exe"
          # 引数設定
          $shortcut.Arguments = $x.パス
        }
        else {
          $shortcut.TargetPath = $x.パス
        }
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