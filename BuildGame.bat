@echo off
setlocal enabledelayedexpansion

:: Add this line to pull LFS objects
git lfs pull

:: Debug: Show when the script starts
echo Script started.

:: Set the path to the Builds directory relative to the workspace
set "buildsDir=%cd%\Builds"

:: Debug: Show the Builds directory
echo Builds directory is %buildsDir%.

:: Use PowerShell to find the most recently modified folder
for /f "delims=" %%i in ('powershell -command "Get-ChildItem -Path '%buildsDir%' | Sort-Object LastWriteTime -Descending | Select-Object -First 1 -ExpandProperty Name"') do set "latestFolder=%%i"

:: Debug: Show the most recently modified folder
echo Most recently modified folder is !latestFolder!.

:: Create the .7z archive using the most recently modified folder
if defined latestFolder (
    echo Creating 7z archive.
    "C:\Program Files\7-Zip\7z.exe" a -t7z "%cd%\Releases\v!latestFolder!.7z" "%buildsDir%\!latestFolder!\*"
    echo 7z archive created.
) else (
    echo No folders found in the Builds directory.
)

:: Generate checksum for the game build
CertUtil -hashfile "%cd%\Releases\v!latestFolder!.7z" SHA256 > "%cd%\Releases\v!latestFolder!.sha256"

:: Debug: Show when the script ends
echo Script ended.

endlocal
