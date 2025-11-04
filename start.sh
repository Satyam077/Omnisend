#!/bin/sh

# Navigate to server folder
cd Omnisend.Server

# Run ASP.NET API
dotnet run --urls "http://0.0.0.0:5279;https://0.0.0.0:7179"
