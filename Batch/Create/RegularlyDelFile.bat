@echo off
title %~nx0
echo ����t�@�C���폜�o�b�`
echo �^�X�N�X�P�W���[�����ŌĂяo���Ďg�p����


: �폜����
  rem Log�t�H���_���ōX�V���t��90���ȑO��.log�t�@�C�����폜
  rem ���^�X�N�X�P�W���[������Ăяo���ꍇ�A��΃p�X���g�p����
  forfiles /p "D:\Log" /d -90 /s /m "*.log" /c "cmd /c del @file"