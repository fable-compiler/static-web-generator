# Static Web Generator

Simple Fable Node.js app to generate static pages.The main advantages of this approach are:

- Use the same **React API** that you use on the frontend with [Elmish](https://elmish.github.io/).
- Use **Fable helpers** for UI, like [Fulma](https://mangelmaxime.github.io/Fulma/).
- Access to all **npm packages**, like [marked](https://www.npmjs.com/package/marked) or [highlight.js](https://www.npmjs.com/package/highlight.js).

## Requirements

- [dotnet SDK](https://www.microsoft.com/net/download/core)
- [node.js](https://nodejs.org)
- [yarn](https://yarnpkg.com/en/)

> On macOS and Linux you'll need [Mono](http://www.mono-project.com/) to run Paket.

## Installing and building

- [Clone this repository](https://github.com/fable-compiler/static-web-generator/)
- Install dependencies: `yarn`
- Start compilation and live server: `yarn start`

To start your own website, use this project as scaffold. You can also take advantage of [Paket Github dependencies](https://fsprojects.github.io/Paket/github-dependencies.html) to link `src/Helpers` from your project and get new additions more easily. For a more comprehensive example check the [Fable website](https://github.com/fable-compiler/fable-compiler.github.io).
