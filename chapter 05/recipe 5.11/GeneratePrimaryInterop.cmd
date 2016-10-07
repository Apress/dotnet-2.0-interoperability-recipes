@echo off
@echo Create a primary interop assembly

rem ---generate the strong name key pair---
sn -k DniComRefactorVB.snk

rem ---create the primary interop assembly---
tlbimp DniComRefactorVB.Dll /primary /keyfile:DniComRefactorVB.snk /namespace:Bukovics.DniComRefactorVB.Interop /out:Bukovics.DniComRefactorVB.Interop.dll /asmversion:1.0.1.0 /verbose

rem ---register the assembly---
regasm Bukovics.DniComRefactorVB.Interop.dll

rem ---add the assembly to the GAC---
gacutil /if Bukovics.DniComRefactorVB.Interop.dll

rem ---unregister everything
regasm Bukovics.DniComRefactorVB.Interop.dll /u
gacutil /uf Bukovics.DniComRefactorVB.Interop
regasm Bukovics.DniComRefactorVB.Interop.dll /regfile x.reg