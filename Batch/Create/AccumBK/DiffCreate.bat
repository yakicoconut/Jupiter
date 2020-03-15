@echo off
title %~nx0
echo �o�b�N�A�b�v�̍������쐬����


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION


: �Q�ƃo�b�`
  rem �폜�o�b�`(�R�s�[���s�������Ŏg�p�͂��Ȃ�)
  set call_DiffExtra_DelFiles="DelFiles.bat"
  rem �R�s�[��̍폜�o�b�`��啶���ɂ��邽�߂̕ϐ�
  set reName_DiffExtra_DelFiles="DELFILES.bat"


: �ϐ�
  rem ���ʎq
  set identifier=Pla

  rem ��f�B���N�g��
  set targetDir01="BackUp_Main"
  set targetDir02="BackUp_Main_DiffSource"
  set targetDir03="BackUp_DiffCheck"
  rem �������t�@�C��
  set targetFile=DIFFFILES.txt


: ���O����
  rem ��f�B���N�g���́u"�v���폜
  set targetDir01=%targetDir01:"=%
  set targetDir02=%targetDir02:"=%
  set targetDir03=%targetDir03:"=%

  rem ���g�̃t�H���_�p�X�擾
  set currentDir=%~dp0

  rem ���s���������t�@�C����
  set process07=�����쐬����01

  rem �{�o�b�`���P�̂Ŏg�p���ꂽ�ꍇ�͌��ݎ������擾����
  if "%dateTime01%"=="" (
    rem ���ݓ����̎擾
    set dateTime01=!date:/=!!time: =0!
    set dateTime01=!dateTime01::=!
    set dateTime01=!dateTime01:.=!
    set dateTime01=!dateTime01:~0,17!
  )


: �����쐬
  rem ���s���������t�@�C���o��
  echo ������>%process07%

  rem �˂��ݕԂ�_�������t�@�C�����Ȃ��ꍇ
  if not exist %targetFile% (
    echo;
    echo %targetFile%�t�@�C��������܂���
    echo �I�����܂�
    pause

    rem ���s���������t�@�C���폜
    del %process07%
    exit
  )

  echo;
  echo �������o�J�n

  rem �������o�t�H���_�쐬
  rem �ϐ�IDENTIFIER�͏�L�ŌĂяo�����o�b�`�����Œ�`�����
  set diffDir=BackUp_%identifier%_%dateTime01%
  mkdir %diffDir%

  rem �u/f "delims="�v�ŋ�؂蕶�����w��
  rem �u=�v��ɕ����w�肪�Ȃ��̂ŉ��s����؂�ƂȂ�
  for /f "delims=" %%a in (%targetFile%) do (
    rem �u"tokens="�v�Ŏw��C���f�b�N�X�����o��
    for /f "tokens=1,2 delims=	" %%b in ("%%a") do (
      rem ���O����
      rem �X�y�[�X����
      set preFix=%%b
      set preFix=!preFix: =!
      rem �ϐ�������
      set delTarget=""
      set upTarget=""

      rem �˂��ݕԂ�_�ΏۊO
      if "!preFix!"=="" (
        echo �ΏۊO
        rem ���̃��[�v��
      ) else (

        rem �폜�t�@�C���̏ꍇ�A�폜�t�H���_�̃p�X���폜
        set delTarget=%%c
        set delTarget=!delTarget:%currentDir%%targetDir02%=!
        set delTarget=!delTarget:%currentDir%%targetDir03%=!

        rem �폜�t�@�C��
        if !preFix!==*EXTRAFile (
          echo �폜�t�@�C��
          echo !delTarget!>>DELTARGET.txt
        ) else (

          rem �폜�t�H���_
          if !preFix!==*EXTRADir (
            echo �폜�t�H���_
            echo !delTarget!>>DELTARGET.txt
          ) else (

            rem �폜�t�@�C���łȂ��ꍇ�A���t�H���_�̃p�X���폜
            set upTarget=%%c
            set upTarget=!upTarget:%currentDir%%targetDir01:"=%=!

            rem �X�V�t�@�C��
            if !preFix!==���V���� (
              echo �X�V�t�@�C��
              echo f | xcopy "%targetDir01%!upTarget!" "%diffDir%!upTarget!" /y /h
            ) else (

              rem �X�V�t�@�C��
              if !preFix!==�V���� (
                echo �X�V�t�@�C��
                echo f | xcopy "%targetDir01%!upTarget!" "%diffDir%!upTarget!" /y /h
              ) else (

                rem �쐬�t�H���_
                if !preFix!==�V�����f�B���N�g�� (
                  echo �쐬�t�H���_
                  rem xcopy�ł�2�K�w�ȏ�̐V�K�t�H���_���쐬�ł��Ȃ�����mkdir���g�p
                  mkdir "%diffDir%!upTarget!"
                ) else (

                  rem �쐬�t�@�C��
                  if !preFix!==�V�����t�@�C�� (
                    echo �쐬�t�@�C��
                    echo f | xcopy "%targetDir01%!upTarget!" "%diffDir%!upTarget!" /y /h
                  )
                )
              )
            )
          )
        )
      )
rem ���[�v���j�^
rem pause
    )
  )

  rem �����Ώۈꗗ���t�H���_�Ɋ܂߂�
  move %targetFile% %diffDir%

  rem �폜�Ώۃt�@�C���ꗗ������ꍇ
  rem �폜�o�b�`�ƍ폜�Ώۃt�@�C���ꗗ���t�H���_�Ɋ܂߂�
  if exist DELTARGET.txt (
    rem �폜�֘A�t�@�C���̈ړ�/�R�s�[
    copy %call_DiffExtra_DelFiles% %diffDir%
    move DELTARGET.txt %diffDir%

    rem �폜�o�b�`��啶���ɕύX����
    ren %diffDir%\%call_DiffExtra_DelFiles% %reName_DiffExtra_DelFiles%
  )

  rem ���s���������t�@�C���폜
  del %process07%


: ���㏈��
  rem �I�������̎擾
  set datetime02=%date:/=%%time: =0%
  set datetime02=%datetime02::=%
  set datetime02=%datetime02:.=%
  set datetime02=%datetime02:~0,17%

  rem �I�������o��
  echo %dateTime01%>>%diffDir%\%dateTime01%
  echo %datetime02%>>%diffDir%\%dateTime01%