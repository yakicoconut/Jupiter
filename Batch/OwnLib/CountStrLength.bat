@echo off
title %~nx0
: �������J�E���g�o�b�`
: ����01:�Ώە�����
: �ߒl:������(���l)


rem �ϐ����[�J����
SETLOCAL
  : ����
    rem �Ώە�����擾
    set targetStr=%~1

  : �������J�E���g
  set length=0
  :LOOP
    rem �J�E���g�A�b�v
    set /a length+=1

    rem �����񂩂�ꕶ���폜
    set targetStr=%targetStr:~1%

    rem �������c���Ă���ꍇ�A���[�v
    if not "%targetStr%"=="" goto LOOP


rem �߂�l
ENDLOCAL && set /a return_CountStrLength=%length%
exit /b