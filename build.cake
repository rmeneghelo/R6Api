#tool "nuget:?package=GitVersion.CommandLine"
#addin nuget:?package=Newtonsoft.Json

using Newtonsoft.Json;

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Task("Build")
.Does(() =>
{
	DotNetCoreBuild(
		"./src/R6Api/R6Api.csproj", 
		new DotNetCoreBuildSettings()
		{
			Configuration = configuration
		});
});

Task("Default").IsDependentOn("Build");

RunTarget(target);