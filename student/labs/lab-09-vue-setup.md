# Lab 09 — Create the Vue + TypeScript Frontend

**Duration:** 40 minutes  
**Goal:** Scaffold a typed frontend that develops and builds cleanly.

## Starting Point

Keep the completed backend. From repository root create `student/starter/frontend`.

## Exercise 1 — Scaffold Vue

```bash
cd student/starter
npm create vue@latest frontend
```

Choose: TypeScript **Yes**, Router **Yes**, Pinia **No**, Vitest **No**, E2E **No**, ESLint **Yes**, Prettier optional. Then:

```bash
cd frontend
npm install
npm install axios
npm run dev
```

Open the URL printed by Vite (normally `http://localhost:5173`).

## Exercise 2 — Clean and type the app

Remove demo components/assets that are no longer imported. Create `src/types.ts` containing `TaskStatus`, `TaskPriority`, Task, create/update request, and login response types matching the API JSON.

Create `.env.example`:

```text
VITE_API_BASE_URL=http://localhost:5080
```

Copy it to `.env.local` on either OS:

```bash
cp .env.example .env.local
```

PowerShell alternative: `Copy-Item .env.example .env.local`.

## Exercise 3 — Build from a clean install

```bash
npm run build
```

Commit both `package.json` and `package-lock.json`; do not commit `node_modules` or `.env.local`.

## Validation

Development server opens, TypeScript shows no error, and production build succeeds.

## Recovery

Run commands in `student/starter/frontend`. If dependencies are inconsistent, remove only `node_modules` and run `npm ci`. Compare `package.json`, `main.ts`, and `types.ts` with `instructor/solutions/frontend/`.

## Expected result

A repeatable Vue + TypeScript starter ready for features.
