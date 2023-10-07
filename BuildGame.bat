@echo off
setlocal

:: Prompt the user for the version number
set /p VERSION="Enter the version number: "

:: Create the Build and Release folders if they don't exist
if not exist "Builds" mkdir "Builds"
if not exist "Releases" mkdir "Releases"

:: Delete the contents of the Build and Release folders
echo Deleting old builds and releases...
for /d %%X in ("Builds\*") do rmdir /s /q "%%X"
for /d %%X in ("Releases\*") do rmdir /s /q "%%X"

:: Build the Unity project
echo Building the Unity project...
"C:\Program Files\Unity\Hub\Editor\2022.3.10f1\Editor\Unity.exe" -quit -batchmode -projectPath "%CD%" -executeMethod BuildGame.BuildAll "%VERSION%"

:: Create a .7z archive with the version number in the filename
echo Creating .7z archive...
"C:\Program Files\7-Zip\7z.exe" a -t7z ".\Releases\ZombieSurvivalRPG_v%VERSION%.7z" ".\Builds\*"

:: Log the output
echo Done. >> batch_output.log

pause

endlocal
