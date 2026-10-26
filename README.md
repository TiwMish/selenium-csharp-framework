# Selenium + C# Framework

Selenium WebDriver test framework in C# with NUnit, built around page objects.
Tests run against the public SauceDemo demo site — no proprietary code, no real
credentials. Demo users are the ones SauceDemo publishes publicly
(`standard_user` / `secret_sauce`).

## What it covers
- UI tests: valid login, invalid login, locked-out user
- Full flow: login → add Sauce Labs Backpack → cart → checkout → "Thank you for your order!"
- Page objects: Login, Inventory, Cart, Checkout
- Explicit waits (no `Thread.Sleep` in tests)

## Run it
```bash
dotnet test
```

ChromeDriver is managed by Selenium Manager (built into Selenium WebDriver), so no manual driver download is needed and the driver always matches the installed Chrome version.
GitHub Actions runs `dotnet test` on every push / pull request (see
`.github/workflows/ci.yml` — add this file manually on GitHub if the
GitHub App cannot push workflow files).

## Structure
```
Pages/            LoginPage, InventoryPage, CartPage, CheckoutPage
Tests/            BaseTest (driver setup/teardown), LoginTests, CartCheckoutTests
SeleniumCSharpFramework.csproj
```
