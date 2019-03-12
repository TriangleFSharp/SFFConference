module Speakers

open Fable.Helpers.React
open Fable.Helpers.React.Props
open System
open Fulma.FontAwesome
open Fulma

type Chirality = Left | Right
type SpeakerDetails = 
  {
    name: String
    icon: String
    talkTitle: String
    talkSummary: String
  }

let speakerImage pic chirality= 
  let mediaLR = 
    match chirality with
    | Left -> Media.left
    | Right -> Media.right
  Section.section [][
    mediaLR [CustomClass "speaker-frame" ] [
      Image.image [Image.Is1by1] [
          img[
            Src pic
            Class "speaker-pic"
          ]
      ]
    ]
  ]


let speaker chirality name pic talkTitle talkSummary =
  let middlePart = 
    Content.content [] [
        p [] [
          h1 [Class "title"] [str name]
          h2 [Class "sub-title"] [str talkTitle]
          str talkSummary
        ]
      ]
  match chirality with
  | Left ->
    Media.media [] [
      (speakerImage pic Left)
      middlePart
    ]
  | Right -> 
    Media.media [] [
      middlePart
      (speakerImage pic Right)
    ]

let speakerLeft speakerDetails =
  let {
        name = name; 
        icon = icon; 
        talkTitle = talkTitle; 
        talkSummary = talkSummary
        } = speakerDetails
  speaker Left name icon talkTitle talkSummary


let speakersList = [
  {
    name = "Steve Goguen"
    icon = "steve_goguen.jpg"
    talkTitle = "Prototyping & Modeling with F#"
    talkSummary = "For this session, we'll explore practical ways, for those new to F#, to create static and dynamic models, and we'll exploit the F# language and wonderful ecosystem of libraries and tools all along the way!"
  };
  {
    name = "Stachu Korick"
    icon = "stachu_korick.jpg"
    talkTitle = "Grappling the JavaScript Ecosystem with F# and Fable"
    talkSummary = "In this session, be prepared for a head-first overview of F#, how to compile it to JavaScript, and learn about how real businesses use F# to create full-stack mobile and web applications powered by Fable. You'll walk away with concrete next steps any road of success Fable can lead you on."
  };
  {
    name = "Marlon Vilorio"
    icon = "marlon_vilorio.jpg"
    talkTitle = "From C# to F#"
    talkSummary = "In this session, I will discuss some of the things we did at Pluralsight in order to make the transition to F# more flawless."
  };
    {
    name = "Olya Samusik"
    icon = "olya_samusik.jpg"
    talkTitle = "Solving 3D Problems With F#"
    talkSummary = "In this talk, I will do an overview of various challenges awaiting those who enter the world of three-dimensional graphics programming, focusing on how F# combined with the existing tools for desktop, web and native mobile can help to tackle these challenges. "
  };
  {
    name = "Luis Quintanilla"
    icon = "luis_quintanilla.jpg"
    talkTitle = "Getting Started with F# in Jupyter Notebooks"
    talkSummary = "In this talk we’ll explore the features of Jupyter Notebooks as well as how to get started using them with F#."
  };
  {
    name = "Brett Rowberry"
    icon = "brett_rowberry.jpg"
    talkTitle = "Creating a Unit Conversion Library"
    talkSummary = "One of the great parts of F# is making illegal states unrepresentable. Let’s see if we can make unit conversions you can’t mess up."
  };
  {
    name = "Eric Harding"
    icon = "eric_harding.jpg"
    talkTitle = "Authoring React Components with Fable"
    talkSummary = "Learn how to create a publishable NPM package which exposes a react component which can be used from a plain JavaScript project. No Fable dependencies needed by the consumer."
  };
  {
    name = "James Novino"
    icon = "james_novino.jpg"
    talkTitle = "Abstracting IO using F#"
    talkSummary = "This talk describes an approach to abstracting IO access patterns using F# and Domain Driven Design into a set of simple to use interfaces. The same interfaces abstract the complexity of the underlying infrastructure from business functionality while maintaining consistent behaviors around retries, error handling, and observability."
  };


]

let view =
  Section.section [] [
    Container.container 
      [Container.IsFluid] 
      (List.map speakerLeft speakersList)
  ]