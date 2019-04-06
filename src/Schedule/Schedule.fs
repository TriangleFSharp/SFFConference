module Schedule
open System
open Fable.PowerPack.Date.Local
open Fulma 
open Fable.Helpers
open React 

type Talk = {title : string; speaker: string ;duration: TimeSpan}
let hour = TimeSpan(1,0,0)

let talks =  [
    {speaker="Steve Goguen"; title="Prototyping & Modeling with F#"; duration= hour}
    {speaker="Stachu Korick"; title="Grappling the JavaScript Ecosystem with F# and Fable";  duration= hour}
    {speaker="James Novino"; title="Abstracting IO using F#";  duration= hour}
    {speaker=""; title="Lunch"; duration=TimeSpan(0,45,0)}
    {speaker="Brett Rowberry"; title="Creating a Unit Conversion Library"; duration=TimeSpan(0,15,0)}
    {speaker="Olya Samusik"; title="Solving 3D Problems With F#";  duration= hour}
    {speaker="Luis Quintanilla"; title="Getting Started with F# in Jupyter Notebooks";  duration= hour}
    {speaker="Eric Harding"; title="Getting Started with F# in Jupyter Notebooks";  duration= hour}
    {speaker="Marlon Vilorio"; title="From C# to F#";  duration= hour}
]

let scheduleItem title speaker time = 
        tr [] [
            td [] [str title]
            td [] [str speaker]
            td [] [str time]
        ]
let scheduleHeader =
    thead [] [
        tr [][th [][str "Title"]]
        tr [][th [][str "Speaker"]]
        tr [][th [][str "Time"]]
    ]
let rec buildSchedule talks (startTime: DateTime)= 
    match talks with
    | [] -> []
    | {speaker=speaker; title=title; duration=duration} :: t -> 
        (scheduleItem title speaker (startTime.ToShortTimeString()) ):: buildSchedule t (startTime + duration)
let view =
    Table.table [] [
        scheduleHeader
        tbody [] (buildSchedule talks (DateTime(4,13,19,9,0,0,DateTimeKind.Local)))
    ]