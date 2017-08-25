@ECHO off
call "C:\Program Files (x86)\Microsoft Visual Studio 12.0\VC\vcvarsall.bat"
ECHO.
@ECHO ON
sqlmetal /server:DESKTOP-UPNNGRH\MARGOSQLSERVER /database:itspRoute  /namespace:Route66.LTS /user:sa /password:Mty011gp /code:"C:\Users\hmarg\Desktop\ITSP\Route66\Route66\LTS\LTSBase.cs" /views /functions /sprocs /language:c# /context:LTSBase
@ECHO OFF
ECHO.
ECHO Done...
ECHO.
PAUSE