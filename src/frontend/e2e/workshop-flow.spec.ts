import { expect, test } from '@playwright/test'
import { mkdir } from 'node:fs/promises'
import { fileURLToPath } from 'node:url'

const screenshotDirectory = fileURLToPath(new URL('../../resources/screenshots/', import.meta.url))

test.beforeAll(async () => {
  await mkdir(screenshotDirectory, { recursive: true })
})

test('instructor completes the workshop CRUD flow', async ({ page }) => {
  await page.goto('/login')
  await expect(page.getByRole('heading', { name: 'Welcome back' })).toBeVisible()
  await page.screenshot({ path: `${screenshotDirectory}/01-login.png`, fullPage: true })

  await page.getByLabel('Username').fill('instructor')
  await page.getByLabel('Password').fill('Workshop2026!')
  await page.getByRole('button', { name: 'Sign in' }).click()

  await expect(page).toHaveURL(/\/tasks$/)
  await expect(page.getByRole('heading', { name: 'Tasks' })).toBeVisible()
  await expect(page.getByText('Explore the workshop repository')).toBeVisible()
  await page.screenshot({ path: `${screenshotDirectory}/02-task-list.png`, fullPage: true })

  await page.getByRole('button', { name: '+ New task' }).click()
  await page.getByLabel('Title').fill('Practice the final demo')
  await page.getByLabel('Description').fill('Created by the browser end-to-end test')
  await page.getByLabel('Priority').selectOption('High')
  await page.getByLabel('Due date').fill('2026-09-13')
  await page.getByRole('button', { name: 'Save task' }).click()

  const taskRow = page.getByRole('row').filter({ hasText: 'Practice the final demo' })
  await expect(taskRow).toBeVisible()
  await page.screenshot({ path: `${screenshotDirectory}/03-task-created.png`, fullPage: true })

  await taskRow.getByRole('button', { name: 'Edit' }).click()
  await page.getByLabel('Status').selectOption('Done')
  await page.getByRole('button', { name: 'Save task' }).click()
  await expect(taskRow.getByText('Done', { exact: true })).toBeVisible()
  await page.screenshot({ path: `${screenshotDirectory}/04-task-completed.png`, fullPage: true })

  page.once('dialog', dialog => dialog.accept())
  await taskRow.getByRole('button', { name: 'Delete' }).click()
  await expect(taskRow).toHaveCount(0)
})

test('student role cannot delete tasks', async ({ page }) => {
  await page.goto('/login')
  await page.getByLabel('Username').fill('student')
  await page.getByLabel('Password').fill('Workshop2026!')
  await page.getByRole('button', { name: 'Sign in' }).click()
  await expect(page).toHaveURL(/\/tasks$/)
  await expect(page.getByRole('button', { name: 'Delete' })).toHaveCount(0)
})
