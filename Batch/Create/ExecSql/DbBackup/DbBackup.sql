/* �w��DB�o�b�N�A�b�v�X�N���v�g */
/*
 * �w�肵��DB���o�b�N�A�b�v����
 *   BACKUP DATABASE �Ώ�DB TO DISK='�o�b�N�A�b�v��.bak' WITH �I�v�V����
 *     �o�b�N�A�b�v��.bak
 *       ���΃p�X�Ŏw�肷��ꍇ�A�u�C���X�g�[���t�H���_\MSSQL10_50.SQL2008R2FORGEM\MSSQL\Backup�v�ɏo�͂����
 *     �I�v�V����
 *       SQLserver�� �o�b�N�A�b�v�͕��a�ȂƂ��ɂ��܂��傤�I�i���S�o�b�N�A�b�v�j ? �������ȂԂ낮
 *       	https://you-1.tokyo/sqlserver_backup/
 *       ��؂蕶��   :�����w��̏ꍇ�A�u,�v�ŋ�؂�
 *       INIT         :�㏑��
 *       NOINIT       :�����̃o�b�N�A�b�v �Z�b�g�ɒǉ�
 *       COMPRESSION  :���k�AExpress�ł̏ꍇ�͎g�p�ł��Ȃ�
 *       SRARUS = ���l:���s�󋵕\���A���l:�\������
 */


-- ���s
PRINT '��TempDB �� TempDb01.bak'
BACKUP DATABASE GemDB TO DISK='E:\empDb01.bak' WITH INIT, STATS = 10

PRINT ''
PRINT '��TempDB �� TempDb02.bak'
BACKUP DATABASE GemDB TO DISK='E:\TempDb02.bak' WITH INIT, STATS = 20