# Lab 07 — Protect the API with JWT and Roles

**Duration:** 60 minutes  
**Goal:** Authenticate users and allow only an Instructor to delete tasks.

> Workshop note: demo credentials and a symmetric key are for local learning only. Production systems use an identity provider, protected secrets, hashed passwords, HTTPS, and key rotation.

## Starting Point

Continue from Lab 06.

## Exercise 1 — Configure JWT Bearer

```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 10.*
```

Add a development-only JWT section to `appsettings.Development.json`:

```json
{
  "Jwt": {
    "Issuer": "WebTechWorkshop",
    "Audience": "WebTechWorkshop.Frontend",
    "Key": "development-only-signing-key-change-me-1234567890"
  }
}
```

Configure authentication in `Program.cs`:

```csharp
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var jwt = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwt["Key"]!);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwt["Issuer"],
            ValidAudience = jwt["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();
```

Middleware order:

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

## Exercise 2 — Create login

Create request/response contracts:

```csharp
public sealed record LoginRequest(string Username, string Password);

public sealed record LoginResponse(
    string Token,
    DateTime ExpiresAt,
    string DisplayName,
    string Role);
```

A token contains identity and role claims:

```csharp
var claims = new[]
{
    new Claim(ClaimTypes.Name, username),
    new Claim(ClaimTypes.Role, role)
};
```

Map the login endpoint:

```csharp
app.MapPost("/api/auth/login", (LoginRequest request, TokenService tokens) =>
{
    // Workshop-only account check goes here.
    var result = tokens.Create(request.Username, "Instructor");
    return Results.Ok(result);
});
```

Use the demo-account logic from the instructor solution rather than storing production credentials in source code.

## Exercise 3 — Protect routes

```csharp
var tasks = app.MapGroup("/api/tasks")
    .RequireAuthorization();

tasks.MapDelete("/{id:int}", DeleteTask)
    .RequireAuthorization(policy => policy.RequireRole("Instructor"));
```

## Exercise 4 — Test identity and permission

```http
POST {{host}}/api/auth/login
Content-Type: application/json

{
  "username": "instructor",
  "password": "workshop"
}

###
GET {{host}}/api/tasks
Authorization: Bearer {{token}}
```

Test anonymous GET → 401, Instructor DELETE → 204/404, and Student DELETE → 403.

## Validation

You can demonstrate the difference: 401 means no valid identity; 403 means known identity without permission.

## Recovery

Check issuer, audience, signing key, token expiry, and the exact `Bearer ` prefix. Compare with `instructor/solutions/backend/` and its demo-account README.

## Expected result

Task routes require identity and DELETE enforces the Instructor role.
