#!/usr/bin/env bash
set -euo pipefail

root_dir="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
cd "$root_dir"

for lab_number in $(seq -w 0 14); do
  lab_file=$(find labs -maxdepth 1 -type f -name "lab-${lab_number}-*.md" -print -quit)
  test -n "$lab_file"
  grep -q '^## Starting Point' "$lab_file"
  grep -q '^## Validation' "$lab_file"
  grep -q "lab-${lab_number}-start" "$lab_file"
  grep -q "lab-${lab_number}-solution" "$lab_file"
done

required_files=(
  docs/agenda.md
  docs/architecture.md
  docs/setup-guide.md
  docs/run-guide.md
  docs/checkpoints.md
  instructor/day-1.md
  instructor/day-2.md
  instructor/demo-script.md
  instructor/fallback-procedure.md
  instructor/rehearsal-checklist.md
  slides/Day-1-Foundation-and-Backend.pptx
  slides/Day-2-Frontend-and-Delivery.pptx
  src/backend/WebTechWorkshop.sln
  src/frontend/package-lock.json
  src/frontend/e2e/workshop-flow.spec.ts
)

for required_file in "${required_files[@]}"; do
  test -s "$required_file"
done

echo "Workshop materials validated"
