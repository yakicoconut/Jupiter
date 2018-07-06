/* テーブルデータ確認用スクリプト */
/*
 * 「POS-VersionUp_ServerSqlDiffList.bat」から実行する
 */

/* 設定 */
-- 「n件処理されました。」の非表示設定
set nocount on


/* データ取得 */
-- PaymentServiceMaster
SELECT 'PaymentServiceMaster'
SELECT *
FROM   PaymentServiceMaster
WHERE  CATCode            = 'g-pfm10' AND
       PaymentServiceCode = '06'


-- SystemParameter_JMBポイントイシュアID
SELECT 'SystemParameter_JMBポイントイシュアID'
SELECT *
FROM   SystemParameter
WHERE  ParameterCode = 'WaonJmbPointIssuerId'


-- #28082:【仕様変更】【POS】【決済端末連動(PFM-10)】交通系新UIガイドライン対応
SELECT '#28082:【仕様変更】【POS】【決済端末連動(PFM-10)】交通系新UIガイドライン対応'
SELECT *
FROM   PaymentServiceReceiptLayoutMaster
WHERE  CATCode            = 'g-pfm10' AND
       PaymentServiceCode = '07'      AND
       ColumnID           = 'Balance'


-- #28121:【決済端末連動(PFM-10)】WAON決済での取引完了後に電子マネー控えレシートが出力されない
SELECT '#28121:【決済端末連動(PFM-10)】WAON決済での取引完了後に電子マネー控えレシートが出力されない'
SELECT *
FROM   PaymentServiceReceiptLayoutMaster
WHERE  CATCode            = 'g-pfm10' AND
       PaymentServiceCode = '06'

/*
 * ・対象テーブル等を見出しとして表示する場合は「SELECT 見出し」を使用する
 */
