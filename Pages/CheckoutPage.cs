using OpenQA.Selenium;

namespace SeleniumCSharpFramework.Pages;

public class CheckoutPage : BasePage
{
    private static readonly By FirstName = By.Id("first-name");
    private static readonly By LastName = By.Id("last-name");
    private static readonly By PostalCode = By.Id("postal-code");
    private static readonly By ContinueButton = By.Id("continue");
    private static readonly By FinishButton = By.Id("finish");
    private static readonly By CompleteHeader = By.ClassName("complete-header");

    public CheckoutPage(IWebDriver driver) : base(driver) { }

    public void FillDetails(string first, string last, string postal)
    {
        Type(FirstName, first);
        Type(LastName, last);
        Type(PostalCode, postal);
        Click(ContinueButton);
    }

    public void Finish() => Click(FinishButton);

    public string ConfirmationText => Find(CompleteHeader).Text;
}
