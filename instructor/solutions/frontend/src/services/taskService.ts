import { api } from './api'
import type { TaskInput, TaskItem } from '@/types'

export const taskService = {
  async getAll(): Promise<TaskItem[]> {
    const { data } = await api.get<TaskItem[]>('/tasks')
    return data
  },
  async create(input: TaskInput): Promise<TaskItem> {
    const { data } = await api.post<TaskItem>('/tasks', input)
    return data
  },
  async update(id: number, input: TaskInput): Promise<TaskItem> {
    const { data } = await api.put<TaskItem>(`/tasks/${id}`, input)
    return data
  },
  async remove(id: number): Promise<void> {
    await api.delete(`/tasks/${id}`)
  },
}
