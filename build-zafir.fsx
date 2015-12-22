#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("Zafir.ThreeJs.FirstPersonControls")
        .VersionFrom("Zafir")
        .WithFSharpVersion(FSharpVersion.FSharp30)
        .WithFramework(fun fw -> fw.Net40)

let main =
    bt.Zafir.Extension("WebSharper.ThreeJs.FirstPersonControls")
        .SourcesFromProject()
        .Embed(["FirstPersonControls.js"])
        .References(fun r ->
            [
                r.NuGet("Zafir.ThreeJs").Latest(true).ForceFoundVersion().Reference()
            ]
        )

bt.Solution [
    main

    bt.NuGet.CreatePackage()
        .Configure(fun c ->
            { c with
                Title = Some "Zafir.ThreeJs.FirstPersonControls"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://bitbucket.org/intellifactory/websharper.threejs.firstpersoncontrols"
                Description = "WebSharper Extensions for ThreeJs.FirstPersonControls 20140124"
                Authors = ["IntelliFactory"]
                RequiresLicenseAcceptance = true
            }
        )
        .Add(main)
]
|> bt.Dispatch
