import { api } from './api'
import type { LoginResponse } from '@/types'

export const authService = {
  async login(username: string, password: string): Promise<LoginResponse> {
    const { data } = await api.post<LoginResponse>('/auth/login', { username, password })
    return data
  },
}
