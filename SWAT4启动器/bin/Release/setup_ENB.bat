@echo off
echo ==========================================================
echo.
echo                   SWAT4·光影补丁安装程序
echo                          ELET出品
echo                  mod/插件版权归原作者所有
echo.
echo ==========================================================
echo 请等待..
xcopy KL_ENB Content\system /e /y
xcopy KL_ENB ContentExpansion\system /e /y
rd KL_ENB /s /q 
echo 完成
pause 