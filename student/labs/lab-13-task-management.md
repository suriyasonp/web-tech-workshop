# Lab 13 — Build the Task Management UI

**Duration:** 75 minutes  
**Goal:** Complete role-aware create, read, update, and delete from the browser.

## Starting Point

Continue from Lab 12 and login as Instructor.

## Exercise 1 — List and filter

Render title, status, priority, and due date. Add filter buttons for All, Todo, In Progress, and Done. Use a computed value; filtering must not mutate the server array.

## Exercise 2 — Create a reusable form

Create `src/components/TaskForm.vue` with title, description, status, priority, and due date. Accept initial values for edit and emit one typed submit event. Add labels, required state, maximum lengths, disabled/busy state, and Cancel.

## Exercise 3 — Connect mutations

Use `taskService` to:

1. create and append/reload;
2. open edit with a copy, update, then replace/reload;
3. confirm before delete, delete, then remove/reload.

Prevent double submission. Keep the dialog open if the API rejects input.

## Exercise 4 — Display API validation

For HTTP 400 Validation Problem responses, show field messages near the form and a short summary. Keep network/server failures as page or toast errors.

## Exercise 5 — Apply role-aware presentation

Show Delete only when `authStore.role === 'Instructor'`. Login as Student and confirm it is hidden. Remember: the API's 403 rule is security; hiding a button only improves UX.

## Validation

Instructor completes CRUD. Data remains after refresh. Student can view/edit as designed but cannot delete, including a manually sent DELETE request.

## Recovery

Use Network request/response bodies to compare the Vue payload with API DTOs. Inspect `TasksView.vue` and `TaskForm.vue` in `instructor/solutions/frontend/`.

## Expected result

A usable full-stack Task Management workflow.
