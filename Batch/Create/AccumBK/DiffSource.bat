@echo off
title %~nx0
echo �ꊇ�Ńo�b�N�A�b�v�ƍ����̒��o������


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION


: �Q�ƃo�b�`
  rem �����쐬�o�b�`
  set call_DiffExtra_Create="DiffCreate.bat"
  rem �~���[�����O�o�b�`
  set call_DiffExtra_Target="DiffTarget.bat"


: �ϐ�
  rem ��f�B���N�g��
  set targetDir01="BackUp_Main"
  set targetDir02="BackUp_Main_DiffSource"


: ���O����
  rem ���g�̃t�H���_�p�X�擾
  set currentDir=%~dp0

  rem ���ݓ����̎擾
  rem �{�o�b�`�ł͎g�p���Ȃ��������쐬�o�b�`�Ŏg�p����O���[�o���ϐ�
  set dateTime01=%date:/=%%time: =0%
  set dateTime01=%dateTime01::=%
  set dateTime01=%dateTime01:.=%
  set dateTime01=%dateTime01:~0,17%

  rem ���s���������t�@�C����
  set process03=�����擾����01
  set process04=�����擾����02
  set process05=�����擾����03
  set process06=�����擾����04


: ��r��(���t�@�C���Q)�t�H���_�̍쐬
  rem ���s���������t�@�C���o��
  echo ������>%process03%

  rem ���C���t�H���_���r���t�H���_�Ƀ~���[�����O
  robocopy "%targetDir01%"  "%targetDir02%" /mir /log:"Log\log_diff01.log" /v
       echo %targetDir01% �� %targetDir02% �R�s�[����

  rem ���s���������t�@�C���폜
  del %process03%


: ��r��(�V�t�@�C���Q)�t�H���_�̍쐬
  rem ���s���������t�@�C���o��
  echo ������>%process04%

  rem �~���[�����O�o�b�`�̌Ăяo��
  call %call_DiffExtra_Target%

  rem ���s���������t�@�C���폜
  del %process04%


: ������񒊏o
  rem ���s���������t�@�C���o��
  echo ������>%process05%

  rem �����t�@�C�����擾
  rem /l:���O�̂݁A/njh:�w�b�_�����A/njs:�t�b�_�����A/ns:�T�C�Y�����A/fp:���S�p�X
  robocopy "%targetDir01%" "%targetDir02%" /mir /l /njh /njs /ns /fp>DIFFFILES.txt

  rem ���s���������t�@�C���폜
  del %process05%


:�����쐬
  rem ���s���������t�@�C���o��
  echo ������>%process06%

  rem �����쐬�o�b�`�̌Ăяo��
  call %call_DiffExtra_Create%

  rem ���s���������t�@�C���폜
  del %process06%