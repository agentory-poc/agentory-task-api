# agentory-task-api

Projects & Tasks REST API (MVP / PoC) built by the Agentory agents with C# / .NET 10, ASP.NET Core, EF Core (SQLite) and xUnit.

## Prerequisites

- .NET 10 SDK

## Build

```bash
dotnet restore
dotnet format --verify-no-changes
dotnet build -c Release
```

## Run

```bash
dotnet run --project src/Agentory.TaskApi
```

The API stores its data in a local SQLite file, `agentory.db` (connection string `ConnectionStrings:Default`, default `Data Source=agentory.db`). The database is created at startup and is never committed.

## Test

```bash
dotnet test
```

Integration tests run the API in memory with `WebApplicationFactory<Program>`, an in-memory SQLite database and a fake `TimeProvider`.

## Layout

- `Agentory.TaskApi.slnx`: solution
- `src/Agentory.TaskApi`: ASP.NET Core Web API (`net10.0`)
- `tests/Agentory.TaskApi.Tests`: xUnit tests (`net10.0`)
