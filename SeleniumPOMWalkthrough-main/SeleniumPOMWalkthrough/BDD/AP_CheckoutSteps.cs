using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumPOMWalkthrough.lib.pages;
using SeleniumPOMWalkthrough.utils;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumPOMWalkthrough.BDD
{
    [Binding]
    public class AP_CheckoutSteps
    {
        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();
        private PersonalDetails _personalDetails;
        [Given(@"I have signed in")]
        public void GivenIHaveSignedIn()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUsername("standard_user");
            AP_Website.AP_HomePage.InputPassword("secret_sauce");
            AP_Website.AP_HomePage.ClickLoginButton();
        }
        
        [Given(@"I am on the catalog")]
        public void GivenIAmOnTheCatalog()
        {
            AP_Website.AP_UserPage.GoToUserPage();
        }
        
        [Given(@"I have added all items to the cart")]
        public void GivenIHaveAddedAllItemsToTheCart()
        {
            AP_Website.AP_UserPage.ClickAddAllToCart();
            Assert.That(AP_Website.AP_ItemPage.GetQuantity(), Is.EqualTo("6"));
        }
        
        [Given(@"I am on the checkout page")]
        public void GivenIAmOnTheCheckoutPage()
        {
            AP_Website.AP_UserPage.ClickShoppingButton();
            AP_Website.AP_UserPage.ClickCheckoutButton();
            Assert.That(AP_Website.SeleniumDriver.Url.Contains("checkout-step-one"));
        }
        
        [When(@"I add all items to the cart")]
        public void WhenIAddAllItemsToTheCart()
        {
            AP_Website.AP_UserPage.ClickAddAllToCart();
        }
        
        [When(@"I go to cart all items should be in cart")]
        public void WhenIGoToCartAllItemsShouldBeInCart()
        {
            AP_Website.AP_UserPage.ClickShoppingButton();
            Assert.That(AP_Website.AP_UserPage.GetHeaderText(), Does.Contain("YOUR CART"));
        }
        
        [When(@"I enter my personal details")]
        public void WhenIEnterMyPersonalDetails(Table table)
        {
            _personalDetails = table.CreateInstance<PersonalDetails>();
            AP_Website.AP_CheckoutPage.InputPersonalDetails(_personalDetails);
        }
        
        [When(@"press continue")]
        public void WhenPressContinue()
        {
            AP_Website.AP_CheckoutPage.ClickContinue();
        }
        
        [When(@"I press finish")]
        public void WhenIPressFinish()
        {
            AP_Website.AP_CheckoutPage.ClickFinish();
        }
        
        [Then(@"Cart inventory should be (.*)")]
        public void ThenCartInventoryShouldBe(int p0)
        {
            Assert.That(AP_Website.AP_ItemPage.GetQuantity(), Is.EqualTo("6"));
        }
        
        [Then(@"I can checkout")]
        public void ThenICanCheckout()
        {
            AP_Website.AP_UserPage.ClickCheckoutButton();
            Assert.That(AP_Website.SeleniumDriver.Url.Contains("checkout-step-one"));
        }

        [Then(@"I should be given an error message saying ""(.*)""")]
        public void ThenIShouldBeGivenAnErrorMessageSaying(string expected)
        {
            var result = AP_Website.AP_CheckoutPage.ErrorMessage();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Then(@"I can continue")]
        public void ThenICanContinue()
        {
            AP_Website.AP_CheckoutPage.InputPersonalDetails(_personalDetails);
            AP_Website.AP_CheckoutPage.ClickContinue();
        }
        
        [Then(@"I should be taken to the order page")]
        public void ThenIShouldBeTakenToTheOrderPage()
        {
            Assert.That(AP_Website.SeleniumDriver.Url.Contains("checkout-step-two"));
        }
        
        [Then(@"I have checked out")]
        public void ThenIHaveCheckedOut()
        {
            Assert.That(AP_Website.SeleniumDriver.Url.Contains("checkout-complete"));
        }
        [AfterScenario]
        public void DisposeWebDriver()
        {
            AP_Website.SeleniumDriver.Quit();
        }
    }
}