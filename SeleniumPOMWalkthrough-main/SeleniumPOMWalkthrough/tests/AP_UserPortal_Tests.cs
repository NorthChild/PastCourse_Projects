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
    public class AP_UserPortal_Tests
    {
        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();
        [Test]
        public void WhenIAmOnThePublicInventoryPage_WhenIClickTheBasketIcon_ThenIShouldBeAbleToViewMyCart()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUsername("standard_user");
            AP_Website.AP_HomePage.InputPassword("secret_sauce");
            AP_Website.AP_HomePage.ClickLoginButton();
            AP_Website.AP_UserPage.ClickShoppingButton();
            var result = AP_Website.AP_UserPage.GetHeaderText();
            Assert.That(result, Does.Contain("YOUR CART"));
        }
        public void CleanUp()
        {
            // Quit the drivers and closes every associated window
            AP_Website.SeleniumDriver.Quit();
            // Release unmanaged resources
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}
