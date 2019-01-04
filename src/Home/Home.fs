module Home
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
// April; Maybe 13
let home dispatch = 
  Hero.hero [] [ 
    Hero.body [] [
      Columns.columns [Columns.IsCentered ] [ 
        Column.column [Column.Width (Screen.All , Column.IsOneThird)]
          [Image.image [  ] [img [ Src "sfflogo_large.png";]]]
      ]   
      Container.container [ Container.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ] [ 
        Heading.h1 [ ]
          [ str "April 13th" ]
        Heading.h2 [ Heading.IsSubtitle ]
          [ str "Raleigh, NC" ] 
        p[] 
          [str "Southern Fried F# is a free, full-day conference full of talks"]
        p[] 
          [str "Keep checking here for updates, and check out the site code on github"]
      ]
    ]    
  ]