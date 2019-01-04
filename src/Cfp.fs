module Cfp
open Fable.Helpers.React
open Fable.Helpers.React.Props

let view =
    div [ Class "main-container" ] [
        form [ Action "http://formspree.io/contact@southernfriedfsharp.com"; Method "POST"] [
            input [Type "Text"; Name "name"; Placeholder "Name"]
            br []
            input [Type "Email"; Name "_replyto"; Placeholder "Email"]
            br []
            textarea [Type "text"; Name "message"; Placeholder "Test Message"; Cols 4] []
            br []
            input [Type "submit"; Value "Send"; ClassName "button is-success" ]
        ]
    ]