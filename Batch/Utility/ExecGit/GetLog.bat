@echo off
title %~nx0
echo �Ώۃt�H���_�R�~�b�g�����擾
: �ڍ�
:   --reverse       :
:   --pretty=oneline:
:   -- �p�X         :
: �T�C�g
:   git log�ŃR�~�b�g�n�b�V�������ق��� - DRY�Ȕ��Y�^
:   	https://otiai10.hatenablog.com/entry/2016/06/15/072039
:   git�ŃR�~�b�g���O���t���i�Â�������j�\������ : git log first commit tail initial reverse ? GitHub
:   	https://gist.github.com/maeharin/4727153
:   git log�̃I�v�V�������Y��Ƀc���[�\�����邽�߂̃G�C���A�X - Qiita
:   	https://qiita.com/hirotsugu_kawa/items/41afaafe477b877b5b73
:   git log�����ԏ��Ƀ\�[�g���� ? DQNEO�N�Ɠ��L
:   	http://dqn.sakusakutto.jp/2014/10/git_log_date_order.html
:   git log�R�}���h�܂Ƃ� - Qiita
:   	https://qiita.com/ma5aki-Y/items/2f5d57207bbd8a57b15e
:   git log �� option �F�X - Qiita
:   	https://qiita.com/takayukioda/items/f1fa9e4c18c233b93e11
:   git log�œ���f�B���N�g���̃R�~�b�g�������{������ - Qiita
:   	https://qiita.com/devnokiyo/items/6444c92223aa7e83e93d


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\..\OwnLib\UserInput.bat"
  rem ���l�̂ݔN���������b�~���擾�o�b�`
  set call_GetStrDateTime="..\..\OwnLib\GetStrDateTime.bat"
  rem ���l�̂ݔN���������b�~���擾�o�b�`�g�p
  call %call_GetStrDateTime%


: �������p��
  rem �Ώۃt�H���_
  set tgtDir="%~1"

  rem �˂��ݕԂ�_�������Ȃ��ꍇ
  if "%~1"=="" (
    goto :USR_INPUT
  )
  goto :EXEC


:USR_INPUT
  : �Ώۃt�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۃt�H���_�p�X���� TRUE PATH
    rem ���͒l���p��
    set tgtDir=%return_UserInput1%


:EXEC
  rem ���O�擾���s
  git log --reverse --pretty=oneline -- %tgtDir:"=%>%return_GetStrDateTime%.txt


pause
exit /b