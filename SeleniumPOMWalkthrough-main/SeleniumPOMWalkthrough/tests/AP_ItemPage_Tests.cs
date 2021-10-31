using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumPOMWalkthrough.lib.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOMWalkthrough.tests
{
    public class AP_ItemPage_Tests
    {
        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();
        [Test]
        public void GivenIAmOnThePublicInventoryPage_WhenIClickOnFirstItem_ThenIAmTakenToItemPage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUsername("standard_user");
            AP_Website.AP_HomePage.InputPassword("secret_sauce");
            AP_Website.AP_HomePage.ClickLoginButton();
            AP_Website.AP_ItemPage.GoToItemPage();
            var result = AP_Website.AP_ItemPage.GetItemName();
            Assert.That(result, Is.EqualTo("Sauce Labs Backpack"));
            Assert.That(AP_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/inventory-item.html?id=4"));
        }
        [Test]
        public void GivenIAmOnTheItemPage_WhenIClickAddToCart_ThenBasketInventoryIncrements()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUsername("standard_user");
            AP_Website.AP_HomePage.InputPassword("secret_sauce");
            AP_Website.AP_HomePage.ClickLoginButton();
            AP_Website.AP_ItemPage.GoToItemPage();
            AP_Website.AP_ItemPage.AddToCart();
            var result = AP_Website.AP_ItemPage.GetQuantity();
            Assert.That(result, Is.EqualTo("1"));
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            // Quit the drivers and closes every associated window
            AP_Website.SeleniumDriver.Quit();
            // Release unmanaged resources
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}
