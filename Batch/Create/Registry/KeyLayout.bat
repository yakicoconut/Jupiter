@echo off
title %~nx0
echo �L�[�{�[�h���C�A�E�g�ύX
   : Windows/TIPS/���W�X�g�����C������CAPSLOCK�̊��蓖�ĕύX - yanor.net/wiki
	 :  http://yanor.net/wiki/?Windows/TIPS/%E3%83%AC%E3%82%B8%E3%82%B9%E3%83%88%E3%83%AA%E3%82%92%E4%BF%AE%E6%AD%A3%E3%81%97%E3%81%A6CAPSLOCK%E3%81%AE%E5%89%B2%E3%82%8A%E5%BD%93%E3%81%A6%E5%A4%89%E6%9B%B4
   : Windows10 CapsLock�L�[��Ctrl�L�[�Ɋ��蓖�Ă� | �J���҂Ƃ��Ă̐����헪
	 :  https://workers-strategy.net/84/


: �ϕϐ�
  : �ύX�Ώ�
  :   ���[��1:�L�[���蓖�Ă�ύX����P�ʂ͈ȉ��ŕ\��
  :           �uxxxxyyyy�v
  :           xxxx:�ύX��̋@�\
  :           yyyy:�ύX�Ώۂ̃L�[�{�[�h�L�[
  :   ���[��2:��L�uxxxx�v�A�uyyyy�v�̓X�L�����R�[�h(���L)�ŋL�q����
  :   ���[��3:�X�L�����R�[�h��4��0���߂ŁA���g���G���f�B�A���̂��߂Ђ�����Ԃ��ċL�q����
  :           (��:�uApplication�v�̓X�L�����R�[�h���uE05D�v�̂���                  �Ђ�����Ԃ��āu5DE0�v�ƋL�q����
  :               �uCtrl(��)�v   �̓X�L�����R�[�h���u1D�v  �̂���4��0���߂Łu001D�v�Ђ�����Ԃ��āu1D00�v�ƋL�q����
  :
  :   ���[�J�����[��:�u,�v�A�u-�v�͌�q�̏����ō폜���邽��
  :                   �uxxxx�v�Ɓuyyyy�v���u,�v�ŋ�؂�A
  :                   �����̃L�[�����ւ���ꍇ�uxxxx,yyyy�v���u-�v�ŋ�؂茩�₷������
  :                   ���uxxxx,yyyy-xxxx,yyyy�v(�K�{�ł͂Ȃ�)
  set targetKeyLayout=5DE0,37E0

  : �ύX����
  :  ��L�u�ύX�Ώہv�ɂ����ύX�Ώۂ����邩���w�肷��
  :  ���[��1:0���ߓ񌅂ŋL�q
  :  ���[��2:���L�u�^�[�~�l�[�^�[�v��ǉ����邽�߁u�ύX�Ώې�+1�v�Ƃ���
  :          (��:�uESC�v���uNumLock�v�A�uPrintScreen�v���uScrollLock�v�̏ꍇ
  :              2(�ύX�Ώې�)+1(�^�[�~�l�[�^�[)�Łu03�v�Ƃ���
  :  ���񌅂͖����؁A16�i���ŋL�q����K�v������?
  set targetNum=02


: ���O����
  rem ���W�X�g���p�X
  set targetKey="HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Keyboard Layout"
  rem �w�b�_(�Œ�l)
  set header=00,00,00,00,00,00,00,00
  rem �^�[�~�l�[�^�[(�Œ�l)
  set terminator=00,00,00,00

  rem �o�C�i���A��
  set targetBinary=%header%%targetNum%000000%targetKeyLayout%%terminator%
  rem �u,�v���폜
  set targetBinary=%targetBinary:,=%
  rem �u-�v���폜
  set targetBinary=%targetBinary:-=%


: ���s
  : ���ݐݒ�o��
    : /s:�ċA�I�Ɍ���
    : /v:�l�����w��
    reg query %targetKey% /s>CURRENT_REG_PRE.txt

  : �폜
    : reg delete %targetKey% /v "Scancode Map" /f

  : �ǉ�
    rem ���C�A�E�g�ύX�l�ǉ�
    reg add %targetKey% /v "Scancode Map" /t REG_BINARY /d %targetBinary% /f

  : �X�V��ݒ�o��
    : /s:�ċA�I�Ɍ���
    : /v:�l�����w��
    reg query %targetKey% /s>CURRENT_REG_POST.txt


: ����
  : �X�L�����R�[�h
  :   Alt(�E)          :E038
  :   Alt(��)          :38
  :   Ctrl(�E)         :E01D
  :   Ctrl(��)         :1D
  :   Shift(�E)        :36
  :   Shift(��)        :2A
  :   Win(�E)          :E05C
  :   Win(��)          :E05B
  :   Application      :E05D
  :   NumLock          :45
  :   PrintScreen      :E037
  :   ScrollLock       :E046
  :   Pause            :E045
  :   CapsLock         :3A
  :   ESC              :01
  :   ���p/�S�p        :29
  :   �ϊ�             :79
  :   ���ϊ�           :7B
  :   �J�^�J�i/�Ђ炪��:70
  :   Insert           :E052
  :   Delete           :E053
  :   `(~�`���_)       :29
  :   F1               :3B
  :   F2               :3C
  :   F3               :3D
  :   F4               :3E
  :   F5               :3F
  :   F6               :40
  :   F7               :41
  :   F8               :42
  :   F9               :43
  :   F10              :44
  :   F11              :57
  :   F12              :58

pause