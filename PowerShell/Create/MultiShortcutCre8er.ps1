$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo ショートカット作成PS


<# 事前設定 #>
  # 続行可能エラーでもコマンドを終了する設定
  $ErrorActionPreference = "Stop"


<# 対象ファイル入力 #>
  # 対象テキストファイルパス入力
  Write-Host("対象フォルダを記述したファイルを指定してください")
  $targetFilePath = (Read-Host 入力してください)


<# ダブルクォーテーション判断 #>
  # 一文字目が「"」の場合
  if ($targetFilePath.Substring(0, 1) -eq "`"" )
  {
    # 先頭のダブルクォートを取る
    $targetFilePath = $targetFilePath.Substring(1, $targetFilePath.Length - 1)
  }
  # 文末が「"」の場合
  if ($targetFilePath.Substring($targetFilePath.Length - 1, 1) -eq "`"" )
  {
    # 末尾のダブルクォートを取る
    $targetFilePath = $targetFilePath.Substring(0, $targetFilePath.Length - 1)
  }


<# ショートカット作成 #>
  Write-Host("")
  Write-Host("")
  Write-Host("ショートカット作成")

  # Shift-JISでファイル読み込み
  $targetFile = New-Object System.IO.StreamReader($targetFilePath, [System.Text.Encoding]::GetEncoding("sjis"))

  Write-Host("")
  # ファイル内容ループ
  while (($x = $targetFile.ReadLine()) -ne $null)
  {
    # 任意のファイルから任意の位置にショートカットを作成
    # シェル変数生成
    $wshShell = New-Object -comObject WScript.Shell

    try{
      # ファイル名のみ取得
      $createFileName = $(Get-ChildItem $x).Name
      Write-Host("$x")

      # ショートカットファイル作成
      $shortcut = $wshShell.CreateShortcut($createFileName + "-ShortCut.lnk")
      # ショートカット先設定
      $shortcut.TargetPath = $x
      # 保存
      $shortcut.Save()
    }catch{
      Write-Host("")
      Write-Host("【エラー】")
      Write-Host("$x")
      Write-Host("  " + $error[0])
      Write-Host("")
      continue
    }
  }

  # クローズ処理
  $targetFile.Close()