using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumCSharpFramework.Tests;

public abstract class BaseTest
{
    protected IWebDriver Driver = null!;

    [SetUp]
    public void SetUp()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        var options = new ChromeOptions();
        options.AddArgument("--headless=new");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        Driver = new ChromeDriver(options);
        Driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}
