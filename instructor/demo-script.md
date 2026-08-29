# Final Demo Script

Target: 12–15 minutes. Keep one browser window, one API terminal, and one frontend terminal visible.

| Time | Instructor action | Teaching point |
|---|---|---|
| 0:00–1:00 | Show architecture and both running terminals | One request crosses UI, service, API, EF Core, and SQLite |
| 1:00–2:30 | Sign in as `instructor` | Authentication proves identity; role controls permission |
| 2:30–5:00 | Create a task | Vue form → Axios → POST → validation → EF Core |
| 5:00–7:00 | Edit status and priority | PUT updates one resource; typed values match backend enums |
| 7:00–8:30 | Refresh the page | Data survives because SQLite persists it |
| 8:30–10:00 | Delete the task | UI permission and API authorization are separate controls |
| 10:00–12:00 | Trigger an empty-title error | Predictable 400 response becomes useful UI feedback |
| 12:00–15:00 | Trace one request in code and recap | Connect every lab to the final continuous application |

## Before Students Enter

- Run backend tests and frontend build.
- Start both applications and complete the demo once.
- Keep `checkpoint-backend-ready`, `checkpoint-auth-ready`, and `checkpoint-frontend-ready` available.
- Keep a pre-created `tasks.db` only as an offline fallback; normally let migrations create it.
