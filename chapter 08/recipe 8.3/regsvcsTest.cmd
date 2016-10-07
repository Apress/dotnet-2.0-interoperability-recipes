@echo off
@echo Demonstrate use of regsvcs
rem -----------------------------------------------------------------
rem regsvcs DniScServerComponent.dll

rem regsvcs /appname:MyServerApp DniScServerComponent.dll

rem regsvcs /u /appname:MyServerApp DniScsimpleComponent.dll
rem regsvcs /appname:MyServerApp2 DniScsimpleComponent.dll

rem regsvcs /noreconfig DniScServerComponent.dll
rem regsvcs /noreconfig DniScJIT.dll
rem regsvcs /noreconfig /appname:DniServerApplication DniScSimpleComponent.dll
rem regsvcs /u /appname:DniServerApplication DniScSimpleComponent.dll

rem regsvcs /noreconfig /appname:DniServerApplication DniScSimpleComponent.dll
rem regsvcs /noreconfig DniScServerComponent.dll
rem regsvcs /noreconfig DniScJIT.dll

rem regsvcs /exapp /noreconfig /appname:DniServerApplication DniScSimpleComponent.dll

rem regsvcs /tlb:MyTypeLib.tlb DniScSimpleComponent.dll
rem regsvcs /extlb /tlb:MyTypeLibX.tlb DniScSimpleComponent.dll

rem regsvcs  /appname:MyServerApp /appdir:c:\temp\ DniScSimpleComponent.dll

rem regsvcs DniScServerComponent.dll
rem regsvcs /u DniScServerComponent.dll

regsvcs DniScsimpleComponent.dll
regsvcs /u DniScsimpleComponent.dll