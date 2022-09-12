# README file

## 1. Problem definition

please read [NET_-_Martian_Robots_Updated.pdf](NET_-_Martian_Robots_Updated.pdf) file

## 2. Running the solver - CLI

run project MartianRobots.Web.Server
local dev computer - CLI

```sh
dotnet run --project .\MartianRobots.Web\Server\MartianRobots.Web.Server.csproj
```

then browse <http://localhost:5003>

## 3. Running the solver - Docker

```sh
docker run -p 5050:80 --name martianrobots clodyx/martianrobotswebserver
```

## 4. Projects structure

	MartianRobotsSolver - problem solver library
	MartianRobotsSolver.Tests - unit tests for solver
	MartianRobots.Api -  a simple web api for quick use
	MartianRobots.Web.Server - blazor WASM app with .net web api
	MartianRobots.Web.Client - WASM app for blazor
	MartianRobots.Web.Shared - shared project for blazor
