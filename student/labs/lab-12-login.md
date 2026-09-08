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

Create a small reactive auth store in `src/stores/authStore.ts`:

```ts
import { reactive } from 'vue'

const STORAGE_KEY = 'workshop-session'

interface Session {
  token: string
  expiresAt: string
  displayName: string
  role: string
}

function loadSession(): Session | null {
  const raw = sessionStorage.getItem(STORAGE_KEY)
  if (!raw) return null

  const session = JSON.parse(raw) as Session
  if (new Date(session.expiresAt).getTime() <= Date.now()) {
    sessionStorage.removeItem(STORAGE_KEY)
    return null
  }

  return session
}

export const authStore = reactive({
  session: loadSession() as Session | null,

  setSession(session: Session) {
    this.session = session
    sessionStorage.setItem(STORAGE_KEY, JSON.stringify(session))
  },

  clear() {
    this.session = null
    sessionStorage.removeItem(STORAGE_KEY)
  },
})
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
  const token = authStore.session?.token

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
    if (error.response?.status === 401 && !error.config?.url?.includes('/api/auth/login')) {
      authStore.clear()
      await router.push('/login')
    }

    return Promise.reject(error)
  },
)
```

## Exercise 4 — Logout and expiry test

```ts
async function logout() {
  authStore.clear()
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
