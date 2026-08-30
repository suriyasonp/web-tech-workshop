# Browser Evidence

These screenshots were captured by Playwright in GitHub Actions run
[`33262413430`](https://github.com/suriyasonp/web-tech-workshop/actions/runs/33262413430)
from commit `36374ea7e788779d8ecf394d1e6f3ab2c0bf0d42`.

- `01-login.png` — login page before authentication.
- `02-task-list.png` — instructor task list after authentication.
- `03-task-created.png` — newly created high-priority task.
- `04-task-completed.png` — task updated to `Done` before deletion.

The same test also signs in as `student` and asserts that no Delete control is rendered.
