@echo off
title %~nx0
echo ���C���u�����`��Git Push�����s����
: bat�t�@�C���ɂ��Git�����[�g���|�W�g���ւ�push
: 	http://country-programmer.dfkp.info/2017/09/pushbybat/
: �V�F���X�N���v�g�Ō��݂̃u�����`�����擾����igit rev-parse�j - �y���M���� Tech Blog
: 	http://blog.penginmura.tech/entry/2018/01/12/093400


: ���O����
  rem �w��u�����`��
  set targetBranch=master


: �J�����g�u�����`���擾
  rem �u�����`���擾Git�R�}���h�쐬
  set revParse=git rev-parse --abbrev-ref HEAD

  rem �R�}���h���ʕϐ���
  for /f "usebackq delims=" %%a in (`%revParse%`) do set curBranch=%%a


: �u�����`���f
  if not %curBranch%==%targetBranch% (
    echo;
    echo �J�����g�u�����`���w�薼�ƈقȂ�܂�
    echo   �w��:%targetBranch%
    echo   ����:%curBranch%
    echo;
    echo �v�b�V���͎��s�����I�����܂�

    pause
    exit
  )


: ���s
  echo;
  echo �v�b�V�������s���܂�
  echo �Ώۃu�����`:%curBranch%

  echo;
  pause

  rem �v�b�V�����s
  echo;
  git push


pause