# Lab 12 — Frontend Login

## Objective
Complete the browser authentication flow.

## Starting Point
Checkout `lab-12-start`.

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
Checkout `lab-12-solution` and inspect `authService`, `authStore`, and the router guard.

## Expected Result
A working authenticated frontend with understandable workshop token handling.
