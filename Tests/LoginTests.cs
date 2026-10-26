using NUnit.Framework;
using SeleniumCSharpFramework.Pages;

namespace SeleniumCSharpFramework.Tests;

[TestFixture]
public class LoginTests : BaseTest
{
    [Test]
    public void ValidLogin_ShowsProductsPage()
    {
        var login = new LoginPage(Driver);
        login.Open();
        var inventory = login.LoginAs("standard_user", "secret_sauce");
        Assert.That(inventory.TitleText, Is.EqualTo("Products"));
    }

    [Test]
    public void InvalidLogin_ShowsError()
    {
        var login = new LoginPage(Driver);
        login.Open();
        login.LoginAs("standard_user", "wrong_password");
        Assert.That(login.ErrorText, Does.Contain("Username and password do not match"));
    }

    [Test]
    public void LockedOutUser_ShowsError()
    {
        var login = new LoginPage(Driver);
        login.Open();
        login.LoginAs("locked_out_user", "secret_sauce");
        Assert.That(login.ErrorText, Does.Contain("locked out"));
    }
}
