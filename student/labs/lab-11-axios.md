# Lab 11 — Connect Vue to the API with Axios

**Duration:** 50 minutes  
**Goal:** Put HTTP configuration behind a typed service and display all request states.

## Starting point

Continue from Lab 10. Start the backend at `http://localhost:5080` and frontend at `http://localhost:5173` in separate terminals.

## Exercise 1 — Create one HTTP client

Create `src/services/api.ts`:

```ts
import axios from 'axios'

export const api = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL,
  headers: { Accept: 'application/json' },
})
```

Add a response interceptor that rejects errors unchanged for now. Lab 12 will handle 401 globally.

## Exercise 2 — Create typed Task operations

Create `src/services/taskService.ts` with async methods: `getAll`, `create`, `update`, and `remove`. Type every request and response using `src/types.ts`; components must not call Axios directly.

## Exercise 3 — Render server data

In `TasksView.vue`, add `tasks`, `loading`, and `error` state. Load tasks in `onMounted` with `try/catch/finally`. Render:

- loading message while pending;
- error alert when request fails;
- empty state when the array is empty;
- a list/table when tasks exist.

## Check your work

Backend data appears. Stop the backend and refresh: the page shows a useful error instead of remaining blank or loading forever.

## Troubleshooting / instructor recovery

Open Browser DevTools → Network. Confirm the URL starts with `http://localhost:5080/api`. If blocked by CORS, configure the backend for the exact frontend origin. Trace TasksView → taskService → api in `instructor/solutions/frontend/`.

## Expected result

Vue consumes the API through one typed service boundary.
