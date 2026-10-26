using OpenQA.Selenium;

namespace SeleniumCSharpFramework.Pages;

public class InventoryPage : BasePage
{
    private static readonly By Title = By.ClassName("title");
    private static readonly By BackpackAddButton = By.Id("add-to-cart-sauce-labs-backpack");
    private static readonly By CartLink = By.ClassName("shopping_cart_link");

    public InventoryPage(IWebDriver driver) : base(driver) { }

    public string TitleText => Find(Title).Text;

    public void AddBackpackToCart() => Click(BackpackAddButton);

    public CartPage GoToCart()
    {
        Click(CartLink);
        return new CartPage(Driver);
    }
}
