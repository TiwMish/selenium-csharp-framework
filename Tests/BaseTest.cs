using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharpFramework.Tests;

public abstract class BaseTest
{
    protected IWebDriver Driver = null!;

    [SetUp]
    public void SetUp()
    {
        // No WebDriverManager: Selenium Manager (built into Selenium WebDriver)
        // downloads the ChromeDriver that matches the Chrome installed on the
        // runner. WebDriverManager pinned a driver for Chrome 156, which the
        // runner did not have, causing "session not created" in CI.
        var options = new ChromeOptions();
        options.AddArgument("--headless=new");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        options.AddArgument("--window-size=1920,1080");
        Driver = new ChromeDriver(options);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}
