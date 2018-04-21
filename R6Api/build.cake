#tool "nuget:?package=GitVersion.CommandLine"
#addin nuget:?package=Newtonsoft.Json

using Newtonsoft.Json;

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var artifactsDirectory = MakeAbsolute(Directory("./artifacts"));

Setup(context =>
{
     CleanDirectory(artifactsDirectory);
});

Task("Build")
.Does(() =>
{
    foreach(var project in GetFiles("./src/**/*.csproj"))
    {
        DotNetCoreBuild(
            project.GetDirectory().FullPath, 
            new DotNetCoreBuildSettings()
            {
                Configuration = configuration
            });
    }
});

Task("Create-Artifact-Package")
.IsDependentOn("Build")
.WithCriteria(ShouldRunRelease())
.Does(() =>
{
    var version = GetPackageVersion();

    foreach (var project in GetFiles("./src/**/*.csproj"))
    {
        DotNetCorePack(
            project.GetDirectory().FullPath,
            new DotNetCorePackSettings()
            {
                Configuration = configuration,
                OutputDirectory = artifactsDirectory,
                ArgumentCustomization = args => args.Append($"/p:Version={version}")
            });
    }
});

Task("Default").IsDependentOn("Build");

RunTarget(target);