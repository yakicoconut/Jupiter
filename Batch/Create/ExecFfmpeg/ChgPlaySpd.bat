@echo off
title %~nx0
echo ffmpeg�ōĐ����x����
: ffmpeg���g���ē���̍Đ����x��ς��Ă݂� - �]�������{�{
: 	http://fftest33.blog.fc2.com/blog-entry-36.html
: �f���Ɖ����� pts ������ setpts, asetpts | �j�R���{
: 	https://nico-lab.net/setpts_asetpts_with_ffmpeg/
: ffmpeg�̎g������R�}���h�ꗗ���܂Ƃ߂܂����B���惊�T�C�Y�E�Î~��ϊ��E�t���[����Ԃɂ���|������J�����B
: 	https://photo-tea.com/p/17/ffmpeg-command-list/

: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\..\OwnLib\UserInput.bat"


: ���[�U���͏���
  : �Ώۃt�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۃt�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set sourcePath=%return_UserInput1%

  : ����
    echo;
    echo �{�������(�����Ŏw��ux.x�v)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE NUM
    rem ���͒l���p��
    set spdRatio=%return_UserInput1%

  : �o�̓t�@�C����
    echo;
    echo �o�̓t�@�C��������(�v�g���q)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE STR
    rem ���͒l���p��
    set outPath=%return_UserInput1%

: ���s
  rem ���ʒ���
  : -i             :���t�@�C��
  : -vf            :
  : setpts=PTS/���l:
  :                 (��1:
  :                      
  :                 (��2:
  :                      
  : -af atempo=���l:
  :                 (��1:
  :                      
  :                 (��2:
  :                      
  ffmpeg\win32\ffmpeg.exe -i %sourcePath% -vf setpts=PTS/%spdRatio% -af atempo=%spdRatio% %outPath%