@echo off
setlocal

:: Set the version number
set VERSION=0.2.4

:: Build the Unity project
"C:\Program Files\Unity\Hub\Editor\2022.3.10f1\Editor\Unity.exe" -quit -batchmode -projectPath "C:\Users\nyxar\Zombie Survival RPG" -executeMethod BuildGame.BuildAll

:: Create a .7z archive with the version number in the filename
"C:\Program Files\7-Zip\7z.exe" a -t7z "./Releases/Zombie Survival RPG_%VERSION%.7z" "./Builds/*"

endlocal


@echo off
setlocal

:: Delete the contents of the Build and Release folders
rmdir /s /q "C:\Users\nyxar\Zombie Survival RPG\Builds*"
rmdir /s /q "C:\Users\nyxar\Zombie Survival RPG\Releases*"

:: Build the Unity project
"C:\Program Files\Unity\Hub\Editor\2022.3.10f1\Editor\Unity.exe" -quit -batchmode -projectPath "C:\Users\nyxar\Zombie Survival RPG" -executeMethod BuildGame.BuildAll

:: Create a .7z archive with the version number in the filename
"C:\Program Files\7-Zip\7z.exe" a -t7z "Zombie Survival RPG_%VERSION%.7z" "./Releases/*"

endlocal
