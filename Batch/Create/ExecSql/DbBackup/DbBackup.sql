/* 指定DBバックアップスクリプト */
/*
 * 指定したDBをバックアップする
 */


-- 実行
BACKUP DATABASE TempDb01 TO DISK='E:\TempDb01.BAK' WITH INIT
BACKUP DATABASE TempDb02 TO DISK='E:\TempDb02.BAK' WITH INIT