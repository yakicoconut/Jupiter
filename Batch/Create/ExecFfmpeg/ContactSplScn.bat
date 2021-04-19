@echo off
title %~nx0
echo ffmpeg�œ��敪��
: ffmpeg�œ�����^�C���z�u���� - Akionux-wiki
: 	http://ja.akionux.net/wiki/index.php/ffmpeg%E3%81%A7%E5%8B%95%E7%94%BB%E3%82%92%E3%82%BF%E3%82%A4%E3%83%AB%E9%85%8D%E7%BD%AE%E3%81%99%E3%82%8B
: ffmpeg �Ŏg����f���̃e�X�g�\�[�X | �j�R���{
: 	https://nico-lab.net/testsrc_with_ffmpeg/
: �f���Ɖ����� pts ������ setpts, asetpts | �j�R���{
: 	https://nico-lab.net/setpts_asetpts_with_ffmpeg/


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: �����`�F�b�N
  rem 10�ȍ~�̈����擾
  set arg08=%8
  set arg09=%9
  shift /8
  shift /8
  set arg10=%8
  set arg11=%9

  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% 11 "PATH PATH STR STR STR STR STR STR NUM NUM STR" %1 %2 %3 %4 %5 %6 %7 %arg08% %arg09% %arg10% %arg11%
  rem �������Ȃ��ꍇ�A���[�U���͂�
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType2%==0 goto :EOF

  rem �������p��
  set  srcPath=%1
  set contPath=%2
  set baseSize=%3
  set  v0Scale=%4
  set  v0Point=%5
  set  v1Scale=%6
  set  v1Point=%7
  set    codec=%arg08%
  set     rate=%arg09%
  set      tbn=%arg10%
  set  outPath=%arg11%

  rem �{������
  goto :RUN


rem ���[�U���͏���
:USER_INPUT
  : ����1�t�@�C���p�X
    echo;
    echo ����1�p�X����
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% ������2�����Đ����Ԃ��傫�����̂��w�� TRUE PATH
    rem ���͒l���p��
    set srcPath=%return_UserInput1%

  : ����2�t�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% ����2�p�X���� TRUE PATH
    rem ���͒l���p��
    set contPath=%return_UserInput1%

  : ����ʃT�C�Y
    echo;
    rem �o�b�`���Łu()�v���g�p�ł��Ȃ����߂����ŕ\��
    echo �x�[�X�T�C�Y����(�cx��)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" FALSE STR
    rem ���͒l���p��
    set baseSize=%return_UserInput1%

  : ����1�X�P�[����
    echo;
    rem �o�b�`���Łu()�v���g�p�ł��Ȃ����߂����ŕ\��
    echo ����1�X�P�[�������(�c:��)
    echo ���ǂ��炩���u-1�v�ݒ�Ƃ���Ǝ����v�Z�ƂȂ�
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" FALSE STR
    rem ���͒l���p��
    set v0Scale=%return_UserInput1%

  : ����1�z�u�ʒu
    echo;
    echo ����1�z�u�ʒu(x=���l:y=���l)����
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" FALSE STR
    rem ���͒l���p��
    set v0Point=%return_UserInput1%

  : ����2�X�P�[����
    echo;
    rem �o�b�`���Łu()�v���g�p�ł��Ȃ����߂����ŕ\��
    echo ����2�X�P�[�������(�c:��)
    echo ���ǂ��炩���u-1�v�ݒ�Ƃ���Ǝ����v�Z�ƂȂ�
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" FALSE STR
    rem ���͒l���p��
    set v1Scale=%return_UserInput1%

  : ����2�z�u�ʒu
    echo;
    echo ����2�z�u�ʒu(x=���l:y=���l)����
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" FALSE STR
    rem ���͒l���p��
    set v1Point=%return_UserInput1%

  : �R�[�f�b�N
    echo;
    echo �R�[�f�b�N����(-c:v ����Codec -c:a ����Codec)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" FALSE STR
    rem ���͒l���p��
    set codec=%return_UserInput1:"=%

  : 1�b�����艽��
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% 1�b�����薇������ TRUE NUM
    rem ���͒l���p��
    set rate=%return_UserInput1%

  : tbn����
    echo;
    echo tbn����(���l)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE NUM
    rem ���͒l���p��
    set tbn=%return_UserInput1%

  : �o�̓t�@�C����
    echo;
    echo �o�̓t�@�C��������(�v�g���q)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE STR
    rem ���͒l���p��
    set outPath=%return_UserInput1%


rem �{����
:RUN
  : ���s
    rem ���O�t�H���_�쐬
    if not exist %~dp0Log ( mkdir %~dp0Log )
    rem �t�@�C�����Ń��O�t�@�C���p�X�ݒ�
    set logPath=%~dp0Log\%~n0.log
    rem ���s�O���O�o��
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem �������s
      : -y      :�㏑��
      : -i      :�Ώۃt�@�C��
      :          �����w��̏ꍇ�A�u-i�v�I�v�V�������ƋL�q����
      : -filter~:[���͏��]�I�v�V����[��`��]
      :            ���̓t�@�C���ɓK�p����I�v�V������
      :            ��`���Ɋi�[���A�g�p�\
      :          ���ڍׂ́uImgCompo.bat�v�Q��
      :          (������:
      :            nullsrc=size=�T�C�Y(�cx��) [��`��];
      :              nullsrc=
      :                �J���[�\�[�X
      :                ���ɂ��upal75bars�v�A�urgbtestsrc�v���A�g�p�\
      :              size=�T�C�Y(�cx��)
      :                �J���[�\�[�X�̃T�C�Y�w��
      :              [��`��]
      :                �C�ӂ̒�`��
      :              ���
      :                ����\��t���̊��ƂȂ�摜���쐬
      :            [i:v] setpts=�I�v�V����, scale=�X�P�[����(�c:��) [��`��];
      :              [i:v]
      :                 ��i:0�n�܂�̐��l
      :                �u-i�v�I�v�V�����Ŏw�肵������
      :              setpts=�I�v�V����,
      :                �Đ����x��X�^�[�g�ʒu�̃I�v�V����
      :                PTS-STARTPTS
      :                  ���͂����f����pts���w�肷��
      :              scale=�X�P�[����(�c:��)
      :                �\��t������T�C�Y��
      :              ���
      :                �Ώۂ̓�����T�C�Y�w�肵�āA�J�n�ʒu���̂܂܂Œ�`
      :            [����`��][�Ώے�`��] overlay=�I�v�V���� [��`��];
      :              [����`��]
      :                �\��t�����ƂȂ��`��
      :              [�Ώے�`��]
      :                �\��t���Ώۓ���̒�`��
      :              overlay=�I�v�V����
      :                �I�[�o���C�p�I�v�V����
      :                shortest=�l
      :                  0:�I�t�A1:�I��
      :                  ���ƑΏۂ̓��A����Đ����Ԃ��Z�����̏I���ɍ��킹��
      :                ����z�u�ʒu(x=���l:y=���l)
      :                  ����̔z�u�ʒu
      :              ���
      :                ���
      :                  �E�unullsrc=�`�v�Ŏw�肵�����摜��`���ubase�v�ɑ΂���
      :                    ����1�̒�`���uone�v���g�p���A�uout1�v�Ƃ���
      :                  �E���摜�͍Đ����Ԃ��Ȃ�����?�ushortest�v�I�v�V�����̃I�����K�{?
      :                  ��[base][one] �� [out1]
      :                ���
      :                  �E��L��ڂ́uout1�v�ɑ΂��ē���2�̒�`���utwo�v���g�p�A
      :                    �Ō�̓���̂��ߒ�`���͒�`���Ȃ�
      :                  �E����1������2�����������Ƃ�O��Ɂushortest�v�I�v�V�����̎w��͂Ȃ�
      :                  ��[out0][two] ��
      : -c:v    :����R�[�f�b�N
      : -c:a    :�����R�[�f�b�N
      : -r      :�t���[�����[�g
      : -video~ :tbn�ݒ�
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -i %contPath% -filter_complex "nullsrc=size=%baseSize% [base]; [0:v] setpts=PTS-STARTPTS, scale=%v0Scale% [one]; [1:v] setpts=PTS-STARTPTS, scale=%v1Scale% [two]; [base][one] overlay=shortest=1:%v0Point% [out0]; [out0][two] overlay=%v1Point%" -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ���O�o��
  rem �u=�v�����݂���ϐ��̓��_�C���N�g��
  rem �o���Ȃ����߃X�y�[�X��t�^
  echo %srcPath:"=%>>%logPath%
  echo %contPath:"=%>>%logPath%
  echo %baseSize:"=%>>%logPath%
  echo %v0Scale:"=%>>%logPath%
  echo %v0Point%>>%logPath%
  echo %v1Scale:"=%>>%logPath%
  echo %v1Point%>>%logPath%
  echo %codec:"=%>>%logPath%
  echo %rate:"=%>>%logPath%
  echo %tbn:"=%>>%logPath%
  echo %outPath:"=%>>%logPath%
  echo;>>%logPath%
  echo %date% %time%>>%logPath%
  echo;>>%logPath%
  echo;>>%logPath%

  rem �������Ȃ�(���[�U���͂Ŏ��s����)�ꍇ�A�|�[�Y
  if %argc%==0 pause

exit /b