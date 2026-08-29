# Environment Setup Guide

Complete this before 12 September 2026. The workshop uses local development only; Docker is optional.

## Required

- VS Code
- Git 2.40 or newer
- GitHub account with repository access
- .NET 10 SDK
- Node.js 20 LTS or newer and npm
- Chrome, Edge, or another modern browser

Recommended VS Code extensions: C# Dev Kit, Vue Official, REST Client, and GitHub Pull Requests.

## Verification

```bash
git --version
dotnet --version
node --version
npm --version
```

Then clone and validate the materials:

```bash
git clone https://github.com/suriyasonp/web-tech-workshop.git
cd web-tech-workshop
git switch workshop-materials
bash scripts/validate-materials.sh
```

## Application Readiness

Backend:

```bash
dotnet restore src/backend/WebTechWorkshop.sln
dotnet test src/backend/WebTechWorkshop.sln
```

Frontend:

```bash
cd src/frontend
npm ci
npm run build
```

## Network Requirements

The machine must reach GitHub, NuGet, and npm during setup. During delivery, the prepared lock file, recovery refs, and repository archive reduce dependency on live network access.

## Ports

- Backend: `http://localhost:5080`
- Frontend: `http://localhost:5173`

If either port is blocked, stop the existing process before changing workshop configuration.
