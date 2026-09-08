# Lab 10 — Build Layout and Client-side Routing

**Duration:** 45 minutes  
**Goal:** Create an application shell and protected browser routes.

## Starting point

Continue in `student/starter/frontend` from Lab 09.

## Exercise 1 — Create views and routes

Create `src/views/LoginView.vue`, `TasksView.vue`, and `NotFoundView.vue`. In `src/router/index.ts`, define:

| Path | View | Rule |
|---|---|---|
| `/` | redirect | `/tasks` |
| `/login` | Login | public |
| `/tasks` | Tasks | requires auth |
| `/:pathMatch(.*)*` | Not Found | public |

Use lazy imports for views.

## Exercise 2 — Create the shell

Create `src/components/AppShell.vue` with application name, current identity placeholder, logout button, `<main>`, and `<RouterView />`. Use semantic HTML and visible keyboard focus.

## Exercise 3 — Add a temporary auth guard

Create a small auth-state module. Add `meta: { requiresAuth: true }` to Tasks and a `router.beforeEach` guard that redirects unauthenticated users to `/login?redirect=/tasks`.

For this lab, use a temporary boolean or stored placeholder; Lab 12 replaces it with a real session.

## Exercise 4 — Verify routes

Run `npm run dev`. Navigate with links (no full reload), paste `/tasks` while signed out, and visit `/does-not-exist`. Resize the browser to about 390 px wide.

## Check your work

Protected route redirects to Login, unknown route shows Not Found, and the layout does not overflow at narrow width.

## Troubleshooting / instructor recovery

Check that Vue Router is installed and `app.use(router)` runs before `mount`. Inspect `router/index.ts` and `AppShell.vue` in `instructor/solutions/frontend/`.

## Expected result

A reusable shell with predictable client-side navigation.
