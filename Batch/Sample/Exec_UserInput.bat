@echo off
title %~nx0
echo ���[�U���̓o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\OwnLib\UserInput.bat"


: �p�^�[��1
  echo;
  echo ================================
  echo ��������͗�1_��������
  echo   �ݒ�
  echo     �\������      :�C��
  echo     �������̓��[�v:�L��
  echo     ���f���[�h    :�f�t�H���g(������)
  echo   ���Ҍ���
  echo     ������  �˓��̓��[�v
  echo     �C�ӓ��́˖ߒl1:���͕�����
  echo               �ߒl2:1
  echo --------------------------------
  call %call_UserInput% �������̓p�^�[�� TRUE STR
  echo %return_UserInput1%
  echo %return_UserInput2%

: �p�^�[��2
  echo;
  echo ================================
  echo ��������͗�2_�\�������Ȃ�
  echo   �ݒ�
  echo     �\������      :""
  echo     �������̓��[�v:�L��
  echo     ���f���[�h    :�f�t�H���g(������)
  echo   ���Ҍ���
  echo     ������  �˓��̓��[�v
  echo     �C�ӓ��́˖ߒl1:���͕�����
  echo               �ߒl2:1
  echo --------------------------------
  call %call_UserInput% "" TRUE STR
  echo %return_UserInput1%
  echo %return_UserInput2%

: �p�^�[��3
  echo;
  echo ================================
  echo ��������͗�3_�������� - �������̓��[�v����
  echo   �ݒ�
  echo     �\������      :�C��
  echo     �������̓��[�v:����
  echo     ���f���[�h    :�f�t�H���g(������)
  echo   ���Ҍ���
  echo     ������  �˖ߒl1:�󕶎�
  echo               �ߒl2:0
  echo     �C�ӓ��́˖ߒl1:���͕�����
  echo               �ߒl2:1
  echo --------------------------------
  call %call_UserInput% "�������� - �������̓��[�v�����p�^�[��" FALSE STR
  echo %return_UserInput1%
  echo %return_UserInput2%

: �p�^�[��4
  echo;
  echo ================================
  echo �p�X���͗�1_�p�X����
  echo   �ݒ�
  echo     �\������      :�C��
  echo     �������̓��[�v:�L��
  echo     ���f���[�h    :�p�X
  echo   ���Ҍ���
  echo     �������́˓��̓��[�v
  echo     �L�����́˖ߒl1:���͕�����
  echo               �ߒl2:1
  echo --------------------------------
  call %call_UserInput% �p�X���̓p�^�[�� TRUE PATH
  echo %return_UserInput1%
  echo %return_UserInput2%

: �p�^�[��5
  echo;
  echo ================================
  echo �p�X���͗�2_�p�X���� - �������̓��[�v����
  echo   �ݒ�
  echo     �\������      :�C��
  echo     �������̓��[�v:����
  echo     ���f���[�h    :�p�X
  echo   ���Ҍ���
  echo     �������́˖ߒl1:���͕�����
  echo               �ߒl2:0
  echo     �L�����́˖ߒl1:���͕�����
  echo               �ߒl2:1
  echo --------------------------------
  call %call_UserInput% "�p�X���� - �������̓��[�v�����p�^�[��" FALSE PATH
  echo %return_UserInput1%
  echo %return_UserInput2%

: �p�^�[��6
  echo;
  echo ================================
  echo ���l���͗�1_���l����
  echo   �ݒ�
  echo     �\������      :�C��
  echo     �������̓��[�v:�L��
  echo     ���f���[�h    :���l
  echo   ���Ҍ���
  echo     �������́˓��̓��[�v
  echo     �L�����́˖ߒl1:���͕�����
  echo               �ߒl2:1
  echo --------------------------------
  call %call_UserInput% ���l���̓p�^�[�� TRUE NUM
  echo %return_UserInput1%
  echo %return_UserInput2%

: �p�^�[��7
  echo;
  echo ================================
  echo ���l���͗�2_���l���� - �������̓��[�v����
  echo   �ݒ�
  echo     �\������      :�C��
  echo     �������̓��[�v:����
  echo     ���f���[�h    :���l
  echo   ���Ҍ���
  echo     �������́˖ߒl1:���͕�����
  echo               �ߒl2:0
  echo     �L�����́˖ߒl1:���͕�����
  echo               �ߒl2:1
  echo --------------------------------
  call %call_UserInput% "���l���� - �������̓��[�v�����p�^�[��" FALSE NUM
  echo %return_UserInput1%
  echo %return_UserInput2%

: �p�^�[��8
  echo;
  echo ================================
  echo ���t���͗�1_���t����
  echo   �ݒ�
  echo     �\������      :�C��
  echo     �������̓��[�v:�L��
  echo     ���f���[�h    :���t
  echo   ���Ҍ���
  echo     �������́˓��̓��[�v
  echo     �L�����́˖ߒl1:���͕�����
  echo               �ߒl2:�L���p�^�[��(yyyy/mm/dd�Ayy/mm/dd�Amm/dd)
  echo --------------------------------
  call %call_UserInput% ���t���̓p�^�[�� TRUE DATE
  echo %return_UserInput1%
  echo %return_UserInput2%

: �p�^�[��9
  echo;
  echo ================================
  echo ���t���͗�2_���t���� - �������̓��[�v����
  echo   �ݒ�
  echo     �\������      :�C��
  echo     �������̓��[�v:����
  echo     ���f���[�h    :���t
  echo   ���Ҍ���
  echo     �������́˖ߒl1:���͕�����
  echo               �ߒl2:0
  echo     �L�����́˖ߒl1:���͕�����
  echo               �ߒl2:�L���p�^�[��(yyyy/mm/dd�Ayy/mm/dd�Amm/dd)
  echo --------------------------------
  call %call_UserInput% "���t���� - �������̓��[�v�����p�^�[��" FALSE DATE
  echo %return_UserInput1%
  echo %return_UserInput2%

: �p�^�[��10
  echo;
  echo ================================
  echo �������͗�1_��������
  echo   �ݒ�
  echo     �\������      :�C��
  echo     �������̓��[�v:�L��
  echo     ���f���[�h    :����
  echo   ���Ҍ���
  echo     �������́˓��̓��[�v
  echo     �L�����́˖ߒl1:���͕�����
  echo               �ߒl2:�L���p�^�[��(mm:ss�Ah:mm:ss�Ahh:mm:ss�Ahh:mm:ss.ff)
  echo --------------------------------
  call %call_UserInput% �������̓p�^�[�� TRUE TIME
  echo %return_UserInput1%
  echo %return_UserInput2%

: �p�^�[��11
  echo;
  echo ================================
  echo �������͗�2_�������� - �������̓��[�v����
  echo   �ݒ�
  echo     �\������      :�C��
  echo     �������̓��[�v:����
  echo     ���f���[�h    :����
  echo   ���Ҍ���
  echo     �������́˖ߒl1:���͕�����
  echo               �ߒl2:0
  echo     �L�����́˖ߒl1:���͕�����
  echo               �ߒl2:�L���p�^�[��(mm:ss�Ah:mm:ss�Ahh:mm:ss�Ahh:mm:ss.ff)
  echo --------------------------------
  call %call_UserInput% "�������� - �������̓��[�v�����p�^�[��" FALSE TIME
  echo %return_UserInput1%
  echo %return_UserInput2%

pause