module Main

open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open StaticWebGenerator
open Fulma

type IPerson =
    abstract firstName: string
    abstract familyName: string
    abstract birthday: string

// Make sure to always resolve paths to avoid conflicts in generated JS files
// Check fable-splitter README for info about ${entryDir} macro

let markdownPath = IO.resolve "${entryDir}/../README.md"
let dataPath = IO.resolve "${entryDir}/../data/people.json"
let indexPath = IO.resolve "${entryDir}/../deploy/index.html"

let createTable() =
    let createHead (headers: string list) =
        thead [] [
            tr [] [for header in headers do
                    yield th [] [str header]]
        ]
    let people =
        IO.readFile dataPath
        |> JS.JSON.parse
        |> unbox<IPerson array>
    div [] [
        hr []
        p [] [str """The text above has been parsed from markdown,
                the table below is generated from a React component."""]
        br []
        Table.table [ Table.IsStriped ] [
            createHead ["First Name"; "Family Name"; "Birthday"]
            tbody [] [
                for person in people do
                    yield tr [] [
                        td [] [str person.firstName]
                        td [] [str person.familyName]
                        td [] [str person.birthday]
                    ]
            ]
        ]
    ]

let frame titleText content data =
    let cssLink path =
        link [ Rel "stylesheet"; Type "text/css"; Href path ]
    html [] [
        head [] [
            yield title [] [str titleText]
            yield meta [ HTMLAttr.Custom ("httpEquiv", "Content-Type")
                         HTMLAttr.Content "text/html; charset=utf-8" ]
            yield meta [ Name "viewport"
                         HTMLAttr.Content "width=device-width, initial-scale=1" ]
            yield cssLink "https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"
            yield cssLink "https://cdnjs.cloudflare.com/ajax/libs/bulma/0.5.1/css/bulma.min.css"
        ]
        body [] [
            Fulma.Container.container [] [
                content
                data
            ]
        ]
    ]

let render() =
    let content =
        IO.readFile markdownPath
        |> parseMarkdownAsReactEl "content"
    let data =
        createTable()
    frame "My page" content data
    |> parseReactStatic
    |> IO.writeFile indexPath
    printfn "Render complete!"

render()
