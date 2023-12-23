#!/bin/bash

dotnet new xunit -o test/day$1Test
dotnet new classlib -o src/day$1 
dotnet add src/day$1/day$1.csproj reference src/Helper/FileLoader/FileLoader.csproj
dotnet add test/day$1Test/day$1Test.csproj reference src/day$1/day$1.csproj 
dotnet sln add src/day$1/day$1.csproj 
dotnet sln add test/day$1Test/day$1Test.csproj
mv src/day$1/Class1.cs src/day$1/Day$1.cs
mv test/day$1Test/UnitTest1.cs test/day$1Test/Day$1Test.cs
