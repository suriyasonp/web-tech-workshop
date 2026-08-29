<script setup lang="ts">
import { reactive, watch } from 'vue'
import type { TaskInput, TaskItem } from '@/types'

const props = defineProps<{ task?: TaskItem | null; busy?: boolean }>()
const emit = defineEmits<{ submit: [input: TaskInput]; cancel: [] }>()

const form = reactive<TaskInput>({ title: '', description: null, status: 'ToDo', priority: 'Medium', dueDate: null })

watch(() => props.task, (task) => {
  form.title = task?.title ?? ''
  form.description = task?.description ?? null
  form.status = task?.status ?? 'ToDo'
  form.priority = task?.priority ?? 'Medium'
  form.dueDate = task?.dueDate ?? null
}, { immediate: true })

function submit() {
  emit('submit', {
    ...form,
    title: form.title.trim(),
    description: form.description?.trim() || null,
    dueDate: form.dueDate || null,
  })
}
</script>

<template>
  <form class="task-form" @submit.prevent="submit">
    <label>Title <input v-model="form.title" maxlength="120" required autofocus /></label>
    <label>Description <textarea v-model="form.description" maxlength="1000" rows="3" /></label>
    <div class="form-grid">
      <label>Status
        <select v-model="form.status"><option value="ToDo">To do</option><option value="InProgress">In progress</option><option value="Done">Done</option></select>
      </label>
      <label>Priority
        <select v-model="form.priority"><option>Low</option><option>Medium</option><option>High</option></select>
      </label>
      <label>Due date <input v-model="form.dueDate" type="date" /></label>
    </div>
    <div class="form-actions">
      <button class="button secondary" type="button" :disabled="busy" @click="emit('cancel')">Cancel</button>
      <button class="button primary" type="submit" :disabled="busy || !form.title.trim()">{{ busy ? 'Saving…' : 'Save task' }}</button>
    </div>
  </form>
</template>
