module App.View

open Elmish
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fable.Core.JsInterop

importAll "./style.scss"

type Page =
  | Home
  | Speakers
  | Schedule
  | Tickets
  | Venue
  | Cfp

type Route = Blog of int | Search of string

type Model = { page : Page }

type Msg = unit
let urlUpdate loc model =
  printfn "%A" loc
  match loc with
  | Some l -> { model with page = l}, Cmd.none
  | None -> model, Cmd.none

let init loc =
  urlUpdate loc { page = Home }

let update msg model =
  model, Cmd.Empty

//uncomment the navbar items as we add content for the pages
let navBar =
  Navbar.navbar [Navbar.Color IsPrimary; Navbar.Option.Props [Role "navigation"]] [ 
    Navbar.Item.a  [ Navbar.Item.Props [Href "#home" ]] [ str "Home" ]
    //Navbar.Item.a [ Navbar.Item.Props[Href "#speakers"]  ] [ str "Speakers" ]
    //Navbar.Item.a [ Navbar.Item.Props[Href "#venue"]  ] [ str "Venue" ]
    //Navbar.Item.a [ Navbar.Item.Props[Href "#schedule"]  ] [ str "Schedule" ]
    //Navbar.Item.a [ Navbar.Item.Props[Href "#tickets"]  ] [ str "Tickets" ]
    Navbar.Item.a [ Navbar.Item.Props[Href "https://sessionize.com/southern-fried-fsharp"]  ] [ str "Call for Speakers" ]
    Navbar.End.div [] [
      Navbar.Item.div [ ] [
        Button.a [Button.Props [Href "#"]] [
          i [ Class "fab fa-twitter"] [str " Share"]
        ]
      ]
      Navbar.Item.div [ ] [
        Button.a [Button.Props [Href "https://github.com/TriangleFSharp/SFFConference"]] [
          i [ Class "fab fa-github"] [str " Contribute"]
        ]
      ]

    ]
  ]

let placeholder = 
  Hero.hero [Hero.Color IsInfo] [
    Hero.body [] [
      Heading.h2 [Heading.IsSubtitle ] [str "Updates coming soon"]
    ]
  ]

let content page dispatch =
  match page with
  | Home -> Home.home dispatch
  | Cfp -> Cfp.view
  | _ -> placeholder


let private view (model:Model) (dispatch:Dispatch<Msg>) =
  div [] [
    navBar
    content model.page dispatch
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
    map Cfp (s "cfp")
  ]


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
