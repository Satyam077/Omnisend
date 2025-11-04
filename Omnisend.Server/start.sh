#!/bin/bash
set -e
dotnet restore
dotnet publish -c Release -o out
cd out
dotnet Omnisend.Server.dll
