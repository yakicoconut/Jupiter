/* �e�[�u���f�[�^�m�F�p�X�N���v�g */
/*
 * �uPOS-VersionUp_ServerSqlDiffList.bat�v������s����
 */

/* �ݒ� */
-- �un����������܂����B�v�̔�\���ݒ�
set nocount on


/* �f�[�^�擾 */
-- PaymentServiceMaster
SELECT 'PaymentServiceMaster'
SELECT *
FROM   PaymentServiceMaster
WHERE  CATCode            = 'g-pfm10' AND
       PaymentServiceCode = '06'


-- SystemParameter_JMB�|�C���g�C�V���AID
SELECT 'SystemParameter_JMB�|�C���g�C�V���AID'
SELECT *
FROM   SystemParameter
WHERE  ParameterCode = 'WaonJmbPointIssuerId'


-- #28082:�y�d�l�ύX�z�yPOS�z�y���ϒ[���A��(PFM-10)�z��ʌn�VUI�K�C�h���C���Ή�
SELECT '#28082:�y�d�l�ύX�z�yPOS�z�y���ϒ[���A��(PFM-10)�z��ʌn�VUI�K�C�h���C���Ή�'
SELECT *
FROM   PaymentServiceReceiptLayoutMaster
WHERE  CATCode            = 'g-pfm10' AND
       PaymentServiceCode = '07'      AND
       ColumnID           = 'Balance'


-- #28121:�y���ϒ[���A��(PFM-10)�zWAON���ςł̎��������ɓd�q�}�l�[�T�����V�[�g���o�͂���Ȃ�
SELECT '#28121:�y���ϒ[���A��(PFM-10)�zWAON���ςł̎��������ɓd�q�}�l�[�T�����V�[�g���o�͂���Ȃ�'
SELECT *
FROM   PaymentServiceReceiptLayoutMaster
WHERE  CATCode            = 'g-pfm10' AND
       PaymentServiceCode = '06'

/*
 * �E�Ώۃe�[�u���������o���Ƃ��ĕ\������ꍇ�́uSELECT ���o���v���g�p����
 */
