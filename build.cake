#tool "nuget:?package=OpenCover"
#tool "nuget:?package=NUnit.ConsoleRunner"
#tool "nuget:?package=ReportGenerator"

var target = Argument("target", "Default");

Task("BuildProject")
    .Does(() =>
    {
        MSBuild("./src/CodeCoverage.Domain/CodeCoverage.Domain.csproj",
            new MSBuildSettings {
                Verbosity = Verbosity.Minimal,
                Configuration = "Debug"
            }
        );
    });

Task("BuildTest")
    .IsDependentOn("BuildProject")
    .Does(() =>
    {
        MSBuild("./tests/CodeCoverage.Domain.Tests/CodeCoverage.Domain.Tests.csproj",
            new MSBuildSettings {
                Verbosity = Verbosity.Minimal,
                Configuration = "Debug"
            }
        );
    });

Task("OpenCover")
    .IsDependentOn("BuildTest")
    .Does(() =>
    {
        var openCoverSettings = new OpenCoverSettings()
        {
            Register = "user",
            SkipAutoProps = true,
            ArgumentCustomization = args => args.Append("-coverbytest:*.Tests.dll").Append("-mergebyhash")
        };

        var outputFile = new FilePath("./GeneratedReports/CodeCoverageReport.xml");

        OpenCover(tool => {
            var testAssemblies = GetFiles("./tests/CodeCoverage.Domain.Tests/bin/Debug/CodeCoverage.Domain.Tests.dll");
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
            HistoryDirectory = new DirectoryPath("./GeneratedReports/ReportsHistory")
        };

        ReportGenerator("./GeneratedReports/CodeCoverageReport.xml", "./GeneratedReports/ReportGeneratorOutput", reportGeneratorSettings);
    });

Task("Default")
    .IsDependentOn("ReportGenerator")
    .Does(() => {
        if (IsRunningOnWindows())
        {
            var reportFilePath = ".\\GeneratedReports\\ReportGeneratorOutput\\index.htm";

            StartProcess("explorer", reportFilePath);
        }
    });

RunTarget(target);