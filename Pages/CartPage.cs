using OpenQA.Selenium;

namespace SeleniumCSharpFramework.Pages;

public class CartPage : BasePage
{
    private static readonly By CheckoutButton = By.Id("checkout-button");
    private static readonly By CartItems = By.ClassName("cart_item");

    public CartPage(IWebDriver driver) : base(driver) { }

    public int ItemCount => Driver.FindElements(CartItems).Count;

    public CheckoutPage Checkout()
    {
        Click(CheckoutButton);
        return new CheckoutPage(Driver);
    }
}
