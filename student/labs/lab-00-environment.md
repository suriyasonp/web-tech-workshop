# Lab 00 — Prepare and Verify Your Environment

**Duration:** 30–45 minutes  
**Goal:** Install the workshop tools, clone the repository, and prove that your computer is ready.

## Starting Point

Use a workshop computer where you can install developer tools. If tools are already installed, verify them before changing anything.

## Prerequisites and official downloads

Install these before the workshop. Use only the official pages.

| Tool | Required version | Official source |
|---|---:|---|
| Git | Latest stable | [git-scm.com/downloads](https://git-scm.com/downloads/) |
| Visual Studio Code | Latest stable | [code.visualstudio.com/Download](https://code.visualstudio.com/Download) |
| .NET SDK | 10.x SDK (not runtime only) | [dotnet.microsoft.com/download/dotnet/10.0](https://dotnet.microsoft.com/download/dotnet/10.0) |
| Node.js | 24.x LTS | [nodejs.org/en/download](https://nodejs.org/en/download) |
| GitHub account | Any active account | [github.com/signup](https://github.com/signup) |

Recommended VS Code extensions: [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit), [Vue - Official](https://marketplace.visualstudio.com/items?itemName=Vue.volar), and [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client).

## Exercise 1 — Verify the tools

Open **PowerShell** on Windows or **Terminal** on macOS and run:

```text
git --version
dotnet --version
node --version
npm --version
code --version
```

Expected: .NET starts with `10.` and Node starts with `v24.`. If `code` is unavailable on macOS, open VS Code, press `Cmd+Shift+P`, and run **Shell Command: Install 'code' command in PATH**.

## Exercise 2 — Clone the workshop

Choose a normal development folder, then run on either operating system:

```bash
git clone https://github.com/suriyasonp/web-tech-workshop.git
cd web-tech-workshop
git switch main
git pull --ff-only
code .
```

If GitHub asks you to authenticate, follow [GitHub's official Git setup guide](https://docs.github.com/en/get-started/git-basics/set-up-git).

## Exercise 3 — Validate the material

macOS:

```bash
bash scripts/validate-materials.sh
```

Windows PowerShell (Git Bash is required for the validator):

```powershell
& "C:\Program Files\Git\bin\bash.exe" scripts/validate-materials.sh
```

## Validation

- Every version command succeeds.
- The repository is open in VS Code.
- The final line is `Workshop materials validated`.

## Recovery

Restart the terminal after installation. Confirm you installed the **.NET SDK**, not only the runtime. If a command still fails, show the instructor the exact command and complete error; do not reinstall everything.

## Expected result

Your workstation is ready for Labs 01–14.
