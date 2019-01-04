module Home
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
// April; Maybe 13
let home dispatch = 
  Hero.hero [] [ 
    Hero.body [] [
      Columns.columns [ ] [ 
        Column.column [ Column.Width (Screen.All, Column.Is3) ] [
          Column.column [ ] [Image.image [ Image.IsSquare  ] [img [ Src "sfflogo_large.png";]]]
        ]   
      ]    
    ]
  ]