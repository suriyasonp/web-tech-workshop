import { computed, reactive } from 'vue'
import type { LoginResponse } from '@/types'

const STORAGE_KEY = 'workshop-auth'

function loadSession(): LoginResponse | null {
  const value = localStorage.getItem(STORAGE_KEY)
  if (!value) return null
  try {
    const session = JSON.parse(value) as LoginResponse
    if (new Date(session.expiresAt) <= new Date()) {
      localStorage.removeItem(STORAGE_KEY)
      return null
    }
    return session
  } catch {
    localStorage.removeItem(STORAGE_KEY)
    return null
  }
}

const state = reactive<{ session: LoginResponse | null }>({ session: loadSession() })

export const authStore = {
  session: computed(() => state.session),
  isAuthenticated: computed(() => state.session !== null),
  canDelete: computed(() => state.session?.role === 'Instructor'),
  setSession(session: LoginResponse) {
    state.session = session
    localStorage.setItem(STORAGE_KEY, JSON.stringify(session))
  },
  logout() {
    state.session = null
    localStorage.removeItem(STORAGE_KEY)
  },
}
