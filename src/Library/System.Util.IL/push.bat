nuget push *.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate

::force succeed
exit 0
