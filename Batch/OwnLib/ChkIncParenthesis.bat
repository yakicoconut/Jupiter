@echo off
title %~nx0
rem �ۊ��ʊܗL����o�b�`
rem ����01:�Ώےl
rem �ߒl  :���茋��(0:�ۊ��ʂ��܂܂�Ȃ��A1:�܂܂��)


rem �ϐ����[�J����
SETLOCAL
  : ����
    rem �Ώےl
    set value=%1


  : ���s
    rem ���茋��
    set isInclude=0

    rem �G���[���x��������(����R�}���h���s)
    cd >NUL

    rem �ۊ��ʂ����݂��邩�ǂ���
    echo %value% | find "(" >NUL
    rem �G���[���x������T�u���[�`���g�p
    call :CHK_ERR_LEVEL
    echo %value% | find ")" >NUL
    call :CHK_ERR_LEVEL


rem �߂�l
ENDLOCAL && set return_ChkIncParenthesis=%isInclude%
exit /b


rem �G���[���x������T�u���[�`��
:CHK_ERR_LEVEL
  rem 0:���݂���A1:���݂��Ȃ�
  if %ERRORLEVEL%==0 (
    set isInclude=1
  )
exit /b