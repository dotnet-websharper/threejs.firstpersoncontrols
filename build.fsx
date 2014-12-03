#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    (
        BuildTool().PackageId("WebSharper.ThreeJs.FirstPersonControls", "3.0-alpha")
        |> fun bt ->
            bt.WithFramework bt.Framework.Net40
    )
        .References (fun r ->
            [
                r.NuGet("WebSharper.ThreeJs").Reference()
            ]
        )

let main =
    (
        bt.WebSharper.Extension "IntelliFactory.WebSharper.ThreeJs.FirstPersonControls"
        |> FSharpConfig.BaseDir.Custom "FirstPersonControls"
    )
        .SourcesFromProject("FirstPersonControls.fsproj")
        .Embed [
            "FirstPersonControls.js"
        ]

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
