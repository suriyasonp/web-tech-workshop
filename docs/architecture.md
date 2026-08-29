# Workshop Architecture

## Target Application

Task Management System with:

- Login
- Task list
- Create task
- Edit task
- Delete task
- Status / priority
- Role-aware authorization

## Logical Architecture

```text
Vue + TypeScript
      |
    Axios
      |
ASP.NET Core Minimal API
      |
 Application Services
      |
 Entity Framework Core
      |
    SQLite
```

## Suggested Task Entity

- Id
- Title
- Description
- Status
- Priority
- DueDate
- CreatedAt

## Core API

```http
GET    /api/tasks
GET    /api/tasks/{id}
POST   /api/tasks
PUT    /api/tasks/{id}
DELETE /api/tasks/{id}
POST   /api/auth/login
```
