<script setup lang="ts">
import { useRouter } from 'vue-router'
import { authStore } from '@/stores/auth'

const router = useRouter()
async function logout() {
  authStore.logout()
  await router.push({ name: 'login' })
}
</script>

<template>
  <div class="app-shell">
    <header class="topbar">
      <RouterLink class="brand" to="/tasks"><span class="brand-mark">TM</span> Task Management</RouterLink>
      <div class="user-actions">
        <span>{{ authStore.session.value?.username }} · {{ authStore.session.value?.role }}</span>
        <button class="button secondary small" type="button" @click="logout">Log out</button>
      </div>
    </header>
    <main class="page"><slot /></main>
  </div>
</template>
