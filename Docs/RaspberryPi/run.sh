#!/bin/bash

cd ../..
export DOTNET_ROOT=~/.dotnet
$DOTNET_ROOT/dotnet run --urls=http://+:5000/
