@echo off
title %~nx0
echo ffmpeg‚Å“®‰æŒ‹‡


rem ‰¹—Ê‚ğã‚°‚é(4”{)
:C:\Users\scapegoatuser\Desktop\Tools_1_0\_Setup_20180512\ffmpeg-20171102-d5995c5-win64-static\bin\ffmpeg.exe -i "a43.mp4" -af "volume=0.5" "a43_.mp4"


rem ‰f‘œ‚¾‚¯•ªŠ„
:ffmpeg.exe -i "a01.mp4" -vcodec copy -map 0:0 "ghi.mp4"
:
:rem ‰¹º‚¾‚¯•ªŠ„
:ffmpeg.exe -i "a01.mp4" -vcodec copy -map 0:1 "ghi_.mp4"


rem ‰¹ºA‰f‘œŒ‹‡
:ffmpeg.exe -i "a06.mp4" -i "def_.mp4" -vcodec copy "def__.mp4"
:
:ffmpeg.exe -f concat -i "def.mp4" -i "ghi.mp4" -c copy "jkl.mp4"