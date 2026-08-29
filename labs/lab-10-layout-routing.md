# Lab 10 — Layout and Routing

## Objective
Build a stable application shell and client routes.

## Starting Point
Checkout `lab-10-start`.

## Steps
1. Add routes for Login, Tasks, and Not Found.
2. Redirect `/` to `/tasks`.
3. Create `AppShell` with identity and logout controls.
4. Add a navigation guard using authentication state.
5. Confirm responsive behavior at narrow width.

## Validation
Navigation changes views without reload; unauthenticated `/tasks` redirects to `/login`; unknown routes show 404.

## Recovery
Checkout `lab-10-solution` and inspect `router/index.ts` and `AppShell.vue`.

## Expected Result
A reusable shell with protected client-side navigation.
