module Venue

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop
open Fable.Core

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
  ]
