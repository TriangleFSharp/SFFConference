module App.View

open Elmish
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma

type Page =
    | Home
    | Speakers
    | Schedule
    | Tickets
    | Venue
    | Cfp

type Route = Blog of int | Search of string

type Model = { page : Page }

type Msg =
    | Increment

let urlUpdate loc model =
    match loc with
    | Some l -> { model with page = l}, Cmd.none
    | None -> model, Cmd.none

let init loc =
    urlUpdate loc { page = Home }

let update msg model =
    model, Cmd.Empty

let private view (model:Model) (dispatch:Dispatch<Msg>) =
    div [] [ 
        button [ OnClick (fun _ -> dispatch Increment) ] [ str "+" ]
        img [ Src "just_chicken.svg"; Style [] ]
        button [ OnClick (fun _ -> dispatch Increment) ] [ str "-" ]
    ]

open Elmish.React
open Elmish.Debug
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Elmish.HMR


let parser =
    oneOf [
        map Home (s "home")
        map Speakers (s "speakers")
        map Schedule (s "schedule")
        map Tickets (s "tickets")
        map Venue (s "venue")
        map Cfp (s "callforpapers")
    ]


//WOAH TYPE MISMATCH HERE
Program.mkProgram init update view
|> Program.toNavigable (parseHash parser) urlUpdate
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReact "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
