#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
dotnet msbuild /v:minimal /t:Package /p:SetVersion=$1 -property:Configuration=Release  $DIR/build/Build.proj
