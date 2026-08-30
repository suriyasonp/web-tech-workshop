import axios from 'axios'
import router from '@/router'
import { authStore } from '@/stores/auth'

export const api = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL ?? 'http://localhost:5080/api',
  headers: { 'Content-Type': 'application/json' },
  timeout: 10_000,
})

api.interceptors.request.use((config) => {
  const token = authStore.session.value?.token
  if (token) config.headers.Authorization = `Bearer ${token}`
  return config
})

api.interceptors.response.use(
  (response) => response,
  async (error) => {
    if (error.response?.status === 401) {
      authStore.logout()
      if (router.currentRoute.value.name !== 'login') await router.push({ name: 'login' })
    }
    return Promise.reject(error)
  },
)

export function getApiError(error: unknown): string {
  if (axios.isAxiosError(error)) {
    const data = error.response?.data as { title?: string; errors?: Record<string, string[]> } | undefined
    const validation = data?.errors ? Object.values(data.errors).flat()[0] : undefined
    return validation ?? data?.title ?? error.message
  }
  return 'Something went wrong. Please try again.'
}
