# Lab 06 — Add Validation and Predictable Errors

**Duration:** 40 minutes  
**Goal:** Give clients consistent 400, 404, and 500 responses.

## Starting point

Continue from the persistent API built in Lab 05.

## Exercise 1 — Create one validator

Create `Validation/TaskRequestValidator.cs`. Return field errors when:

- title is null, empty, or whitespace;
- title exceeds 120 characters;
- description exceeds 1000 characters;
- status or priority is not a defined enum value.

Keep validation reusable for POST and PUT.

## Exercise 2 — Return standard error shapes

At POST and PUT, return:

```csharp
return Results.ValidationProblem(errors);
```

For a missing task use `Results.NotFound()`. Register problem details:

```csharp
builder.Services.AddProblemDetails();
app.UseExceptionHandler();
app.UseStatusCodePages();
```

## Exercise 3 — Prove each failure

Add requests to `TaskApi.http`:

1. POST with `"title": "   "`.
2. POST with an invalid status.
3. GET `/api/tasks/999999`.
4. POST a valid task to confirm the happy path still works.

## Check your work

Blank title returns 400 with `errors.Title`; missing ID returns 404; the API remains running after bad input.

## Think about it

Validation errors are expected client mistakes; exceptions are unexpected failures. They should not share an ambiguous response.

## Troubleshooting / instructor recovery

Set a breakpoint in the validator and send one invalid request. Inspect `TaskRequestValidator` and endpoint responses under `instructor/solutions/backend/`.

## Expected result

The frontend can display actionable API failures without parsing custom strings.
