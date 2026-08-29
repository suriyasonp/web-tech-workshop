# Lab 07 — Authentication and Authorization

## Objective
Protect Task routes with JWT identity and role permission.

## Starting Point
Checkout `lab-07-start`.

## Steps
1. Configure JWT Bearer validation.
2. Implement `POST /api/auth/login`.
3. Add name and role claims to the token.
4. Require authentication for `/api/tasks`.
5. Require the Instructor role for DELETE.

## Validation
Anonymous GET returns 401; Instructor can delete; Student receives 403.

## Recovery
Checkout `lab-07-solution` and use the demo accounts documented in `src/backend/README.md`.

## Expected Result
Participants can distinguish authentication (who) from authorization (may do what).
