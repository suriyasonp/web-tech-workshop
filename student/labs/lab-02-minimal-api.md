# Lab 02 — .NET Minimal API

## Objective
Create and run the backend skeleton.

## Starting Point
Use `main` and create the backend under `student/starter/backend`.

## Steps
1. Create a .NET 10 web project named `TaskApi`.
2. Add OpenAPI support and map `GET /health`.
3. Configure the development URL as `http://localhost:5080`.
4. Run `dotnet run --project TaskApi`.

## Validation
`curl http://localhost:5080/health` returns HTTP 200 and `{"status":"ok"}`.

## Recovery
Compare `TaskApi.csproj`, `Program.cs`, and `launchSettings.json` with `instructor/solutions/backend/TaskApi/`.

## Expected Result
A runnable Minimal API with a visible health endpoint.
