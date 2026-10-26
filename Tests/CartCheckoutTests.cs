using NUnit.Framework;
using SeleniumCSharpFramework.Pages;

namespace SeleniumCSharpFramework.Tests;

[TestFixture]
public class CartCheckoutTests : BaseTest
{
    [Test]
    public void FullCheckout_Flow_ConfirmsOrder()
    {
        var login = new LoginPage(Driver);
        login.Open();
        var inventory = login.LoginAs("standard_user", "secret_sauce");

        inventory.AddBackpackToCart();
        var cart = inventory.GoToCart();
        Assert.That(cart.ItemCount, Is.EqualTo(1));

        var checkout = cart.Checkout();
        checkout.FillDetails("Isha", "Tiwari", "M5V 1J1");
        checkout.Finish();
        Assert.That(checkout.ConfirmationText, Is.EqualTo("Thank you for your order!"));
    }
}
