@echo off
title %~nx0
echo �e�L�X�g�t�@�C���w�蕶����s�擾
echo;
: �e�L�X�g�t�@�C����ǂݍ����
: �w�蕶���񂪑��݂���s�̂ݏo�͂���


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION
  : �Q�ƃo�b�`
    rem ���l�̂ݔN���������b�~���擾�o�b�`
    set call_GetStrDateTime="..\OwnLib\GetStrDateTime.bat"
    rem ���l�̂ݔN���������b�~���擾�o�b�`�g�p
    call %call_GetStrDateTime%
    set datetime=%return_GetStrDateTime%
    rem ���[�U���̓o�b�`
    set call_UserInput="..\OwnLib\UserInput.bat"


  : ���[�U����
    rem �Ώۃt�@�C��
    call %call_UserInput% �Ώۃt�@�C���w�� TRUE PATH
    set tgtFile=%return_UserInput1%
    echo;

    rem ���ؕ�����J�n�ʒu
    call %call_UserInput% ���ؕ�����J�n�ʒu TRUE NUM
    set startPoint=%return_UserInput1%
    echo;

    rem ������
    call %call_UserInput% ������ TRUE NUM
    set tgtLength=%return_UserInput1%
    echo;

    rem �w�蕶����
    call %call_UserInput% �w�蕶���� TRUE STR
    set tgtStr=%return_UserInput1%


  : �w��t�@�C�����[�v
    set /a counter=1
    for /f "usebackq delims=" %%a in (%tgtFile%) do (
      rem �Ώۈ�s
      set row=%%a
      rem ���ؕ�����擾
      set verifyStr=!row:~%startPoint:"=%,%tgtLength:"=%!

      rem �����񌟏�
      if "!verifyStr!"==%tgtStr% (
        rem �s���ƑΏۍs�o��
        echo !counter!:!row!>>%~nx0_%datetime%.txt
      )
      rem �J�E���^�C���N�������g
      set /a counter=!counter!+1
    )


  :END
    echo;
    echo �o�̓t�@�C��:%~nx0_%datetime%.txt
    pause
    exit