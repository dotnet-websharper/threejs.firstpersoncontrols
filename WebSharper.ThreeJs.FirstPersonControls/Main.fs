namespace FirstPersonControls

open WebSharper.InterfaceGenerator

module Definition =
    open WebSharper.ThreeJs
    open WebSharper.JavaScript.Dom

    let O = T<unit>

    let mainResource =
        Resource "FirstPersonControls" "FirstPersonControls.js"
        |> RequiresExternal [
            T<WebSharper.ThreeJs.Resources.Js>
        ]

    let FirstPersonControls =
        Class "THREE.FirstPersonControls"
        |+> Static [
            Constructor (T<THREE.Object3D>?``object`` * !? T<Element>?domElement)
        ]
        |+> Instance [
            "object"            =@ T<THREE.Object3D>
            "target"            =@ T<THREE.Vector3>
            "domElement"        =? T<Element>
            "movementSpeed"     =@ T<float>
            "lookSpeed"         =@ T<float>
            "lookVertical"      =@ T<bool>
            "autoForward"       =@ T<bool>
            "activeLook"        =@ T<bool>
            "heightSpeed"       =@ T<bool>
            "heightCoef"        =@ T<float>
            "heightMin"         =@ T<float>
            "heightMax"         =@ T<float>
            "constrainVertical" =@ T<bool>
            "verticalMin"       =@ T<float>
            "verticalMax"       =@ T<float>
            "autoSpeedFactor"   =@ T<float>
            "mouseX"            =? T<int>
            "mouseY"            =? T<int>
            "lat"               =@ T<float>
            "lon"               =@ T<float>
            "phi"               =@ T<float>
            "theta"             =@ T<float>
            "moveForward"       =@ T<bool>
            "moveBackward"      =@ T<bool>
            "moveLeft"          =@ T<bool>
            "moveRight"         =@ T<bool>
            "freeze"            =@ T<bool>
            "mouseDragOn"       =@ T<bool>
            "viewHalfX"         =@ T<float>
            "viewHalfY"         =@ T<float>

            "handleResize" => O ^-> O
            "update"       => T<float>?delta ^-> O
        ]
        |> Requires [
            mainResource
        ]

    let Assembly =
        Assembly [
            Namespace "WebSharper.ThreeJs.THREE" [
                 FirstPersonControls
            ]
            Namespace "WebSharper.ThreeJs.Resources" [
                 mainResource
            ]
        ]

[<Sealed>]
type Extension () =
    interface IExtension with
        member x.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()