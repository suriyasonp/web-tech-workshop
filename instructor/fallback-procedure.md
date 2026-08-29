# Backup and Fallback Procedure

## Student Recovery

1. Commit or copy the student’s current work.
2. Identify the last completed lab.
3. Compare with the matching solution checkpoint when available.
4. For a blocked room, move everyone to the nearest milestone checkpoint and continue.

## Service Failure

- Backend unavailable: teach frontend routing/components with a temporary local task array.
- Frontend unavailable: continue API exercises with `TaskApi.http` or any REST client.
- NuGet/npm unavailable: use an instructor machine with restored dependencies and share the running URLs on the local network.
- GitHub unavailable: distribute a prepared repository archive and record commits locally.

## Data Reset

Stop the API, delete only `src/backend/TaskApi/tasks.db`, and restart. Migrations recreate the database and seed two tasks.

Never ask students to delete the repository when a targeted reset is sufficient.
