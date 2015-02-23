#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("WebSharper.ThreeJs.FirstPersonControls", "3.0-alpha")
    |> fun bt -> bt.WithFramework bt.Framework.Net40

let main =
    bt.WebSharper.Extension("WebSharper.ThreeJs.FirstPersonControls")
        .SourcesFromProject()
        .Embed(["FirstPersonControls.js"])
        .References(fun r ->
            [
                r.NuGet("WebSharper.ThreeJs").Reference()
            ]
        )

bt.Solution [
    main

    bt.NuGet.CreatePackage()
        .Configure(fun c ->
            { c with
                Title = Some "WebSharper.ThreeJs.FirstPersonControls"
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
