#!/bin/bash

cd Bin
cmake .
make
cd ..
dotnet Bin/Server.App.dll --appId=1 --appType=AllServer --config=../Config/StartConfig/LocalAllServer.txt