using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumPOMWalkthrough.lib.pages;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow;

namespace SeleniumPOMWalkthrough.BDD
{
    [Binding]
    public class AP_ItemPageSteps
    {
        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();
        [Given(@"I have logged in")]
        public void GivenIHaveLoggedIn()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUsername("standard_user");
            AP_Website.AP_HomePage.InputPassword("secret_sauce");
            AP_Website.AP_HomePage.ClickLoginButton();
        }

        [Given(@"I am on the public inventory page")]
        public void GivenIAmOnThePublicInventoryPage()
        {
            AP_Website.AP_UserPage.GoToUserPage();
            Assert.That(AP_Website.SeleniumDriver.Url.Contains("inventory"));
        }

        [When(@"click on the first item")]
        public void WhenClickOnTheFirstItem()
        {
            AP_Website.AP_ItemPage.GoToItemPage();
        }

        [When(@"click add to cart")]
        public void WhenClickAddToCart()
        {
            AP_Website.AP_ItemPage.AddToCart();
        }

        [Then(@"cart inventory is incremented")]
        public void ThenCartInventoryIsIncremented()
        {
            Assert.That(AP_Website.AP_ItemPage.GetQuantity(), Is.EqualTo("1"));
        }


        [Then(@"I am taken to the item page")]
        public void ThenIAmTakenToTheItemPage()
        {
            Assert.That(AP_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/inventory-item.html?id=4"));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            AP_Website.SeleniumDriver.Quit();
        }
    }
}
