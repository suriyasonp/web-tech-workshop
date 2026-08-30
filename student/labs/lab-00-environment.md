# Lab 00 — Environment Check

## Objective
Confirm that the workshop toolchain is installed before coding begins.

## Starting Point
Clone the repository, switch to `main`, and open the repository root.

## Steps
1. Open the repository in VS Code.
2. Run `git --version`, `dotnet --version`, `node --version`, and `npm --version`.
3. Confirm .NET reports major version 10 and Node reports version 24, matching CI.
4. Run `bash scripts/validate-materials.sh`.

## Validation
Every command succeeds and the material validator reports `Workshop materials validated`.

## Recovery
Compare the failed command with `docs/setup-guide.md` and ask the instructor to verify the installed tool version.

## Expected Result
The machine is ready and the participant knows where to find recovery instructions.
