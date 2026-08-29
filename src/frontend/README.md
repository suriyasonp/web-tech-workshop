# Frontend — Task Management UI

Vue 3 + TypeScript + Vite frontend with Vue Router, Axios service layer, JWT session handling, route protection, loading/error states, filtering, and Task CRUD.

## Run

Start the backend first, then:

```bash
cd src/frontend
cp .env.example .env
npm install
npm run dev
```

Open `http://localhost:5173` and sign in with `instructor` / `Workshop2026!`.

## Verify

```bash
npm run type-check
npm run build
```

The frontend stores the workshop JWT in local storage. This is intentionally simple for teaching; production applications should evaluate stronger token storage and refresh-token controls.
