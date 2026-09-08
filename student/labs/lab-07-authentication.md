# Lab 07 — Protect the API with JWT and Roles

**Duration:** 60 minutes  
**Goal:** Authenticate users and allow only an Instructor to delete tasks.

> Workshop note: demo credentials and a symmetric key are for local learning only. Production systems use an identity provider, protected secrets, hashed passwords, HTTPS, and key rotation.

## Starting point

Continue from Lab 06.

## Exercise 1 — Configure JWT Bearer

```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 10.*
```

Add a development-only JWT section to `appsettings.Development.json` with issuer, audience, and a long signing key. Configure `AddAuthentication().AddJwtBearer(...)`, add authorization, then ensure middleware order is:

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

## Exercise 2 — Create login

Create `Contracts/LoginRequest.cs`, `LoginResponse.cs`, and `Services/TokenService.cs`. Map `POST /api/auth/login`. For the workshop accounts, include name and role claims and return token, expiry, display name, and role.

## Exercise 3 — Protect routes

Apply `.RequireAuthorization()` to the Task route group. Apply `.RequireAuthorization(policy => policy.RequireRole("Instructor"))` to DELETE.

## Exercise 4 — Test identity and permission

1. Anonymous GET → 401.
2. Login as Instructor; copy the token.
3. Send `Authorization: Bearer <token>`; GET → 200, DELETE → 204/404.
4. Repeat with Student; DELETE → 403.

## Check your work

You can demonstrate the difference: 401 means no valid identity; 403 means known identity without permission.

## Troubleshooting / instructor recovery

Check issuer, audience, signing key, token expiry, and the exact `Bearer ` prefix. Compare with `instructor/solutions/backend/` and its demo-account README.

## Expected result

Task routes require identity and DELETE enforces the Instructor role.
