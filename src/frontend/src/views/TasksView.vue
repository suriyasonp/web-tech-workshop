<script setup lang="ts">
import { computed, onMounted, ref } from 'vue'
import AppShell from '@/components/AppShell.vue'
import TaskForm from '@/components/TaskForm.vue'
import { getApiError } from '@/services/api'
import { taskService } from '@/services/taskService'
import { authStore } from '@/stores/auth'
import type { TaskInput, TaskItem, TaskStatus } from '@/types'

const tasks = ref<TaskItem[]>([])
const loading = ref(true)
const busy = ref(false)
const error = ref('')
const filter = ref<'All' | TaskStatus>('All')
const filterOptions: Array<'All' | TaskStatus> = ['All', 'ToDo', 'InProgress', 'Done']
const dialogOpen = ref(false)
const editingTask = ref<TaskItem | null>(null)
const filteredTasks = computed(() => filter.value === 'All' ? tasks.value : tasks.value.filter(task => task.status === filter.value))

async function loadTasks() {
  loading.value = true
  error.value = ''
  try { tasks.value = await taskService.getAll() }
  catch (reason) { error.value = getApiError(reason) }
  finally { loading.value = false }
}

function openCreate() { editingTask.value = null; dialogOpen.value = true }
function openEdit(task: TaskItem) { editingTask.value = task; dialogOpen.value = true }

async function save(input: TaskInput) {
  busy.value = true
  error.value = ''
  try {
    if (editingTask.value) {
      const updated = await taskService.update(editingTask.value.id, input)
      tasks.value = tasks.value.map(task => task.id === updated.id ? updated : task)
    } else {
      tasks.value.unshift(await taskService.create(input))
    }
    dialogOpen.value = false
  } catch (reason) { error.value = getApiError(reason) }
  finally { busy.value = false }
}

async function remove(task: TaskItem) {
  if (!confirm(`Delete “${task.title}”?`)) return
  error.value = ''
  try {
    await taskService.remove(task.id)
    tasks.value = tasks.value.filter(item => item.id !== task.id)
  } catch (reason) { error.value = getApiError(reason) }
}

function label(value: string) { return value.replace(/([a-z])([A-Z])/g, '$1 $2') }
function selectFilter(value: 'All' | TaskStatus) { filter.value = value }
onMounted(loadTasks)
</script>

<template>
  <AppShell>
    <section class="page-heading">
      <div><p class="eyebrow">Workshop application</p><h1>Tasks</h1><p class="muted">Plan, track, and complete the team’s work.</p></div>
      <button class="button primary" type="button" @click="openCreate">+ New task</button>
    </section>

    <div v-if="error" class="alert error" role="alert">{{ error }} <button class="text-button" @click="error = ''">Dismiss</button></div>

    <section class="panel">
      <div class="toolbar">
        <div class="filters" aria-label="Filter tasks">
          <button v-for="option in filterOptions" :key="option" class="filter" :class="{ active: filter === option }" @click="selectFilter(option)">{{ label(option) }}</button>
        </div>
        <span class="muted">{{ filteredTasks.length }} task{{ filteredTasks.length === 1 ? '' : 's' }}</span>
      </div>

      <div v-if="loading" class="empty-state">Loading tasks…</div>
      <div v-else-if="filteredTasks.length === 0" class="empty-state"><strong>No tasks found</strong><span>Create a task or choose another filter.</span></div>
      <div v-else class="table-wrap">
        <table>
          <thead><tr><th>Task</th><th>Status</th><th>Priority</th><th>Due</th><th class="actions">Actions</th></tr></thead>
          <tbody>
            <tr v-for="task in filteredTasks" :key="task.id">
              <td><strong>{{ task.title }}</strong><span class="task-description">{{ task.description || 'No description' }}</span></td>
              <td><span class="badge" :data-status="task.status">{{ label(task.status) }}</span></td>
              <td><span class="priority" :data-priority="task.priority">{{ task.priority }}</span></td>
              <td>{{ task.dueDate || '—' }}</td>
              <td class="actions"><button class="text-button" @click="openEdit(task)">Edit</button><button v-if="authStore.canDelete.value" class="text-button danger" @click="remove(task)">Delete</button></td>
            </tr>
          </tbody>
        </table>
      </div>
    </section>

    <div v-if="dialogOpen" class="dialog-backdrop" @click.self="dialogOpen = false">
      <section class="dialog" role="dialog" aria-modal="true" :aria-label="editingTask ? 'Edit task' : 'Create task'">
        <div class="dialog-heading"><h2>{{ editingTask ? 'Edit task' : 'Create task' }}</h2><button class="icon-button" @click="dialogOpen = false">×</button></div>
        <TaskForm :task="editingTask" :busy="busy" @submit="save" @cancel="dialogOpen = false" />
      </section>
    </div>
  </AppShell>
</template>
