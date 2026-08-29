# Lab 02 — .NET Minimal API

## Objective
Create and run the backend skeleton.

## Starting Point
Checkout `lab-02-start` and work under `src/backend`.

## Steps
1. Create a .NET 10 web project named `TaskApi`.
2. Add OpenAPI support and map `GET /health`.
3. Configure the development URL as `http://localhost:5080`.
4. Run `dotnet run --project TaskApi`.

## Validation
`curl http://localhost:5080/health` returns HTTP 200 and `{"status":"ok"}`.

## Recovery
Checkout `lab-02-solution` and inspect `TaskApi.csproj`, `Program.cs`, and `launchSettings.json`.

## Expected Result
A runnable Minimal API with a visible health endpoint.
