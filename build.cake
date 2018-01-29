#tool "nuget:?package=OpenCover"
#tool "nuget:?package=NUnit.ConsoleRunner"
#tool "nuget:?package=ReportGenerator"

var target = Argument("target", "Default");

Task("BuildProjects")
    .Does(() =>
    {
        foreach(var project in GetFiles("./src/**/*.csproj"))
        {
            MSBuild(project.GetDirectory().FullPath,
                new MSBuildSettings {
                    Verbosity = Verbosity.Minimal,
                    Configuration = "Debug"
                }
            );
        }
    });

Task("BuildTests")
    .IsDependentOn("BuildProjects")
    .Does(() =>
    {
        foreach(var project in GetFiles("./tests/**/*.csproj"))
        {
            MSBuild(project.GetDirectory().FullPath,
                new MSBuildSettings {
                    Verbosity = Verbosity.Minimal,
                    Configuration = "Debug"
                }
            );
        }
    });

Task("OpenCover")
    .IsDependentOn("BuildTests")
    .Does(() =>
    {
        var openCoverSettings = new OpenCoverSettings()
        {
            Register = "user",
            SkipAutoProps = true,
            ArgumentCustomization = args => args.Append("-coverbytest:*.Tests.dll").Append("-mergebyhash")
        };

        var outputFile = new FilePath("./docs/testsResults/Reports/CodeCoverageReport.xml");

        OpenCover(tool => {
            var testAssemblies = GetFiles("./tests/**/bin/Debug/*.Tests.dll");
            tool.NUnit3(testAssemblies);
            },
            outputFile,
            openCoverSettings
                .WithFilter("+[CodeCoverage*]*")
                .WithFilter("-[CodeCoverage.Tests]*")
        );
    });

Task("ReportGenerator")
    .IsDependentOn("OpenCover")
    .Does(() =>{
        var reportGeneratorSettings = new ReportGeneratorSettings()
        {
            HistoryDirectory = new DirectoryPath("./docs/testsResults/Reports/ReportsHistory")
        };

        ReportGenerator("./docs/testsResults/Reports/CodeCoverageReport.xml", 
                        "./docs/testsResults/Reports/ReportGeneratorOutput",
                        reportGeneratorSettings);
    });

Task("Default")
    .IsDependentOn("ReportGenerator")
    .Does(() => {
        if (IsRunningOnWindows())
        {
            var reportFilePath = ".\\docs\\testsResults\\Reports\\ReportGeneratorOutput\\index.htm";

            StartProcess("explorer", reportFilePath);
        }
    });

RunTarget(target);