# Fable Static Page Generator

Simple Fable Node.js app to generate static pages.The main advantages of this approach are:

- Use the same **React API** that you use on the frontend with [Fable.Elmish](https://fable-elmish.github.io/)
- Use **Fable helpers** for UI, like [Fulma](https://mangelmaxime.github.io/Fulma/)
- Access to all **npm packages**, like [marked](https://www.npmjs.com/package/marked) or [handlebars](http://handlebarsjs.com/)

This is just a quick experiment to see how a static site can be generated using Fable. If you're looking for a more opinionated tool that uses F# on .NET, check [Fornax](https://gitlab.com/Krzysztof-Cieslak/Fornax).

## Requirements

- [dotnet SDK](https://www.microsoft.com/net/download/core) 2.0 or higher
- [node.js](https://nodejs.org) 6.11 or higher

> Although it's not a Fable requirement, on macOS and Linux you'll need [Mono](http://www.mono-project.com/) for other F# tooling like Paket or editor support.

## Installing and building

- [Clone this repository](https://github.com/fable-compiler/static-page-generator/)
- Install JS dependencies: `npm install`
- **Move to src folder**: `cd src`
- Install F# dependencies: `dotnet restore`

To generate the web page, _still in src folder_ (where the .fsproj is), run `dotnet fable npm-start`. This will start Fable in watch mode, so any time you edit one of the F# files, the page(s) will be generated again. If you just want to run Fable once, use `dotnet fable npm-build` instead.

The web pages will be output to `public` directory. To start a static server to display them in a browser, _in a new terminal and from the repo root_, run `npm run server`. To publish the web pages into gh-pages branch, run `npm run publish`.
