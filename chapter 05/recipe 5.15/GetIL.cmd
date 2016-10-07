@echo off
set SOLUTION_BASE_PATH=C:\DotNetInteropWork\code\
rem ----------------------------------------------------
copy "%SOLUTION_BASE_PATH%\chapter 05\bin\DniComResults.dll"
rem cd "%SOLUTION_BASE_PATH%\chapter 05\bin"
rem ----------------------------------------------------
rem -generate import lib that we can manually edit
tlbimp.exe  DniComResults.dll  /out:Interop.DniComResults.dll /verbose
ildasm.exe Interop.DniComResults.dll /out:DniComResults.il
