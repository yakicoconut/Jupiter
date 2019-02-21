@echo off
title %~nx0
echo キーボードレイアウト変更
   : Windows/TIPS/レジストリを修正してCAPSLOCKの割り当て変更 - yanor.net/wiki
	 :  http://yanor.net/wiki/?Windows/TIPS/%E3%83%AC%E3%82%B8%E3%82%B9%E3%83%88%E3%83%AA%E3%82%92%E4%BF%AE%E6%AD%A3%E3%81%97%E3%81%A6CAPSLOCK%E3%81%AE%E5%89%B2%E3%82%8A%E5%BD%93%E3%81%A6%E5%A4%89%E6%9B%B4
   : Windows10 CapsLockキーをCtrlキーに割り当てる | 労働者としての生存戦略
	 :  https://workers-strategy.net/84/


: 可変変数
  : 変更対象
  :   ルール1:キー割り当てを変更する単位は以下で表す
  :           「xxxxyyyy」
  :           xxxx:変更後の機能
  :           yyyy:変更対象のキーボードキー
  :   ルール2:上記「xxxx」、「yyyy」はスキャンコード(下記)で記述する
  :   ルール3:スキャンコードは4桁0埋めで、リトルエンディアンのためひっくり返して記述する
  :           (例:「Application」はスキャンコードが「E05D」のため                  ひっくり返して「5DE0」と記述する
  :               「Ctrl(左)」   はスキャンコードが「1D」  のため4桁0埋めで「001D」ひっくり返して「1D00」と記述する
  :
  :   ローカルルール:「,」、「-」は後述の処理で削除するため
  :                   「xxxx」と「yyyy」を「,」で区切り、
  :                   複数のキーを入れ替える場合「xxxx,yyyy」を「-」で区切り見やすくする
  :                   →「xxxx,yyyy-xxxx,yyyy」(必須ではない)
  set targetKeyLayout=5DE0,37E0

  : 変更総数
  :  上記「変更対象」にいくつ変更対象があるかを指定する
  :  ルール1:0埋め二桁で記述
  :  ルール2:下記「ターミネーター」を追加するため「変更対象数+1」とする
  :          (例:「ESC」→「NumLock」、「PrintScreen」→「ScrollLock」の場合
  :              2(変更対象数)+1(ターミネーター)で「03」とする
  :  ※二桁は未検証、16進数で記述する必要がある?
  set targetNum=02


: 事前処理
  rem レジストリパス
  set targetKey="HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Keyboard Layout"
  rem ヘッダ(固定値)
  set header=00,00,00,00,00,00,00,00
  rem ターミネーター(固定値)
  set terminator=00,00,00,00

  rem バイナリ連結
  set targetBinary=%header%%targetNum%000000%targetKeyLayout%%terminator%
  rem 「,」を削除
  set targetBinary=%targetBinary:,=%
  rem 「-」を削除
  set targetBinary=%targetBinary:-=%


: 実行
  : 現在設定出力
    : /s:再帰的に検索
    : /v:値名を指定
    reg query %targetKey% /s>CURRENT_REG_PRE.txt

  : 削除
    : reg delete %targetKey% /v "Scancode Map" /f

  : 追加
    rem レイアウト変更値追加
    reg add %targetKey% /v "Scancode Map" /t REG_BINARY /d %targetBinary% /f

  : 更新後設定出力
    : /s:再帰的に検索
    : /v:値名を指定
    reg query %targetKey% /s>CURRENT_REG_POST.txt


: メモ
  : スキャンコード
  :   Alt(右)          :E038
  :   Alt(左)          :38
  :   Ctrl(右)         :E01D
  :   Ctrl(左)         :1D
  :   Shift(右)        :36
  :   Shift(左)        :2A
  :   Win(右)          :E05C
  :   Win(左)          :E05B
  :   Application      :E05D
  :   NumLock          :45
  :   PrintScreen      :E037
  :   ScrollLock       :E046
  :   Pause            :E045
  :   CapsLock         :3A
  :   ESC              :01
  :   半角/全角        :29
  :   変換             :79
  :   無変換           :7B
  :   カタカナ/ひらがな:70
  :   Insert           :E052
  :   Delete           :E053
  :   `(~チルダ)       :29
  :   F1               :3B
  :   F2               :3C
  :   F3               :3D
  :   F4               :3E
  :   F5               :3F
  :   F6               :40
  :   F7               :41
  :   F8               :42
  :   F9               :43
  :   F10              :44
  :   F11              :57
  :   F12              :58

pause