@echo off
title %~nx0
rem �����v�Z�o�b�`
rem ����01:����
rem ����02:�E��
rem �ߒl01:�v�Z����


rem �ϐ����[�J����
SETLOCAL ENABLEDELAYEDEXPANSION
  : �Q�ƃo�b�`
    rem �����_��؂�o�b�`
    set call_SepDecimal=%~dp0"..\OwnLib\SepDecimal.bat"
    rem �����擾�o�b�`
    set call_GetLen=%~dp0"..\OwnLib\GetLen.bat"
    rem �[�����߃o�b�`
    set call_ZeroPadding=%~dp0"..\OwnLib\ZeroPadding.bat"

  : ����
    set leftVal=%1
    set rightVal=%2

  : ���O����
    : ����
      rem �����_��؂�o�b�`�g�p
      call %call_SepDecimal% %leftVal%
      set leftInt=%return_SepDecimal01%
      set leftDec=%return_SepDecimal02%
      rem �����_�ȉ����ʂ�0�̏ꍇ�A�֋X��A������1��������
      if %leftDec:~0,1%==0 set /a leftDec=1%leftDec%
      rem �����擾�o�b�`�g�p
      call %call_GetLen% %leftDec%
      set /a leftDecLen=%return_GetLen%
  
    : �E��
      call %call_SepDecimal% %rightVal%
      set rightInt=%return_SepDecimal01%
      set rightDec=%return_SepDecimal02%
      if %rightDec:~0,1%==0 set /a rightDec=1%rightDec%
      call %call_GetLen% %rightDec%
      set /a rightDecLen=%return_GetLen%
  
    : �����v�Z����
      rem �������ϐ������ӂ̌����ŏ�����
      set /a srcDecLen=%leftDecLen%
  
      rem �E�ӏ�����>���ӏ������̏ꍇ
      if %rightDecLen% gtr %leftDecLen% (
        rem �E�ӂ̌�����ݒ�
        set /a srcDecLen=%rightDecLen%
      )

      rem �[�����߃o�b�`�g�p(���ʃ��[�h)
      call %call_ZeroPadding% %leftDec% -%srcDecLen%
      set  leftDec=%return_ZeroPadding%
      call %call_ZeroPadding% %rightDec% -%srcDecLen%
      set  rightDec=%return_ZeroPadding%

echo %leftDec%
echo %rightDec%
pause
  : �v�Z
    rem �����v�Z
    set /a integer = %leftInt% + %rightInt%
    rem �����v�Z
    set /a decimal = %leftDec% + %rightDec%
  
    : ��������
      rem �����擾�o�b�`�g�p
      call %call_GetLen% %decimal%
      set /a resultDecimalLen=%return_GetLen%
  
      rem �����v�Z���ʂ̌��������̏����������傫���ꍇ
      if %resultDecimalLen% gtr %srcDecLen% (
        rem �J��オ��v�Z
        set /a integer = %integer% + 1
        rem �J��オ�����l�𔲂����l(�擪��0�̏ꍇ�A�G���[�ƂȂ邽�ߕ�����Ŋi�[)
        set decimal=!decimal:~-%srcDecLen%!
      )
  
rem �߂�l
ENDLOCAL && set return_CalcDecimal=%integer%.%decimal%
exit /b