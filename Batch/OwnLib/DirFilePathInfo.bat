@echo off
title %~nx0
: �f�B���N�g���t�@�C�����o�b�`
: ����01:�Ώۃf�B���N�g���t�@�C���p�X
: ����02:�p�X���I��(���L�Q��)
: ����03:��w�t�H���_�擾(��������up)�̂Ƃ��Ɏg�p
:        �f�t�H���g��1�K�w����擾
: �ߒl:�f�B���N�g���t�@�C�����


rem �ϐ����[�J����
SETLOCAL ENABLEDELAYEDEXPANSION
  : ������
    : �Ώۃp�X:C:\Program Files\Java\jre1.8.0_144\Welcome.html
    : ~   :C:\Program Files\Java\jre1.8.0_144\Welcome.html
    : f   :C:\Program Files\Java\jre1.8.0_144\Welcome.html
    : d   :C:
    : p   :\Program Files\Java\jre1.8.0_144\
    : n   :Welcome
    : x   :.html
    : s   :C:\PROGRA~1\Java\JRE18~2.0_1\WELCOM~1.HTM
    : a   :--a------
    : t   :2017/09/08 20:51
    : z   :955
    : dp  :C:\Program Files\Java\jre1.8.0_144\
    : nx  :Welcome.html
    : fs  :C:\PROGRA~1\Java\JRE18~2.0_1\WELCOM~1.HTM
    : ftza:--a------ 2017/09/08 20:51 955 C:\Program Files\Java\jre1.8.0_144\Welcome.html
    : up 1:jre1.8.0_144
    : up 2:Java


  : ����
    rem �f�t�H���g�ł͈��������̂܂ܐݒ�
    set dirFilePathInfo=%1

    rem �˂��ݕԂ�_���������Ȃ��ꍇ�A���I��
    if "%2"=="" goto END

    rem ���������u"�v�����Őݒ�
    set option=%~2

    rem ��O������ �l���Ȃ��ꍇ
    if "%3"=="" (
      rem �u1�v�ɐݒ�
      set /a upCount=1
    ) else (
      rem �u"�v�����Őݒ�
      set /a upCount=%~3
    )


    rem ���������u~�v�̏ꍇ�A�u"�v�폜
    if %option%==~ set dirFilePathInfo=%~1
    rem ���S�C���p�X��
    if %option%==f set dirFilePathInfo=%~f1
    rem �h���C�u����
    if %option%==d set dirFilePathInfo=%~d1
    rem �h���C�u�����𔲂������̃t�H���_�p�X
    if %option%==p set dirFilePathInfo=%~p1
    rem �t�@�C�����̂�
    if %option%==n set dirFilePathInfo=%~n1
    rem �g���q
    if %option%==x set dirFilePathInfo=%~x1
    rem �Z�����O
    if %option%==s set dirFilePathInfo=%~s1
    rem ����
    if %option%==a set dirFilePathInfo=%~a1
    rem ���t/����
    if %option%==t set dirFilePathInfo=%~t1
    rem �T�C�Y
    if %option%==z set dirFilePathInfo=%~z1
    rem ���C�u�����ƃp�X
    if %option%==dp set dirFilePathInfo=%~dp1
    rem �t�@�C�����Ɗg���q
    if %option%==nx set dirFilePathInfo=%~nx1
    rem ���S�ȃp�X�ƒZ�����O
    if %option%==fs set dirFilePathInfo=%~fs1
    rem dir�R�}���h�o��
    if %option%==ftza set dirFilePathInfo=%~ftza1
    rem �������_�t�H���_��(��O�����g�p)
    if %option%==up (
      rem ���[�v�J�E���g������
      set /a loopCount=0

      rem �w��K�w����̃t�H���_�����[�v�Ŏ擾
      :UPLOOP
        rem �t�H���_�p�X(����\�܂�)�擾
        set dirFilePathInfo=%~p1
        rem �����́u\�v�}�[�N����
        set dirFilePathInfo=!dirFilePathInfo:~0,-1!

        rem ���[�v�J�E���g�A�b�v
        set /a loopCount+=1
        rem ���[�v�񐔂����������ΏI��
        if not !loopCount!==!upCount! call :UPLOOP "!dirFilePathInfo!""

      rem �p�X�ŉ��w�̃t�H���_���擾
      for /f "delims=" %%a in ("!dirFilePathInfo!") do set dirFilePathInfo=%%~nxa
    )


:END
  rem ��������

rem �߂�l
ENDLOCAL && set return_DirFilePathInfo=%dirFilePathInfo%
exit /b