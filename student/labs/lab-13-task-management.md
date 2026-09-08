# Lab 13 — Build the Task Management UI

**Duration:** 75 minutes  
**Goal:** Complete role-aware create, read, update, and delete from the browser.

## Starting Point

Continue from Lab 12 and login as Instructor.

## Exercise 1 — List and filter

Render title, status, priority, and due date. Add filter buttons for All, Todo, In Progress, and Done. Use a computed value; filtering must not mutate the server array.

```ts
const filter = ref<'All' | TaskStatus>('All')

const filteredTasks = computed(() => {
  if (filter.value === 'All') return tasks.value
  return tasks.value.filter((task) => task.status === filter.value)
})
```

## Exercise 2 — Create a reusable form

Create `src/components/TaskForm.vue` with title, description, status, priority, and due date. Accept initial values for edit and emit one typed submit event.

```vue
<script setup lang="ts">
import { reactive } from 'vue'
import type { TaskRequest } from '../types'

const props = defineProps<{
  initial?: TaskRequest
  busy?: boolean
}>()

const emit = defineEmits<{
  submit: [value: TaskRequest]
  cancel: []
}>()

const form = reactive<TaskRequest>({
  title: props.initial?.title ?? '',
  description: props.initial?.description ?? null,
  status: props.initial?.status ?? 'Todo',
  priority: props.initial?.priority ?? 'Medium',
  dueDate: props.initial?.dueDate ?? null,
})

function submit() {
  emit('submit', { ...form })
}
</script>
```

Add labels, required state, maximum lengths, disabled/busy state, and Cancel.

## Exercise 3 — Connect mutations

Create:

```ts
async function createTask(request: TaskRequest) {
  saving.value = true
  try {
    await taskService.create(request)
    await loadTasks()
    showForm.value = false
  } finally {
    saving.value = false
  }
}
```

Update:

```ts
async function updateTask(id: number, request: TaskRequest) {
  saving.value = true
  try {
    await taskService.update(id, request)
    await loadTasks()
    editing.value = null
  } finally {
    saving.value = false
  }
}
```

Delete:

```ts
async function deleteTask(task: Task) {
  if (!window.confirm(`Delete "${task.title}"?`)) return

  await taskService.remove(task.id)
  tasks.value = tasks.value.filter((item) => item.id !== task.id)
}
```

Prevent double submission. Keep the dialog open if the API rejects input.

## Exercise 4 — Display API validation

For HTTP 400 Validation Problem responses, extract field errors:

```ts
import axios from 'axios'

function getValidationErrors(error: unknown) {
  if (!axios.isAxiosError(error) || error.response?.status !== 400) {
    return {}
  }

  return error.response.data?.errors ?? {}
}
```

Show field messages near the form and a short summary. Keep network/server failures as page or toast errors.

## Exercise 5 — Apply role-aware presentation

```vue
<button
  v-if="authStore.session?.role === 'Instructor'"
  type="button"
  @click="deleteTask(task)"
>
  Delete
</button>
```

Login as Student and confirm it is hidden. Remember: the API's 403 rule is security; hiding a button only improves UX.

## Validation

Instructor completes CRUD. Data remains after refresh. Student can view/edit as designed but cannot delete, including a manually sent DELETE request.

## Recovery

Use Network request/response bodies to compare the Vue payload with API DTOs. Inspect `TasksView.vue` and `TaskForm.vue` in `instructor/solutions/frontend/`.

## Expected result

A usable full-stack Task Management workflow.
