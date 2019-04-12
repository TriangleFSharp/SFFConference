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

let paypal = 
  form [ Action "https://www.paypal.com/cgi-bin/webscr"
         Method "post"
         Target "_top" ]
      [ input [ Type "hidden"
                Name "cmd"
                Value "_donations" ]
        input [ Type "hidden"
                Name "business"
                Value "8D2V3G4AEGENJ" ]
        input [ Type "hidden"
                Name "currency_code"
                Value "USD" ]
        input [ Type "image"
                Src "https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif"
                HTMLAttr.Custom ("border", "0")
                Name "submit"
                Title "PayPal - The safer, easier way to pay online!"
                Alt "Donate with PayPal button" ]
        img [ Alt ""
              HTMLAttr.Custom ("border", "0")
              Src "https://www.paypal.com/en_US/i/scr/pixel.gif"
              HTMLAttr.Custom ("width", "1")
              HTMLAttr.Custom ("height", "1") ] ]

//uncomment the navbar items as we add content for the pages
let navBar =
  Navbar.navbar [Navbar.Color IsPrimary; Navbar.Option.Props [Role "navigation"]] [ 
    Navbar.Item.a  [ Navbar.Item.Props [Href "#home" ]] [ str "Home" ]
    Navbar.Item.a [ Navbar.Item.Props[Href "#speakers"]  ] [ str "Speakers" ]
    Navbar.Item.a [ Navbar.Item.Props[Href "#schedule"]  ] [ str "Schedule" ]
    Navbar.Item.a [ Navbar.Item.Props[Href "https://www.eventbrite.com/e/southern-fried-f-tickets-54591291021"]  ] [ str "Tickets" ]
    Navbar.Item.a [ Navbar.Item.Props[Href "#venue"]  ] [str "Venue" ]
    Navbar.End.div [] [
      Navbar.Item.div [ ] [
        Button.a [ Button.Props [Href "https://twitter.com/friedfsharp"]] [
          i [ Class "fab fa-twitter"] [str " Share"]
        ]
      ]
      Navbar.Item.div [ ] [
        Button.a [Button.Props [Href "https://github.com/TriangleFSharp/SFFConference"]] [
          i [ Class "fab fa-github"] [str " Contribute"]
        ]
      ]
      Navbar.Item.div [ ] [
        paypal
      ]

    ]
  ]

let footer =
  Footer.footer [] [
    Level.level [] [
      Level.item [] [
        a [Href "http://foundation.fsharp.org/code_of_conduct"] [ str "Code of Conduct"]
      ]
      Level.item [] [
        Image.image [ Image.Is32x32 ] [
          img [Src "sandwich.png"; Class "chicken-sandwich"]
        ]
      ]
      Level.item [] [
        str "Questions?"
        a [ Href "mailto:contact@southernfriedfsharp.com"
            Style [ Margin "5px" ] ] 
            [ str "Contact us"]
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
  | Venue -> Venue.view
  | Speakers -> Speakers.view
  | Schedule -> Schedule.view
  | _ -> placeholder


let private view (model:Model) (dispatch:Dispatch<Msg>) =
  div [] [
    navBar
    content model.page dispatch
    footer
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
