module Speakers

open Fable.Helpers.React
open Fable.Helpers.React.Props

let speaker right name pic talkTitle talkSummary =
  article [Class "media"] [
    if right = false then 
      yield figure [Class "media-left"] [
        p [Class "image is-256x256"] [
          div [Class "speaker-frame"] [
            div[
              Class "speaker-pic"
              Style [
                BackgroundImage (sprintf "url(%s)" pic)
              ]
            ] []
          ]
        ]
      ]
    yield div [Class "media-content"] [
      div [Class "content"] [
        p [] [
          h1 [Class "title"] [str name]
          h2 [Class "sub-title"] [str talkTitle]
          str talkSummary
        ]
      ]
    ]
    if right = true then
      yield figure [Class "media-right"] [
        p [Class "image is-256x256"] [
          div [Class "speaker-frame"] [
            div[
              Class "speaker-pic"
              Style [
                BackgroundImage (sprintf "url(%s)" pic)
              ]
            ] []
          ]
        ]
      ]
  ]

let speakerLeft = speaker false
let speakerRight = speaker true

let foremFipsum = "Fexplicabo faborum flaceat frchitecto ft felectus.  fmet folestiae finus ft fn fum fuo facilis fst.  fuas fuasi fossimus fit.  fa foloremque fatus folores fd funt fuidem ficta.  fos fst fsperiores fssumenda faudantium foluptas foluptatem f#"

let view =
  div [] [
    div [Class "container"] [
      speakerLeft 
        "Itchy" 
        "http://placekitten.com/300/301" 
        "Screwing Around with F#"
        foremFipsum
      speakerRight 
        "Scratchy"
        "http://placekitten.com/301/300" 
        "Maybe... you need a type system"
        foremFipsum
      speakerLeft 
        "Monad"
        "http://placekitten.com/300/300" 
        "F# because it's NOT javascript"
        foremFipsum
    ]
  ]