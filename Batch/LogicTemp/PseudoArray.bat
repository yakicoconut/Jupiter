@echo off
title %~nx0
echo �[���z��
echo �R�}���h�v�����v�g�ɔz��̎d�l���Ȃ�����
echo �ϐ����𓮓I�ɕύX���[���z�����������
echo;


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION
  : �[���z��쐬
    rem �ϐ��J�E���g�^������
    set /a counter=0

    rem ���I�ϐ��쐬���[�v
    rem set�R�}���h���̕ϐ����ɓ��I�Ȑ��l��t������
    for /f "delims=" %%a in ('dir') do (
      rem �J�E���^�𑝂₷
      set /a counter+=1

      rem �t�@�C������擾�����s�𓮓I�ϐ��ɑ��
      set var_!counter!=%%a
    )

    rem �J�E���^�̍ő�l���擾
    set /a totalCounter=%counter%

    rem �[���z�񏇎��o���T�u���[�`��
    set /a getCounter=0
    call :GET_ARRAY_ASC

    echo;
    echo -----------------------------------------------
    echo;

    rem �[���z��t���o���T�u���[�`��
    call :GET_ARRAY_DESC

    goto END


   rem �[���z�񏇎��o���T�u���[�`��
   :GET_ARRAY_ASC
     rem �˂��ݕԂ�_�J�E���^���}�b�N�X�Ȃ�I��
     if %getCounter% == %totalCounter%  exit /b

     rem �J�E���^�C���N�������g
     set /a getCounter+=1

     rem �\��
     echo !var_%getCounter%!
     echo ���� %getCounter%/%totalCounter%

     goto GET_ARRAY_ASC


  rem �[���z��t���o���T�u���[�`��
  :GET_ARRAY_DESC
    rem �˂��ݕԂ�_�J�E���^��0�Ȃ�I��
    if %counter%==0 exit /b

    echo !var_%counter%!
    echo �c�� !counter!/!totalCounter!

    rem �J�E���^�����炷
    set /a counter-=1

    goto GET_ARRAY_DESC
    pause


  :END
    echo;
    pause