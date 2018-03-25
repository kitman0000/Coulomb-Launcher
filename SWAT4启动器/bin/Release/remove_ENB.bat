@echo off
rd content\system\ReShade /s /q 
del Content\system\d3d9.dll
del content\system\ReShade.fx
del content\system\ReShade
del content\system\d3d9.dll

rd ContentExpansion\system\ReShade /s/q
del ContentExpansion\system\d3d9.dll
del ContentExpansion\system\ReShade.fx
del ContentExpansion\system\ReShade
del ContentExpansion\system\d3d9.dll

echo Íê³É
pause