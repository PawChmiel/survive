This file explains how Visual Studio created the project.

The following tools were used to generate this project:
- create-vite

The following steps were used to generate this project:
- Create react project with create-vite: `npm init --yes vite@latest survive.app -- --template=react-ts`.
- Update `vite.config.ts` to set up proxying and certs.
- Add `@type/node` for `vite.config.js` typing.
- Update `App` component to fetch and display weather information.
- Create project file (`survive.app.esproj`).
- Create `launch.json` to enable debugging.
- Create `nuget.config` to specify location of the JavaScript Project System SDK (which is used in the first line in `survive.app.esproj`).
- Add project to solution.
- Write this file.
