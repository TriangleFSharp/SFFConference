module Speakers

open Fable.Helpers.React
open Fable.Helpers.React.Props

let speaker pic name =
  div [Class "speaker"] [
    div [Class "speaker-frame"] [
      div[
        Class "speaker-pic"
        Style [
          BackgroundImage pic
        ]
      ] [
        // img [Src pic]
      ]
    ]
    div [] [
      str name
    ]
  ]

let view =
  div [] [
    div [] [
      speaker "http://placekitten.com/300/301" "Itchy"
      speaker "http://placekitten.com/301/300" "Scratchy"
      speaker "http://placekitten.com/300/300" "Monad"
    ]
  ]