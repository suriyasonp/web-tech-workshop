# Lab 06 — Add Validation and Predictable Errors

**Duration:** 40 minutes  
**Goal:** Give clients consistent 400, 404, and 500 responses.

## Starting Point

Continue from the persistent API built in Lab 05.

## Exercise 1 — Create one validator

Create `Validation/TaskRequestValidator.cs`. Return field errors when:

- title is null, empty, or whitespace;
- title exceeds 120 characters;
- description exceeds 1000 characters;
- status or priority is not a defined enum value.

Example validator shape:

```csharp
namespace TaskApi.Validation;

public static class TaskRequestValidator
{
    public static Dictionary<string, string[]> Validate(TaskRequest request)
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(request.Title))
            errors["Title"] = ["Title is required."];
        else if (request.Title.Length > 120)
            errors["Title"] = ["Title must be 120 characters or fewer."];

        if (request.Description?.Length > 1000)
            errors["Description"] = ["Description must be 1000 characters or fewer."];

        if (!Enum.IsDefined(request.Status))
            errors["Status"] = ["Status is invalid."];

        if (!Enum.IsDefined(request.Priority))
            errors["Priority"] = ["Priority is invalid."];

        return errors;
    }
}
```

Keep validation reusable for POST and PUT.

## Exercise 2 — Return standard error shapes

At POST and PUT:

```csharp
var errors = TaskRequestValidator.Validate(request);
if (errors.Count > 0)
    return Results.ValidationProblem(errors);
```

For a missing task use:

```csharp
return Results.NotFound();
```

Register problem details and exception handling in `Program.cs`:

```csharp
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();
```

## Exercise 3 — Prove each failure

Add requests to `TaskApi.http`:

```http
POST {{host}}/api/tasks
Content-Type: application/json

{
  "title": "   ",
  "description": null,
  "status": "Todo",
  "priority": "Medium",
  "dueDate": null
}

###
GET {{host}}/api/tasks/999999
```

Also test an invalid status and then a valid POST to confirm the happy path still works.

## Validation

Blank title returns 400 with `errors.Title`; missing ID returns 404; the API remains running after bad input.

## Think about it

Validation errors are expected client mistakes; exceptions are unexpected failures. They should not share an ambiguous response.

## Recovery

Set a breakpoint in the validator and send one invalid request. Inspect `TaskRequestValidator` and endpoint responses under `instructor/solutions/backend/`.

## Expected result

The frontend can display actionable API failures without parsing custom strings.
