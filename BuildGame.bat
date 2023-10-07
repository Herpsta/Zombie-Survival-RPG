@echo off
set /p version="Enter version number: "
7z a -t7z "Releases/ZombieSurvivalRPG_v%version%.7z" "Builds/ZombieSurvivalRPG_v%version%/*"
