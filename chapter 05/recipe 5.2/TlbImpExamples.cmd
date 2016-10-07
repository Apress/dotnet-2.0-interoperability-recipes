cd ..\bin
@echo create a Strong Name key file
sn -k XXX.Interop.DniSimpleComVB.snk
tlbimp.exe  DniSimpleComVB.dll /keyfile:XXX.Interop.DniSimpleComVB.snk /out:XXX.Interop.DniSimpleComVB.dll /verbose