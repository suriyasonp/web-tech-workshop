# Lab 04 — Task CRUD

## Objective
Implement the complete REST shape before persistence.

## Starting Point
Checkout `lab-04-start`.

## Steps
1. Add GET collection and GET-by-id routes.
2. Add POST with HTTP 201 and a `Location` header.
3. Add PUT and DELETE routes.
4. Move collection logic behind `TaskService`.
5. Exercise every route with `TaskApi.http`.

## Validation
Create → read → update → delete completes and an unknown id returns HTTP 404.

## Recovery
Checkout `lab-04-solution` and trace each route into `TaskService`.

## Expected Result
A complete REST-shaped API with endpoint code separated from task behavior.
