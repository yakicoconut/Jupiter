/* 指定DBバックアップスクリプト */
/*
 * 指定したDBをバックアップする
 *   BACKUP DATABASE 対象DB TO DISK='バックアップ先.bak' WITH オプション
 *     バックアップ先.bak
 *       相対パスで指定する場合、「インストールフォルダ\MSSQL10_50.SQL2008R2FORGEM\MSSQL\Backup」に出力される
 *     オプション
 *       SQLserverの バックアップは平和なときにやりましょう！（完全バックアップ） ? ざったなぶろぐ
 *       	https://you-1.tokyo/sqlserver_backup/
 *       区切り文字   :複数指定の場合、「,」で区切る
 *       INIT         :上書き
 *       NOINIT       :既存のバックアップ セットに追加
 *       COMPRESSION  :圧縮、Express版の場合は使用できない
 *       SRARUS = 数値:実行状況表示、数値:表示割合
 */


-- 実行
PRINT '■TempDB → TempDb01.bak'
BACKUP DATABASE GemDB TO DISK='E:\empDb01.bak' WITH INIT, STATS = 10

PRINT ''
PRINT '■TempDB → TempDb02.bak'
BACKUP DATABASE GemDB TO DISK='E:\TempDb02.bak' WITH INIT, STATS = 20