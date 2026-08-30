# Lab 12 — Frontend Login

## Objective
Complete the browser authentication flow.

## Starting Point
Continue from your Lab 11 application under `student/starter/`.

## Steps
1. Build the Login view.
2. Call `/api/auth/login` through `authService`.
3. Store the session with its expiration time.
4. Attach the Bearer token in the Axios interceptor.
5. Redirect expired/unauthorized sessions to login.
6. Implement logout.

## Validation
Login reaches `/tasks`, refresh preserves a valid session, and logout returns to `/login`.

## Recovery
Inspect `authService`, `authStore`, and the router guard under `instructor/solutions/frontend/`.

## Expected Result
A working authenticated frontend with understandable workshop token handling.
