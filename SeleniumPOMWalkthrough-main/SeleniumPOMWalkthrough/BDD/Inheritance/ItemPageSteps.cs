using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace SeleniumPOMWalkthrough.BDD.Inheritance
{
    [Binding]
    [Scope(Tag ="Item")]
    public class ItemPageSteps : BaseSteps
    {
        [When(@"I click on the first item")]
        public void WhenIClickOnTheFirstItem()
        {
            AP_Website.AP_ItemPage.GoToItemPage();
        }
        
        [Then(@"I should be on the first item page")]
        public void ThenIShouldBeOnTheFirstItemPage()
        {
            Assert.That(AP_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/inventory-item.html?id=4"));
        }

        [Then(@"I should be able to add item to the cart")]
        public void ThenIShouldBeAbleToAddItemToTheCart()
        {
            AP_Website.AP_ItemPage.AddToCart();
        }

        [Then(@"The cart should increment")]
        public void ThenTheCartShouldIncrement()
        {
            Assert.That(AP_Website.AP_ItemPage.GetQuantity(), Is.EqualTo("1"));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            AP_Website.SeleniumDriver.Quit();
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}
