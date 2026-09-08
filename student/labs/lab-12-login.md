# Lab 12 — Implement Browser Login

**Duration:** 55 minutes  
**Goal:** Login, retain a valid workshop session, attach its Bearer token, and logout.

## Starting Point

Continue from Lab 11 with both applications running.

## Exercise 1 — Add auth service and state

Create `src/services/authService.ts`:

```ts
import { api } from './api'
import type { LoginResponse } from '../types'

export const authService = {
  async login(username: string, password: string): Promise<LoginResponse> {
    const response = await api.post<LoginResponse>('/api/auth/login', {
      username,
      password,
    })

    return response.data
  },
}
```

Create a small reactive auth store in `src/stores/auth.ts`:

```ts
import { computed, reactive } from 'vue'
import type { LoginResponse } from '../types'

const STORAGE_KEY = 'workshop-auth'

function loadSession(): LoginResponse | null {
  const raw = sessionStorage.getItem(STORAGE_KEY)
  if (!raw) return null

  try {
    const session = JSON.parse(raw) as LoginResponse

    if (new Date(session.expiresAt).getTime() <= Date.now()) {
      sessionStorage.removeItem(STORAGE_KEY)
      return null
    }

    return session
  } catch {
    sessionStorage.removeItem(STORAGE_KEY)
    return null
  }
}

const state = reactive<{ session: LoginResponse | null }>({
  session: loadSession(),
})

export const authStore = {
  session: computed(() => state.session),
  isAuthenticated: computed(() => state.session !== null),
  canDelete: computed(() => state.session?.role === 'Instructor'),

  setSession(session: LoginResponse) {
    state.session = session
    sessionStorage.setItem(STORAGE_KEY, JSON.stringify(session))
  },

  logout() {
    state.session = null
    sessionStorage.removeItem(STORAGE_KEY)
  },
}
```

## Exercise 2 — Build Login view

The submit handler should keep UI state explicit:

```ts
const busy = ref(false)
const error = ref('')

async function submit() {
  busy.value = true
  error.value = ''

  try {
    const session = await authService.login(username.value, password.value)
    authStore.setSession(session)
    await router.push(String(route.query.redirect ?? '/tasks'))
  } catch {
    error.value = 'Login failed. Check your username and password.'
  } finally {
    busy.value = false
  }
}
```

Do not display the password in logs or error messages.

## Exercise 3 — Attach and reject tokens centrally

In the Axios request interceptor:

```ts
api.interceptors.request.use((config) => {
  const token = authStore.session.value?.token

  if (token) {
    config.headers.Authorization = `Bearer ${token}`
  }

  return config
})
```

Handle 401 centrally:

```ts
api.interceptors.response.use(
  (response) => response,
  async (error) => {
    if (
      error.response?.status === 401 &&
      !error.config?.url?.includes('/api/auth/login')
    ) {
      authStore.logout()
      await router.push('/login')
    }

    return Promise.reject(error)
  },
)
```

## Exercise 4 — Logout and expiry test

```ts
async function logout() {
  authStore.logout()
  await router.push('/login')
}
```

Test: login → refresh → Tasks remains available → logout → Tasks redirects. Temporarily change stored expiry to the past and refresh.

## Validation

Valid session survives refresh; expired session does not; logout removes the token; authenticated Task GET returns 200.

## Recovery

Inspect `sessionStorage`, the request's Authorization header, and API response in DevTools. Compare `authService`, `authStore`, and router guard with `instructor/solutions/frontend/`.

## Expected result

A complete workshop authentication flow with centralized token handling.
