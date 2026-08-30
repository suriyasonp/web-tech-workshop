# Backup and Fallback Procedure

## Student Recovery

1. Commit or copy the student’s current work under `student/starter/`.
2. Identify the last completed lab.
3. Compare only the blocked part with `instructor/solutions/`.
4. For a blocked room, copy the relevant instructor solution files into a temporary recovery folder, then continue on `main`.

## Service Failure

- Backend unavailable: teach frontend routing/components with a temporary local task array.
- Frontend unavailable: continue API exercises with `TaskApi.http` or any REST client.
- NuGet/npm unavailable: use an instructor machine with restored dependencies and share the running URLs on the local network.
- GitHub unavailable: distribute a prepared repository archive and record commits locally.

## Data Reset

Stop the API, delete only `instructor/solutions/backend/TaskApi/tasks.db`, and restart. Migrations recreate the database and seed two tasks.

Never ask students to delete the repository when a targeted reset is sufficient.
