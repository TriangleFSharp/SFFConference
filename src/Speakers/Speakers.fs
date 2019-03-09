module Speakers

open Fable.Helpers.React
open Fable.Helpers.React.Props

let speakerLeft name pic subject =
  div [Class "speaker"] [
    div [Class "speaker-frame"] [
      div[
        Class "speaker-pic"
        Style [
          BackgroundImage (sprintf "url(%s)" pic)
        ]
      ] []
    ]
    div [] [
      str name
    ]
  ]

let view =
  div [] [
    div [] [
      speakerLeft 
        "Itchy" 
        "http://placekitten.com/300/301" 
        "PROTOTYPING & MODELING WITH F#"
      speakerLeft 
        "Scratchy"
        "http://placekitten.com/301/300" 
        "F# for game development"
      speakerLeft 
        "Monad"
        "http://placekitten.com/300/300" 
        "F# because it's not javascript"
    ]
  ]