// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}
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
