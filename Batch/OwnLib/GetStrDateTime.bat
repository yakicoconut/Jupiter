@echo off
title %~nx0
rem ���l�̂ݔN���������b�~���擾�o�b�`
rem �ߒl:���l�̂ݔN���������b�~��


rem �ϐ����[�J����
SETLOCAL
  : �N���������b�~���擾
    rem �N�������擾(�u/�v�폜)
    set repDate=%date:/=%
    rem �����擾(�ꌅ���l�[������)
    set repTime=%time: =0%
    rem �u:�v�폜
    set repTime=%repTime::=%
    rem �u.�v(�~���b�R���})�폜
    set repTime=%repTime:.=%


rem �߂�l
ENDLOCAL && set return_GetStrDateTime=%repDate%%repTime%
exit /b