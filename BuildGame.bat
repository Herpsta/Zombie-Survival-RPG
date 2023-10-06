@echo off
setlocal

:: Build the Unity project
"C:\Program Files\Unity\Hub\Editor\2022.3.10f1\Editor\Unity.exe" -quit -batchmode -projectPath "C:\Users\nyxar\Zombie Survival RPG" -executeMethod BuildGame.BuildAll

:: Create a .7z archive with the version number in the filename
"C:\Program Files\7-Zip\7z.exe" a -t7z "Zombie Survival RPG_%VERSION%.7z" "./Releases/*"

endlocal
