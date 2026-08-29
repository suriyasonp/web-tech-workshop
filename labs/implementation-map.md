# Lab-to-Implementation Map

The final code under `src/` is the source of truth when preparing and validating each lab.

| Lab | Final implementation reference | Completion check |
|---|---|---|
| 02–03 | `TaskApi/Program.cs`, `Endpoints/TaskEndpoints.cs` | API starts; GET returns 200 |
| 04 | `Services/TaskService.cs` | All REST-shaped CRUD paths exist |
| 05 | `Data/`, `Models/`, `Migrations/` | Restart retains tasks |
| 06 | `TaskRequestValidator` and problem responses | Invalid title returns 400 |
| 07 | `AuthEndpoints`, `TokenService`, JWT setup | Anonymous task request returns 401 |
| 08 | `TaskApi.Tests/` | `dotnet test` passes |
| 09 | `package.json`, `main.ts`, `App.vue` | Vite renders locally |
| 10 | `router/`, `AppShell.vue`, views | Client navigation and 404 work |
| 11 | `services/api.ts`, `taskService.ts` | Task list comes from backend |
| 12 | `authService.ts`, `stores/auth.ts`, route guard | Refresh preserves a valid session |
| 13 | `TasksView.vue`, `TaskForm.vue` | Full CRUD updates UI and API |
| 14 | `docs/run-guide.md` | Final demo path completes without manual data repair |

## API Contract Used by Labs

Task write payload:

```json
{
  "title": "Prepare final demo",
  "description": "Run the complete workshop flow",
  "status": "InProgress",
  "priority": "High",
  "dueDate": "2026-09-13"
}
```

Valid status values: `ToDo`, `InProgress`, `Done`. Valid priority values: `Low`, `Medium`, `High`.
