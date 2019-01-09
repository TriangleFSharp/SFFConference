module Venue

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop
open Fable.Core
open Fulma

[<AutoOpen>]
module Leaflet =
  type MapProp =
    | Center of float*float
    | Zoom of float
    | ClassName of string

  let map (props:MapProp list) children = 
    ofImport "Map" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

  type TileLayerProp =
  | Url of string
  | Attribution of string
  let tileLayer () =
    let props = [
      Url "http://{s}.tile.osm.org/{z}/{x}/{y}.png"
      Attribution "&copy; <a href=\"http://osm.org/copyright\">OpenStreetMap</a> contributors"
    ]
    ofImport "TileLayer" "react-leaflet" (keyValueList CaseRules.LowerFirst props) []

  type MarkerProp =
  | Position of float*float
  let marker (props:MarkerProp list) children =
    ofImport "Marker" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

  let popup children =
    ofImport "Popup" "react-leaflet" () children


let hotel name link =
  Media.media [] [
    Media.left [] [
      i [Class "fas fa-hotel"] []
    ]
    Media.content [] [
      a [Href link] [
        Heading.h5 [] [ str name ]
      ]
    ]
  ]

let view =
  let pos = 35.77502, -78.63811
  div [] [
    Leaflet.map [ Center pos; Zoom 18.] [
      tileLayer ()
      marker [ Position pos ] [
        popup [
          div [Style [ FontWeight "bold"]][str "Red Hat"]
          div [] [str "100 East Davie Street"]
          div [] [str "Raleigh, North Carolina 27601"]
        ]
      ]
    ]
    Section.section [] [
      Heading.h1 [] [
        str "Venue"
      ]
      str "Southern Fried F# is being held at " 
      a [ Href "https://www.redhat.com/en/about/videos/inside-red-hats-raleigh-headquarters"] [str "Red Hat global headquarters"]
      str " in downtown Raleigh North Carolina."
    ]
    Section.section [] [
      Heading.h3 [ Heading.IsSubtitle] [
        str "Accommodation"
      ]
      hotel "Raleigh Marriott City Center" "https://www.google.com/maps/place/Raleigh+Marriott+City+Center/@35.774974,-78.6421814,17z/data=!4m5!3m4!1s0x89ac5f715804d045:0xf512109c25af5aea!8m2!3d35.7735791!4d-78.6399557"
      hotel "Sheraton Raleigh" "https://www.google.com/maps/place/Sheraton+Raleigh+Hotel/@35.774974,-78.6421814,17z/data=!4m5!3m4!1s0x89ac5f717b90484d:0x91190ab641cc99a7!8m2!3d35.77497!4d-78.6399929"
      hotel "Holiday Inn" "https://www.google.com/maps/place/Holiday+Inn+Raleigh+Downtown/@35.7769051,-78.6443635,16.25z/data=!4m5!3m4!1s0x89ac5f6f98fac369:0xebc5bc60334731e7!8m2!3d35.7810101!4d-78.644094"
    ]
    // Alternative Food?
  ]
