# Lab 07 — Authentication and Authorization

## Objective
Protect Task routes with JWT identity and role permission.

## Starting Point
Continue from your Lab 06 backend under `student/starter/backend`.

## Steps
1. Configure JWT Bearer validation.
2. Implement `POST /api/auth/login`.
3. Add name and role claims to the token.
4. Require authentication for `/api/tasks`.
5. Require the Instructor role for DELETE.

## Validation
Anonymous GET returns 401; Instructor can delete; Student receives 403.

## Recovery
Compare with `instructor/solutions/backend/` and use the demo accounts documented in its `README.md`.

## Expected Result
Participants can distinguish authentication (who) from authorization (may do what).
