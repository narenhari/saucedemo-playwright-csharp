# SauceDemo UI Test Automation (C#)

![Tests](https://github.com/narenhari/saucedemo-playwright-csharp/actions/workflows/tests.yml/badge.svg)

Automated UI tests for [SauceDemo](https://www.saucedemo.com), a practice e-commerce site, built with C# and Playwright for .NET. The tests run automatically on every push through GitHub Actions.

## Tech stack

- C# and .NET 9
- NUnit (test framework)
- Playwright for .NET (browser automation)
- GitHub Actions (CI)

## What's covered

| Test | What it checks |
|---|---|
| Valid user can log in | Logging in as `standard_user` lands on the inventory page |
| Locked-out user sees an error | Logging in as `locked_out_user` shows a "locked out" error message |
| Add to cart updates the badge | Adding the backpack shows `1` on the cart badge |

## How to run it locally

Prerequisites: .NET 9 SDK and PowerShell.

```bash
git clone https://github.com/narenhari/saucedemo-playwright-csharp.git
cd saucedemo-playwright-csharp/SauceDemoTests
dotnet build
pwsh bin/Debug/net9.0/playwright.ps1 install
dotnet test
```

On Windows Command Prompt, use this for the browser install instead:

```bash
powershell -ExecutionPolicy Bypass -File bin\Debug\net9.0\playwright.ps1 install
```

To watch the browser while the tests run, set `HEADED=1` first (`set HEADED=1` in Command Prompt). To use another browser, set `BROWSER=firefox` or `BROWSER=webkit`.

## Continuous integration

The workflow in `.github/workflows/tests.yml` runs on every push to `main` and on pull requests. It builds the project, installs Chromium and runs the tests headless on Ubuntu.
