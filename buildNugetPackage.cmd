nuget\nuget restore ./src/System.Collections.Async.sln
msbuild ./src/Solution.sln /t:Build /p:Configuration="Release"
mkdir build
nuget\nuget pack ./src/System.Collections.Async.nuspec -OutputDirectory build