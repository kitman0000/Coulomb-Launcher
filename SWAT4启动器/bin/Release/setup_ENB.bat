@echo off
echo ==========================================================
echo.
echo                   SWAT4����Ӱ������װ����
echo                          ELET��Ʒ
echo                  mod/�����Ȩ��ԭ��������
echo.
echo ==========================================================
echo ��ȴ�..
xcopy KL_ENB Content\system /e /y
xcopy KL_ENB ContentExpansion\system /e /y
rd KL_ENB /s /q 
echo ���
pause 