@echo off
title %~nx0
rem ���l����o�b�`
rem ����01:�Ώےl
rem �ߒl:���茋��(0:���l�łȂ��A1:���l)


rem �ϐ����[�J����
SETLOCAL
  : ����
    rem �Ώےl
    set value=%1


  : ���s
    rem ���l�t���O
    set isNumeric=0

    rem �Ώےl���[�v
      : �P�̂������͘A���������l�ŕ����������2��ϐ��Ɋi�[
      : (��1:abc9def  ���uabc�v�A�udef�v
      : (��2:ghi123jkl���ughi�v�A�ujkl�v
    for /F "tokens=1,2 delims=0123456789" %%i in ("%value%") do (
      set hoge=%%i
      set fuga=%%j
    )

    rem 1�ڂ���̏ꍇ
    if "%hoge%"=="" (
      rem ���l�Ɣ��f
      set isNumeric=1
    )

    rem 1�ڂ��u.�v����2�ڂ���̏ꍇ
    if "%hoge%"=="." (
      if "%fuga%"=="" (
        rem ���������l�Ɣ��f
        set isNumeric=1
      )
    )


rem �߂�l
ENDLOCAL && set return_ChkNum=%isNumeric%
exit /b