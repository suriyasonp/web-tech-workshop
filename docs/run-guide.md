# Run and Verify the Final Application

Use two terminals. The commands assume the repository root as the starting directory.

## 1. Backend

```bash
cd instructor/solutions/backend
dotnet restore
dotnet run --project TaskApi
```

Verify `http://localhost:5080/health` returns `{"status":"ok"}`.

## 2. Frontend

```bash
cd instructor/solutions/frontend
cp .env.example .env
npm install
npm run dev
```

Open `http://localhost:5173`, then use `instructor` / `Workshop2026!` for full CRUD.

## 3. Demo Path

1. Sign in and explain the JWT request/response.
2. Filter the seeded tasks by status.
3. Create a high-priority task with a due date.
4. Edit its status to `Done`.
5. Refresh to show SQLite persistence.
6. Delete the task as `Instructor`.
7. Sign in as `student` and show that delete is unavailable and protected by the API.

## 4. Automated Verification

```bash
dotnet test instructor/solutions/backend/WebTechWorkshop.sln
cd instructor/solutions/frontend
npm ci
npm run build
```

GitHub Actions runs the same backend build/tests and frontend production build on every push and pull request.

## Troubleshooting

- Port already in use: stop the old process or update both `launchSettings.json` and `.env`.
- Browser reports CORS: confirm the frontend is on `http://localhost:5173`.
- HTTP 401: log in again; the demo token expires after 120 minutes.
- Database schema issue: stop the API, remove only `instructor/solutions/backend/TaskApi/tasks.db`, then restart to apply migrations and seed data.
