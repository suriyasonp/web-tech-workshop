# Lab 12 — Implement Browser Login

**Duration:** 55 minutes  
**Goal:** Login, retain a valid workshop session, attach its Bearer token, and logout.

## Starting Point

Continue from Lab 11 with both applications running.

## Exercise 1 — Add auth service and state

Create `src/services/authService.ts` to POST `/api/auth/login`. Create `src/stores/authStore.ts` (a simple reactive module is sufficient) that stores token, expiry, display name, and role.

Persist one JSON session value in `sessionStorage`. On startup, restore it only when its expiry is in the future.

## Exercise 2 — Build Login view

Add username/password fields, submit button, busy state, and an accessible error alert. On success, save the session and route to the `redirect` query value or `/tasks`.

Do not display the password in logs or error messages.

## Exercise 3 — Attach and reject tokens centrally

In the Axios request interceptor:

```ts
config.headers.Authorization = `Bearer ${authStore.token}`
```

Only add it when a token exists. In the response interceptor, clear session and route to Login for 401. Avoid redirect loops when the failed request is the login request.

## Exercise 4 — Logout and expiry test

Logout must clear storage and route to `/login`. Test: login → refresh → Tasks remains available → logout → Tasks redirects. Temporarily change stored expiry to the past and refresh.

## Validation

Valid session survives refresh; expired session does not; logout removes the token; authenticated Task GET returns 200.

## Recovery

Inspect `sessionStorage`, the request's Authorization header, and API response in DevTools. Compare `authService`, `authStore`, and router guard with `instructor/solutions/frontend/`.

## Expected result

A complete workshop authentication flow with centralized token handling.
