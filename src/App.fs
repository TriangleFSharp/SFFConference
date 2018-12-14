module App.View

open Elmish
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma


type Model = { size : float }

type Msg =
    | Increment
    | Decrement

let init () =
    { size = 32. }, Cmd.none

let update msg model =
    match msg with
    | Increment -> 
        { model with size = model.size * 2. }, Cmd.Empty
    | Decrement ->
        { model with size = model.size / 2. }, Cmd.Empty


let private view model dispatch =
    div [ ] [ 
        button [ OnClick (fun _ -> dispatch Increment) ] [ str "+" ]
        img [ Src "just_chicken.svg"; Style [Width model.size;] ]
        button [ OnClick (fun _ -> dispatch Decrement) ] [ str "-" ]
    ]

open Elmish.React
open Elmish.Debug
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Elmish.HMR


Program.mkProgram init update view
// |> Program.toNavigable (parseHash str) urlUpdate
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReact "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
