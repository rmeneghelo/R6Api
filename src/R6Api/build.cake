var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

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

Task("Default").IsDependentOn("Build");

RunTarget(target);