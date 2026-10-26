using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace SauceDemoTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class SauceDemoUiTests : PageTest
{
    private async Task LoginAsync(string username, string password)
    {
        await Page.GotoAsync("https://www.saucedemo.com");
        await Page.GetByPlaceholder("Username").FillAsync(username);
        await Page.GetByPlaceholder("Password").FillAsync(password);
        await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
    }

    [Test]
    public async Task ValidUser_CanLogin()
    {
        await LoginAsync("standard_user", "secret_sauce");
        await Expect(Page).ToHaveURLAsync(new Regex("inventory"));
    }

    [Test]
    public async Task LockedOutUser_SeesErrorMessage()
    {
        await LoginAsync("locked_out_user", "secret_sauce");
        await Expect(Page.Locator("[data-test='error']")).ToContainTextAsync("locked out");
    }

    [Test]
    public async Task AddToCart_ShowsOneItemInCartBadge()
    {
        await LoginAsync("standard_user", "secret_sauce");
        await Page.Locator("[data-test='add-to-cart-sauce-labs-backpack']").ClickAsync();
        await Expect(Page.Locator(".shopping_cart_badge")).ToHaveTextAsync("1");
    }
}