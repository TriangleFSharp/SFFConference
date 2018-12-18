module Home
open Fable.Helpers.React
open Fable.Helpers.React.Props


// April; Maybe 13
let home dispatch = 
    div [] [ 
        button [] [ str "+" ]
        img [ Src "just_chicken.svg"; Style [ Width 64.] ]
        button [] [ str "-" ]
    ]