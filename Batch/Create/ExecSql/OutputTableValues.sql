/*
 * テーブルデータ出力スクリプト
 *   ・バッチファイルから実行する
 *   ・対象テーブル等を見出しとして表示する場合は「SELECT 見出し」を使用する
 */

/* 設定 */
-- 「n件処理されました。」の非表示設定
set nocount on

/* データ取得 */
-- hogeMaster
SELECT 'hogeMaster'
SELECT *
FROM   hogeMaster
WHERE  ABC = 'abc' AND
       DEF = 'def'