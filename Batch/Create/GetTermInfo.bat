@echo off
title %~nx0
echo �[���ŗL���擾
: Wevtutil �Ń����[�g�� Windows �}�V���̃C�x���g���O���擾����
: 	https://mseeeen.msen.jp/acquire-event-log-in-remote-machine-with-wevtutil/


: ����
  rem �擾�p�X
  set targetPath001="C:\bin\Log"


: �Q�ƃo�b�`
  rem ���l�̂ݔN���������b�~���擾�o�b�`
  set call_GetStrDateTime="..\OwnLib\GetStrDateTime.bat"


: �錾
  rem ���l�̂ݔN���������b�~���擾�o�b�`�g�p
  call %call_GetStrDateTime%
  set datetime=%return_GetStrDateTime%
  rem �R�����g�p�C���f���g���p�X�y�[�X�~2
  set indent=  


: MsInfo32
  echo;
  echo;
  echo msinfo32�擾

  rem IdentifyingNumber��2�s�ڎ擾
  for /f "tokens=2 usebackq delims=^:" %%i in (`wmic csproduct get IdentifyingNumber ^| findstr /n /r "." ^| findstr /r "^2:"`) do set serialNum=%%i

  rem �V���A���i���o�[�\��
  echo %indent%�V���A���i���o�[:%serialNum%

  rem �g�����T�u���[�`���g�p
  set x=%serialNum%
  call :TRIM %x%
  rem �X�y�[�X�����݂���ꍇ�A�ŏ��̃X�y�[�X�܂ł���
  rem �t�@�C�����ɏo���Ȃ����߁u"�v�ł�����
  set serialNum="%x%"


  : �o�̓t�H���_�쐬
    rem �����ۂɂ͖��Ȃ����\����́u"�v�����
    echo %indent%�o�̓t�H���_�쐬:%~dp0TermInfo_%serialNum:"=%_%datetime%
    md TermInfo_%serialNum%_%datetime%


  rem �t�@�C���o��
  msinfo32 /report TermInfo_%serialNum%_%datetime%\MsInfo32.txt


: EventLog
  echo;
  echo �e�C�x���g���O�o��
  wevtutil epl Application     TermInfo_%serialNum%_%datetime%\EventLog_Application.evtx
  wevtutil epl Security        TermInfo_%serialNum%_%datetime%\EventLog_Security.evtx
  wevtutil epl Setup           TermInfo_%serialNum%_%datetime%\EventLog_Setup.evtx
  wevtutil epl System          TermInfo_%serialNum%_%datetime%\EventLog_System.evtx
  wevtutil epl ForwardedEvents TermInfo_%serialNum%_%datetime%\EventLog_ForwardedEvents.evtx


: CheckDisk
  echo;
  echo �`�F�b�N�f�B�X�N���ʎ擾
  rem �����ۂɂ͐���ɏo�͂���邪�\����G���[�ƂȂ邽�߃V���A���́u"�v�����
  chkdsk>TermInfo_%serialNum:"=%_%datetime%\ChekDisk.txt


: Log001
  echo;
  echo �Ώۃt�H���_�擾

  rem �Ώۃt�H���_�����݂���ꍇ
  if exist %targetPath001% (
    rem �t�H���_�R�s�[
    echo d | xcopy %targetPath001% TermInfo_%serialNum%_%datetime%\Target001 /s
  )


: ������
  echo;
  echo;
  echo ��������
  pause
  exit


rem �g�����T�u���[�`��
:TRIM
  rem ���̃X�y�[�X������
  set x=%*

  exit /b