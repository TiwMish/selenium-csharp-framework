using OpenQA.Selenium;

namespace SeleniumCSharpFramework.Pages;

public class LoginPage : BasePage
{
    private static readonly By Username = By.Id("user-name");
    private static readonly By Password = By.Id("password");
    private static readonly By LoginButton = By.Id("login-button");
    private static readonly By Error = By.CssSelector("[data-test='error']");

    public LoginPage(IWebDriver driver) : base(driver) { }

    public void Open() => Driver.Navigate().GoToUrl("https://www.saucedemo.com/");

    public InventoryPage LoginAs(string username, string password)
    {
        Type(Username, username);
        Type(Password, password);
        Click(LoginButton);
        return new InventoryPage(Driver);
    }

    public string ErrorText => Find(Error).Text;
}
