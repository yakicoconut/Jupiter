@echo off
title %~nx0
rem �[�������폜�o�b�`
rem ����01:�Ώےl
rem �ߒl  :�폜��l


rem �ϐ����[�J����
SETLOCAL
  : ����
    rem �Ώےl
    set value=%1

  rem �����폜���[�v
  :DEL_ZERO_END
    rem �˂��ݕԂ�_�l���Ȃ��ꍇ(0�݂̂��l��)
    if "%value%"=="" goto :END_BAT
    rem �˂��ݕԂ�_������0�łȂ��ꍇ
    if not %value:~-1,1%==0 goto :END_BAT

    rem �������폜���ĕϐ��Ɋi�[
    set value=%value:~0,-1%
    goto :DEL_ZERO_END

  rem ������
  :END_BAT
    rem �����Ȃ�

rem �߂�l
ENDLOCAL && set return_DelZeroEnd=%value%
exit /b