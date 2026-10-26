using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpFramework.Pages;

public abstract class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly WebDriverWait Wait;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    protected IWebElement Find(By locator) =>
        Wait.Until(driver =>
        {
            var element = driver.FindElement(locator);
            return element.Displayed ? element : null;
        })!;

    protected void Click(By locator) => Find(locator).Click();

    protected void Type(By locator, string text)
    {
        var element = Find(locator);
        element.Clear();
        element.SendKeys(text);
    }
}
