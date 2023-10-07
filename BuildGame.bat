@echo off
set version=%1
7z a -t7z "Releases/ZombieSurvivalRPG_v%version%.7z" "C:\Users\nyxar\Zombie Survival RPG\Builds\ZombieSurvivalRPG_v%version%/*"
