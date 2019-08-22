#!/bin/bash
cd src
sudo snap alias dotnet-sdk.dotnet dotnet
dotnet restore
dotnet build
