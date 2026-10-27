using OpenQA.Selenium;

namespace SeleniumCSharpFramework.Pages;

public class CheckoutPage : BasePage
{
    // Use data-test selectors throughout, matching the Playwright and
    // Cypress frameworks (which pass). The id selectors for first/last/
    // postal/continue/finish timed out on the overview step in CI.
    private static readonly By FirstName = By.CssSelector("[data-test='firstName']");
    private static readonly By LastName = By.CssSelector("[data-test='lastName']");
    private static readonly By PostalCode = By.CssSelector("[data-test='postalCode']");
    private static readonly By ContinueButton = By.CssSelector("[data-test='continue']");
    private static readonly By FinishButton = By.CssSelector("[data-test='finish']");
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
