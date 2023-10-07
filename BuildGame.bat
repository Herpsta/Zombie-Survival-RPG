@echo off
setlocal

:: Set the version number from environment variable
set VERSION=%VERSION%

:: Delete the contents of the Build and Release folders
echo Deleting old builds and releases...
rmdir /s /q "C:\Users\nyxar\Zombie Survival RPG\Builds"
rmdir /s /q "C:\Users\nyxar\Zombie Survival RPG\Releases"

:: Build the Unity project
echo Building the Unity project...
"C:\Program Files\Unity\Hub\Editor\2022.3.10f1\Editor\Unity.exe" -quit -batchmode -projectPath ".\" -executeMethod BuildGame.BuildAll

:: Create a .7z archive with the version number in the filename
echo Creating .7z archive...
"C:\Program Files\7-Zip\7z.exe" a -t7z ".\Releases\ZombieSurvivalRPG_v%VERSION%.7z" ".\Builds\*"

echo Done. >> batch_output.log
pause

endlocal
