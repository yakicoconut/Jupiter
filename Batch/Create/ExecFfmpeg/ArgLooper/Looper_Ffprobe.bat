@echo off
title %~nx0
echo �R�}���h���[�v_ffprobe
echo;
: ����01:���[�v�J�n���̐��l�̂ݔN���������b�~��
: ����02:���[�v�J�E���^
: ����03:�I�v�V����
: ����04:�Ώۈ���
: �ߒl  :�Ȃ�


SETLOCAL
  : ��������
    rem �˂��ݕԂ�_�������Ȃ��ꍇ
    if "%~1"=="" (
      echo ���{�t�@�C���͒P�̂Ŏ��s���Ȃ��ł�������
      echo �I�����܂�
      pause
      exit
    )

  : ����
    rem �������p��
    set datetime=%~1
    set counter=%~2
    set option=%~3
    set arg=%~4

  : �R�}���h���s
    rem �t�@�C�������o���o��
    echo %counter%:%arg%>>ffprobe_%datetime%.txt

    rem ffprobe���s
    ".\ExecFfmpeg\ffmpeg\win32\ffprobe.exe" %option% %arg%>>ffprobe_%datetime%.txt
    echo;>>ffprobe_%datetime%.txt
    echo;
    echo;

ENDLOCAL
exit /b