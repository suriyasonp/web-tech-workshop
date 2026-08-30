import { createRouter, createWebHistory } from 'vue-router'
import { authStore } from '@/stores/auth'
import LoginView from '@/views/LoginView.vue'
import TasksView from '@/views/TasksView.vue'
import NotFoundView from '@/views/NotFoundView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    { path: '/', redirect: '/tasks' },
    { path: '/login', name: 'login', component: LoginView, meta: { guestOnly: true } },
    { path: '/tasks', name: 'tasks', component: TasksView, meta: { requiresAuth: true } },
    { path: '/:pathMatch(.*)*', name: 'not-found', component: NotFoundView },
  ],
})

router.beforeEach((to) => {
  if (to.meta.requiresAuth && !authStore.isAuthenticated.value)
    return { name: 'login', query: { redirect: to.fullPath } }
  if (to.meta.guestOnly && authStore.isAuthenticated.value) return { name: 'tasks' }
})

export default router
