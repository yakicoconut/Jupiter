@echo off
title %~nx0
echo �ݐύ����o�b�N�A�b�v�̘R����`�F�b�N����


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION


: ���O
  rem ��f�B���N�g��
  set targetDir01=BackUp_Main
  set targetDir02=BackUp_DiffCheck
  rem �˂��ݕԂ�_�Ώۂ����݂��Ȃ��ꍇ
  if not exist %targetDir01% (
    echo;
    echo %targetDir01%�t�H���_�����݂��܂���
    echo �I�����܂�
    pause
    exit
  )
  if not exist %targetDir02% (
    echo;
    echo %targetDir02%�t�H���_�����݂��܂���
    echo �I�����܂�
    pause
    exit
  )

: ���O����
  rem ���ݓ����̎擾
  set datetime=%date:/=%%time: =0%
  set datetime=%datetime::=%
  set datetime=%datetime:.=%
  set datetime=%datetime:~0,17%

  rem �������t�@�C����
  set diffCheckFile=DIFFFILES_%datetime%.txt


: ��r����
  rem �����t�@�C�����擾
  rem /l:���O�̂݁A/njh:�w�b�_�����A/njs:�t�b�_�����A/ns:�T�C�Y�����A/fp:���S�p�X
  robocopy "%targetDir01%" "%targetDir02%" /mir /l /njh /njs /ns /fp>%diffCheckFile%


: �����`�F�b�N
  rem �u/f "delims="�v�ŋ�؂蕶�����w��
  rem �u=�v��ɕ����w�肪�Ȃ��̂ŉ��s����؂�ƂȂ�
  for /f "delims=" %%a in (%diffCheckFile%) do (
    rem �u"tokens="�v�Ŏw��C���f�b�N�X�����o��
    for /f "tokens=1,2 delims=	" %%b in ("%%a") do (
      rem ���O����
      rem �X�y�[�X����
      set prefix=%%b
      set prefix=!prefix: =!
      rem �ϐ�������
      set delTarget=""
      set upTarget=""

      rem �˂��ݕԂ�_�ΏۊO
      if "!prefix!"=="" (
        rem ���̃��[�v��
      ) else (

        rem �폜�t�@�C���̏ꍇ�A�폜�t�H���_�̃p�X���폜
        set delTarget=%%c
        set delTarget=!delTarget:%myDir%%targetDir02%=!

        rem �폜�t�@�C��
        if !prefix!==*EXTRAFile (
          echo;
          echo �`�F�b�N�t�H���_�Ƃ̊Ԃɍ��ق�����܂�
          echo %diffCheckFile%���m�F���Ă�������
          pause
          exit
        ) else (

          rem �폜�t�H���_
          if !prefix!==*EXTRADir (
            echo;
            echo �`�F�b�N�t�H���_�Ƃ̊Ԃɍ��ق�����܂�
            echo %diffCheckFile%���m�F���Ă�������
            pause
            exit
          ) else (

            rem �폜�t�@�C���łȂ��ꍇ�A���t�H���_�̃p�X���폜
            set upTarget=%%c
            set upTarget=!upTarget:%myDir%%targetDir01:"=%=!

            rem �X�V�t�@�C��
            if !prefix!==���V���� (
              echo;
              echo �`�F�b�N�t�H���_�Ƃ̊Ԃɍ��ق�����܂�
              echo %diffCheckFile%���m�F���Ă�������
              pause
              exit
            ) else (

              rem �쐬�t�H���_
              if !prefix!==�V�����f�B���N�g�� (
                echo;
                echo �`�F�b�N�t�H���_�Ƃ̊Ԃɍ��ق�����܂�
                echo %diffCheckFile%���m�F���Ă�������
                pause
                exit
              ) else (

                rem �쐬�t�@�C��
                if !prefix!==�V�����t�@�C�� (
                  echo;
                  echo �`�F�b�N�t�H���_�Ƃ̊Ԃɍ��ق�����܂�
                  echo %diffCheckFile%���m�F���Ă�������
                  pause
                  exit
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

echo;
echo �`�F�b�N����
pause


: ���㏈��
  del %diffCheckFile%