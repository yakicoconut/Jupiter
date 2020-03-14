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
      rem �����擾�o�b�`�g�p
      call %call_GetLen% %leftDec%
      set /a leftDecLen=%return_GetLen%

    : �E��
      call %call_SepDecimal% %rightVal%
      set rightInt=%return_SepDecimal01%
      set rightDec=%return_SepDecimal02%
      call %call_GetLen% %rightDec%
      set /a rightDecLen=%return_GetLen%

    : �����v�Z����
      rem �����_�ȉ����ʂ�0�̏ꍇ�A�v�Z�p����1��ݒ�
      if %leftDec:~0,1%==0 set /a leftCalcInt=1
      if %rightDec:~0,1%==0 set /a rightCalcInt=1
      rem �v�Z�p�������v�ϐ�������
      set /a sumCalcInt=1
      rem �ǂ���̒l��[����or�Ȃ�]�̏ꍇ
      if "%leftCalcInt%"=="%rightCalcInt%" (
        set /a sumCalcInt=0
        rem �l������ꍇ
        if "%leftCalcInt%""%rightCalcInt%"=="1""1" set /a sumCalcInt=2
      )

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
      rem �v�Z�p�����̍��v�ɒl������ꍇ
      if not "%sumCalcInt%"=="" (
        rem �v�Z�p�����̍��v�𐮐����ɍ��킹��
        set /a addIntDecLen=%srcDecLen%+1
        call %call_ZeroPadding% %sumCalcInt% -!addIntDecLen!
        set  sumCalcInt=!return_ZeroPadding!
      )

  : �v�Z
    : �P���v�Z
      rem �����v�Z
      set /a integer = %leftInt% + %rightInt%
      rem �����v�Z
      rem 0�n�܂�̏ꍇ�A���l�^�G���[�ƂȂ邽�ߌv�Z�p����1���g�p���Čv�Z
      set /a decimal = %leftCalcInt%%leftDec% + %rightCalcInt%%rightDec%
      rem �v�Z�p�������N���A
      set /a decimal = decimal - %sumCalcInt%

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