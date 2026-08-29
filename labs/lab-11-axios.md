# Lab 11 — Axios Integration

## Objective
Keep HTTP configuration behind a typed service layer.

## Starting Point
Checkout `lab-11-start`.

## Steps
1. Create one Axios instance using `VITE_API_BASE_URL`.
2. Add request and response interceptors.
3. Implement typed `taskService` methods.
4. Load tasks into Tasks view.
5. Display loading, empty, and error states.

## Validation
The task list is loaded from the backend and a stopped backend produces visible feedback.

## Recovery
Checkout `lab-11-solution` and trace TasksView → taskService → api instance.

## Expected Result
Components depend on application services rather than raw HTTP calls.
