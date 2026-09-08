# Lab 02 — Create a .NET 10 Minimal API

**Duration:** 35 minutes  
**Goal:** Create and run the backend with a health endpoint.

## Starting Point

Return to `main` and create the application in `student/starter/backend`.

## Exercise 1 — Scaffold the project

```bash
git switch main
mkdir -p student/starter/backend
cd student/starter/backend
dotnet new webapi -n TaskApi --framework net10.0 --use-minimal-apis
cd TaskApi
dotnet restore
```

Windows PowerShell supports `mkdir`; if the folder exists, continue.

## Exercise 2 — Add the first route

Open `Program.cs`. Keep OpenAPI registration and replace the sample weather route with:

```csharp
app.MapGet("/health", () => Results.Ok(new { status = "ok" }))
   .WithName("Health");
```

In `Properties/launchSettings.json`, set the HTTP application URL to `http://localhost:5080`.

## Exercise 3 — Run and call the API

Terminal 1:

```bash
dotnet run
```

Terminal 2 on macOS:

```bash
curl -i http://localhost:5080/health
```

Windows PowerShell:

```powershell
Invoke-RestMethod http://localhost:5080/health
```

Stop the server with `Ctrl+C`.

## Validation

The response is HTTP 200 with `{"status":"ok"}`. Run `dotnet build`; it must finish with zero errors.

## Recovery

If port 5080 is busy, stop the old `dotnet` process rather than changing the workshop port. Compare only `TaskApi.csproj`, `Program.cs`, and `launchSettings.json` with `instructor/solutions/backend/TaskApi/`.

## Expected result

A runnable .NET 10 Minimal API at `http://localhost:5080`.
