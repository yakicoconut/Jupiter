@echo off
title %~nx0
echo ffmpegで動画結合


rem 音量を上げる(4倍)
:C:\Users\scapegoatuser\Desktop\Tools_1_0\_Setup_20180512\ffmpeg-20171102-d5995c5-win64-static\bin\ffmpeg.exe -i "a43.mp4" -af "volume=0.5" "a43_.mp4"


rem 映像だけ分割
:ffmpeg.exe -i "a01.mp4" -vcodec copy -map 0:0 "ghi.mp4"
:
:rem 音声だけ分割
:ffmpeg.exe -i "a01.mp4" -vcodec copy -map 0:1 "ghi_.mp4"


rem 音声、映像結合
:ffmpeg.exe -i "a06.mp4" -i "def_.mp4" -vcodec copy "def__.mp4"
:
:ffmpeg.exe -f concat -i "def.mp4" -i "ghi.mp4" -c copy "jkl.mp4"