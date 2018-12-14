module App.View

open Elmish
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma


type Model = { counter : int }

type Msg =
    | Increment
    | Decrement

let init () =
    { counter = 0 }, Cmd.none

let update msg model =
    match msg with
    | Increment -> 
        { model with counter = model.counter + 1 }, Cmd.Empty
    | Decrement ->
        { model with counter = model.counter - 1 }, Cmd.Empty


let private view model dispatch =
    div [ ] [ 
        button [ OnClick (fun _ -> dispatch Increment) ] [ str "+" ]
        str (string model.counter)
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
