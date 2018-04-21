var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var solutionName = "./src/R6Api/R6Api.sln";
var artifactsDirectory = MakeAbsolute(Directory("./artifacts"));

Task("Build")
.Does(() =>
{
	DotNetCoreBuild(
		solutionName, 
		new DotNetCoreBuildSettings()
		{
			Configuration = configuration
		});
});

Task("Create-Pack")
.IsDependentOn("Build")
.Does(() =>
{
	DotNetCorePack(
		solutionName,
		new DotNetCorePackSettings()
		{
			Configuration = configuration,
			OutputDirectory = artifactsDirectory
		});
});

Task("Publish")
 .IsDependentOn("Create-Pack")
 .Does(() =>
{
    DotNetCorePublish(solutionName, new DotNetCorePublishSettings {
  Configuration = "Release",
  OutputDirectory = artifactsDirectory
 });
});

Task("Default").IsDependentOn("Publish");

RunTarget(target);