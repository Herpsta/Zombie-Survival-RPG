@echo off
setlocal enabledelayedexpansion

:: Set the path to the Builds directory
set "buildsDir=C:\Users\nyxar\Zombie Survival RPG\Builds"

:: Initialize variables to find the most recently modified folder
set "latestFolder="
set "latestTime=0"

:: Loop through each folder in the Builds directory
for /d %%a in ("%buildsDir%\*") do (
    :: Get the last modification timestamp of the folder
    for %%b in ("%%~ta") do set "folderTime=%%~tb"
    
    :: Convert the timestamp to YYYYMMDDHHMMSS format
    set "folderTime=!folderTime:~6,4!!folderTime:~0,2!!folderTime:~3,2!!folderTime:~11,2!!folderTime:~14,2!!folderTime:~17,2!"
    
    :: Compare with the latest timestamp
    if !folderTime! gtr !latestTime! (
        set "latestTime=!folderTime!"
        set "latestFolder=%%~nxa"
    )
)

:: Create the .7z archive using the most recently modified folder
if defined latestFolder (
    "C:\Program Files\7-Zip\7z.exe" a -t7z "C:\Users\nyxar\Zombie Survival RPG\Releases\!latestFolder!.7z" "%buildsDir%\!latestFolder!\*"
) else (
    echo No folders found in the Builds directory.
)

endlocal
