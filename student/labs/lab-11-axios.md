# Lab 11 — Connect Vue to the API with Axios

**Duration:** 50 minutes  
**Goal:** Put HTTP configuration behind a typed service and display all request states.

## Starting Point

Continue from Lab 10. Start the backend at `http://localhost:5080` and frontend at `http://localhost:5173` in separate terminals.

## Exercise 1 — Create one HTTP client

Create `src/services/api.ts`:

```ts
import axios from 'axios'

export const api = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL,
  headers: { Accept: 'application/json' },
})

api.interceptors.response.use(
  (response) => response,
  (error) => Promise.reject(error),
)
```

Lab 12 will extend this client to handle authentication centrally.

## Exercise 2 — Create typed Task operations

Create `src/services/taskService.ts`:

```ts
import { api } from './api'
import type { Task, TaskRequest } from '../types'

export const taskService = {
  async getAll(): Promise<Task[]> {
    const response = await api.get<Task[]>('/api/tasks')
    return response.data
  },

  async create(request: TaskRequest): Promise<Task> {
    const response = await api.post<Task>('/api/tasks', request)
    return response.data
  },

  async update(id: number, request: TaskRequest): Promise<Task> {
    const response = await api.put<Task>(`/api/tasks/${id}`, request)
    return response.data
  },

  async remove(id: number): Promise<void> {
    await api.delete(`/api/tasks/${id}`)
  },
}
```

Components must not call Axios directly.

## Exercise 3 — Render server data

In `TasksView.vue`:

```vue
<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { taskService } from '../services/taskService'
import type { Task } from '../types'

const tasks = ref<Task[]>([])
const loading = ref(false)
const error = ref('')

async function loadTasks() {
  loading.value = true
  error.value = ''

  try {
    tasks.value = await taskService.getAll()
  } catch {
    error.value = 'Unable to load tasks.'
  } finally {
    loading.value = false
  }
}

onMounted(loadTasks)
</script>

<template>
  <p v-if="loading">Loading tasks…</p>
  <p v-else-if="error" role="alert">{{ error }}</p>
  <p v-else-if="tasks.length === 0">No tasks yet.</p>

  <ul v-else>
    <li v-for="task in tasks" :key="task.id">
      {{ task.title }} — {{ task.status }}
    </li>
  </ul>
</template>
```

## Validation

Backend data appears. Stop the backend and refresh: the page shows a useful error instead of remaining blank or loading forever.

## Recovery

Open Browser DevTools → Network. Confirm the URL starts with `http://localhost:5080/api`. If blocked by CORS, configure the backend for the exact frontend origin. Trace TasksView → taskService → api in `instructor/solutions/frontend/`.

## Expected result

Vue consumes the API through one typed service boundary.
