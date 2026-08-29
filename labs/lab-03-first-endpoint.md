# Lab 03 — First Task Endpoint

## Objective
Connect a route to a typed Task response.

## Starting Point
Checkout `lab-03-start`.

## Steps
1. Define Task status, priority, and response types.
2. Map `GET /api/tasks`.
3. Return two sample tasks.
4. Call the route with `TaskApi.http` and inspect JSON casing and status codes.

## Validation
`GET /api/tasks` returns HTTP 200 and a JSON array with `title`, `status`, and `priority`.

## Recovery
Checkout `lab-03-solution` and compare the endpoint contract with `docs/architecture.md`.

## Expected Result
Participants can explain route, DTO, serialization, and HTTP response.
