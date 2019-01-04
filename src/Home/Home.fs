module Home
open Fable.Helpers.React
open Fable.Helpers.React.Props

// April; Maybe 13
let home dispatch = 
    div [ ClassName "awful"] [ 
        img [ Src "sfflogo_large.png"; Style [ Width 64.] ]
        div [ClassName "red"; Style [Width 64.; Height 64. ]] []
        div[] [
            button [ClassName "button is-primary"] [str "a button"]
            str " primary"
        ]
        div [] [
            button [ClassName "button is-link"] [str "a button"]
            str " link"
        ]
        div [] [
            button [ClassName "button is-info"] [str "a button"]
            str " info"
        ]
        div [] [
            button [ClassName "button is-success"] [str "a button"]
            str " success"
        ]
        div [] [
            button [ClassName "button is-warning"] [str "a button"]
            str " warning"
        ]
        div [] [
            button [ClassName "button is-danger"] [str "a button"]
            str " danger"
        ]
        div [] [
            button [ClassName "button is-dark"] [str "a button"]
            str " dark"
        ]
    ]