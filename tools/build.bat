
@ECHO OFF

echo:
echo ==========================
echo Be2BillNet package builder
echo ==========================
echo:

set currentDirectory=%CD%
cd ..
cd build
set outputDirectory=%CD%
cd %currentDirectory%
set nuget=%CD%\..\tools\nuget.exe
set msbuild4="%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"
set vincrement=%CD%\..\tools\Vincrement.exe


echo Check CLI apps
echo -----------------------------

if not exist %nuget% (
 echo ERROR: nuget could not be found, verify path. exiting.
 echo Configured as: %nuget%
 pause
 exit
)

if not exist %msbuild4% (
 echo ERROR: msbuild 4 could not be found, verify path. exiting.
 echo Configured as: %msbuild4%
 pause
 exit
)

if not exist %vincrement% (
 echo ERROR: vincrement could not be found, verify path. exiting.
 echo Configured as: %vincrement%
 pause
 exit
)

echo Everything is fine.

echo:
echo Build solution
echo -----------------------------
cd ..
cd src
set solutionDirectory=%CD%
%msbuild4% Be2BillNet.sln /p:Configuration=Release /nologo /verbosity:q

if not %ERRORLEVEL% == 0 (
 echo ERROR: build failed. exiting.
 cd %currentDirectory%
 pause
 exit
)
echo Done.

echo:
echo Copy libs
echo -----------------------------
mkdir %outputDirectory%\lib
mkdir %outputDirectory%\lib\net40
xcopy /Q %solutionDirectory%\NET40.Be2BillNet\bin\Release\* %outputDirectory%\lib\net40
echo Done.




echo:
echo Increment version number
echo -----------------------------

echo Hit return to continue...
pause 
%vincrement% -file=%outputDirectory%\version.txt 0.0.1 %outputDirectory%\version.txt
if not %ERRORLEVEL% == 0 (
 echo ERROR: vincrement. exiting.
 cd %currentDirectory%
 pause
 exit
)
set /p version=<%outputDirectory%\version.txt
echo Done: %version%



echo:
echo Build NuGet package
echo -----------------------------

echo Hit return to continue...
pause 
cd %outputDirectory%
%nuget% pack Be2BillNet.nuspec -Version %version%
echo Done.




echo:
echo Push NuGet package
echo -----------------------------

echo Hit return to continue...
pause 
cd %outputDirectory%
%nuget% push Be2BillNet.%version%.nupkg
echo Done.





cd %currentDirectory%
pause



