# Lab 10 — Build Layout and Client-side Routing

**Duration:** 45 minutes  
**Goal:** Create an application shell and protected browser routes.

## Starting Point

Continue in `student/starter/frontend` from Lab 09.

## Exercise 1 — Create views and routes

Create `src/views/LoginView.vue`, `TasksView.vue`, and `NotFoundView.vue`. In `src/router/index.ts`:

```ts
import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: '/', redirect: '/tasks' },
    {
      path: '/login',
      component: () => import('../views/LoginView.vue'),
    },
    {
      path: '/tasks',
      component: () => import('../views/TasksView.vue'),
      meta: { requiresAuth: true },
    },
    {
      path: '/:pathMatch(.*)*',
      component: () => import('../views/NotFoundView.vue'),
    },
  ],
})

export default router
```

## Exercise 2 — Create the shell

Create `src/components/AppShell.vue`:

```vue
<script setup lang="ts">
import { RouterView } from 'vue-router'
</script>

<template>
  <div class="app-shell">
    <header>
      <strong>Task Management</strong>
      <button type="button">Logout</button>
    </header>

    <main>
      <RouterView />
    </main>
  </div>
</template>
```

Use semantic HTML and visible keyboard focus.

## Exercise 3 — Add a temporary auth guard

For this lab, use a temporary boolean or stored placeholder:

```ts
const isAuthenticated = () =>
  sessionStorage.getItem('workshop-auth') === 'true'

router.beforeEach((to) => {
  if (to.meta.requiresAuth && !isAuthenticated()) {
    return {
      path: '/login',
      query: { redirect: to.fullPath },
    }
  }
})
```

Lab 12 replaces this placeholder with a real JWT-backed session.

## Exercise 4 — Verify routes

Run `npm run dev`. Navigate with links (no full reload), paste `/tasks` while signed out, and visit `/does-not-exist`. Resize the browser to about 390 px wide.

## Validation

Protected route redirects to Login, unknown route shows Not Found, and the layout does not overflow at narrow width.

## Recovery

Check that Vue Router is installed and `app.use(router)` runs before `mount`. Inspect `router/index.ts` and `AppShell.vue` in `instructor/solutions/frontend/`.

## Expected result

A reusable shell with predictable client-side navigation.
