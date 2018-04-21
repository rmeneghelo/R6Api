var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var csprojName = "./src/R6Api/R6Api.csproj";
var artifactsDirectory = MakeAbsolute(Directory("./artifacts"));

Task("Build")
.Does(() =>
{
	DotNetCoreBuild(
		csprojName, 
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
		csprojName,
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
    DotNetCorePublish(csprojName, new DotNetCorePublishSettings {
  Configuration = "Release",
  OutputDirectory = artifactsDirectory
 });
});

Task("Default").IsDependentOn("Publish");

RunTarget(target);