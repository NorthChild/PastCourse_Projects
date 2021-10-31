using NUnit.Framework;
using SeleniumPOMWalkthrough.utils;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumPOMWalkthrough.BDD.Inheritance
{
    [Binding]
    [Scope(Tag = "Checkout")]
    public class UserStorySteps : BaseSteps
    {
        private PersonalDetails _personalDetails;
        [When(@"I add all items to the basket")]
        public void WhenIAddAllItemsToTheBasket()
        {
            AP_Website.AP_UserPage.ClickAddAllToCart();
        }
        
        [When(@"I go to basket")]
        public void WhenIGoToBasket()
        {
            AP_Website.AP_UserPage.ClickShoppingButton();
            AP_Website.AP_UserPage.ClickCheckoutButton();
        }
        
        [When(@"I enter personal details for order")]
        public void WhenIEnterPersonalDetailsForOrder(Table table)
        {
            _personalDetails = table.CreateInstance<PersonalDetails>();
            AP_Website.AP_CheckoutPage.InputPersonalDetails(_personalDetails);
        }
        
        [When(@"I press continue")]
        public void WhenIPressContinue()
        {
            AP_Website.AP_CheckoutPage.ClickContinue();
        }
        
        [When(@"I press the finish button")]
        public void WhenIPressTheFinishButton()
        {
            AP_Website.AP_CheckoutPage.ClickFinish();
        }
        
        [Then(@"I have checkedout")]
        public void ThenIHaveCheckedout()
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
