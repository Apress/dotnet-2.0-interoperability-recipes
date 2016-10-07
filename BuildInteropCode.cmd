@echo off
@echo COMMAND-LINE BUILD FOR 
@echo .NET 2.0 INTEROPERABILITY RECIPES
@echo by Bruce Bukovics * Apress
rem ------------------------------------------------------------
set BUILDUTILITY=msbuild
set BUILDACTION=/t:Rebuild
set BUILDPROFILE2005=/p:Configuration=Debug /p:Platform="Mixed Platforms"
set BUILDPROFILE2005ANY=/p:Configuration=Debug /p:Platform="Any Cpu"
rem -------------------------------------------------
set VSDEVENVVB6="%HOMEDRIVE%\Program Files\Microsoft Visual Studio\VB98\VB6.exe"
rem -------------------------------------------------
if not "%1" == "" set BUILDACTION=%1
@echo BUILDACTION = %BUILDACTION%
pause
rem -------------------------------------------------
@echo START OF NEW BUILD > %HOMEDRIVE%\buildlog.txt
rem -------------------------------------------------
@echo VB 6.0 COM SERVER BUILDS 
%VSDEVENVVB6% /m "chapter 05\chapter05vb.vbg" /outdir "chapter 05\bin" /out %HOMEDRIVE%\buildlog.txt
rem -------------------------------------------------
@echo Build interop assemblies for any VB6 components
@echo BUILD INTEROP ASSEMBLIES
rem ----------------------------------------------------
cd chapter 05\bin
rem ----------------------------------------------------
tlbimp.exe  DniSimpleComVB.dll  /out:Interop.DniSimpleComVB.dll /verbose
tlbimp.exe  DniComEventsVB.dll  /out:Interop.DniComEventsVB.dll /verbose
tlbimp.exe  DniDataTypesVB.dll  /out:Interop.DniDataTypesVB.dll /verbose
tlbimp.exe  DniExtendComVB.dll  /out:Interop.DniExtendComVB.dll /verbose
tlbimp.exe  DniComRefactorVB.dll  /out:Interop.DniComRefactorVB.dll /verbose
tlbimp.exe  DniComResultsVB.dll  /out:Interop.DniComResultsVB.dll /verbose
tlbimp.exe  DniErrorInfoVB.dll  /out:Interop.DniErrorInfoVB.dll /verbose
cd ..\..\
rem -------------------------------------------------
@echo VS.NET 2005 BUILDS
@echo START OF NEW BUILD >> %HOMEDRIVE%\buildlog.txt
@echo BUILDING CHAPTER 1
%BUILDUTILITY% "chapter 01\chapter 01.sln" %BUILDACTION% %BUILDPROFILE2005% >> %HOMEDRIVE%\buildlog.txt
@echo BUILDING CHAPTER 2
%BUILDUTILITY% "chapter 02\chapter 02.sln" %BUILDACTION% %BUILDPROFILE2005% >> %HOMEDRIVE%\buildlog.txt
@echo BUILDING CHAPTER 3
%BUILDUTILITY% "chapter 03\chapter 03.sln" %BUILDACTION% %BUILDPROFILE2005ANY% >> %HOMEDRIVE%\buildlog.txt
@echo BUILDING CHAPTER 4
%BUILDUTILITY% "chapter 04\chapter 04.sln" %BUILDACTION% %BUILDPROFILE2005% >> %HOMEDRIVE%\buildlog.txt
@echo BUILDING CHAPTER 5
%BUILDUTILITY% "chapter 05\chapter 05.sln" %BUILDACTION% %BUILDPROFILE2005% >> %HOMEDRIVE%\buildlog.txt
@echo BUILDING CHAPTER 6
%BUILDUTILITY% "chapter 06\chapter 06.sln" %BUILDACTION% %BUILDPROFILE2005% >> %HOMEDRIVE%\buildlog.txt
@echo BUILDING CHAPTER 7
%BUILDUTILITY% "chapter 07\chapter 07.sln" %BUILDACTION% %BUILDPROFILE2005% >> %HOMEDRIVE%\buildlog.txt
@echo BUILDING CHAPTER 8
%BUILDUTILITY% "chapter 08\chapter 08.sln" %BUILDACTION% %BUILDPROFILE2005ANY% >> %HOMEDRIVE%\buildlog.txt
@echo BUILDING CHAPTER 9
%BUILDUTILITY% "chapter 09\chapter 09.sln" %BUILDACTION% %BUILDPROFILE2005ANY% >> %HOMEDRIVE%\buildlog.txt
rem -------------------------------------------------
@echo VB 6.0 COM CLIENT BUILDS FOR CHAPTER 6 
%VSDEVENVVB6% /m "chapter 06\chapter06vb.vbg" /outdir "chapter 06\bin" /out %HOMEDRIVE%\buildlog.txt
@echo VB 6.0 COM CLIENT BUILDS FOR CHAPTER 7
%VSDEVENVVB6% /m "chapter 07\chapter07vb.vbg" /outdir "chapter 07\bin" /out %HOMEDRIVE%\buildlog.txt
@echo VB 6.0 COM CLIENT BUILDS FOR CHAPTER 8
%VSDEVENVVB6% /m "chapter 08\chapter08vb.vbg" /outdir "chapter 08\bin" /out %HOMEDRIVE%\buildlog.txt
rem -------------------------------------------------
:exit
@echo END OF BUILD - SUMMARY FOLLOWS >> %HOMEDRIVE%\buildlog.txt
find "error" %HOMEDRIVE%\buildlog.txt >> %HOMEDRIVE%\buildlog.txt
rem -------------------------------------------------
start notepad.exe %HOMEDRIVE%\buildlog.txt
rem -------------------------------------------------
