@ECHO off
cd src
csc QotdClient.cs
move QotdClient.exe ..
csc QotdServer.cs
move QotdServer.exe ..
move message.txt ..
cd ..
