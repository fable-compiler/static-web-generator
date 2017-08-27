module Fable.StaticPageGenerator.Main

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.PowerPack
open System.Text.RegularExpressions
open Helpers

type IPerson =
    abstract firstName: string
    abstract familyName: string
    abstract birthday: string

// Make sure to always resolve paths to avoid conflicts in generated JS files
// Check fable-splitter README for info about ${entryDir} macro

let templatePath = resolve "${entryDir}/../templates/template.hbs"
let markdownPath = resolve "${entryDir}/../README.md"
let dataPath = resolve "${entryDir}/../data/people.json"
let indexPath = resolve "${entryDir}/../public/index.html"

let createTable() =
    let people = readFile dataPath |> JS.JSON.parse |> unbox<IPerson array>
    table [ClassName "table"] [
        thead [] [
            tr [] [
                th [] [str "First Name"]
                th [] [str "Family Name"]
                th [] [str "Birthday"]
            ]
        ]
        tbody [] [
            for person in people do
                yield tr [] [
                    td [] [str person.firstName]
                    td [] [str person.familyName]
                    td [] [str person.birthday]
                ]
        ]
    ]

let render() =
    [ "title" ==> "My page"
      "body" ==> parseMarkdown markdownPath
      "data" ==> (createTable() |> parseReactStatic) ]
    |> parseTemplate templatePath
    |> writeFile indexPath

render()
