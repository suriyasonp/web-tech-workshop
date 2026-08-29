<script setup lang="ts">
import { ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { authService } from '@/services/authService'
import { getApiError } from '@/services/api'
import { authStore } from '@/stores/auth'

const route = useRoute()
const router = useRouter()
const username = ref('instructor')
const password = ref('Workshop2026!')
const error = ref('')
const busy = ref(false)

async function login() {
  busy.value = true
  error.value = ''
  try {
    authStore.setSession(await authService.login(username.value, password.value))
    await router.push(typeof route.query.redirect === 'string' ? route.query.redirect : '/tasks')
  } catch (reason) {
    error.value = getApiError(reason)
  } finally {
    busy.value = false
  }
}
</script>

<template>
  <main class="login-page">
    <section class="login-card">
      <div class="brand large"><span class="brand-mark">TM</span> Task Management</div>
      <p class="eyebrow">KU Web Technology Development Workshop</p>
      <h1>Welcome back</h1>
      <p class="muted">Sign in to continue to your workshop tasks.</p>
      <div v-if="error" class="alert error" role="alert">{{ error }}</div>
      <form @submit.prevent="login">
        <label>Username <input v-model="username" autocomplete="username" required /></label>
        <label>Password <input v-model="password" type="password" autocomplete="current-password" required /></label>
        <button class="button primary full" type="submit" :disabled="busy">{{ busy ? 'Signing in…' : 'Sign in' }}</button>
      </form>
      <p class="demo-note">Demo: <code>instructor</code> / <code>Workshop2026!</code></p>
    </section>
  </main>
</template>
