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
    public class AP_Signin_Tests
    {
        /* Instantiate our pages in our tests
         * These classes will include the functions for the page. 
         * Notice - NO USING STATMENTS! */
        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();
        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSigninButton_ThenIShouldLandOnTheSigninPage()
        {
            // Navigate to the AP Home page
            AP_Website.AP_HomePage.VisitHomePage();
            // Navigatge to the AP sign in page
            AP_Website.AP_HomePage.ClickLoginButton();
            // Assert that the title is correct
            Assert.That(AP_Website.SeleniumDriver.Title, Does.Contain("Swag Labs"));
        }
        [Test]
        public void GivenIAmOnTheHomePage_WhenISigninWithAValidCredentails_THenIShouldAppearInTheCustom()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUsername("standard_user");
            AP_Website.AP_HomePage.InputPassword("secret_sauce");
            AP_Website.AP_HomePage.ClickLoginButton();
            Assert.That(AP_Website.SeleniumDriver.Url.Contains("inventory"));
        }
        [Category("Sad Path")]
        [Test]
        public void GivenIAmOnHomePage_WhenISigninWithAValidUsernameButInvalidPassword_ThenIShouldBeGivenAnErrorMessage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUsername("standard_user");
            AP_Website.AP_HomePage.InputPassword("wrong");
            AP_Website.AP_HomePage.ClickLoginButton();
            Assert.That(AP_Website.AP_HomePage.ErrorMessage, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
        }
        [Test]
        public void GivenIAmOnHomePage_WhenISigninWithAInvalidUsername_ThenIShouldBeGivenAnErrorMessage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUsername("standard_user");
            AP_Website.AP_HomePage.InputPassword("");
            AP_Website.AP_HomePage.ClickLoginButton();
            Assert.That(AP_Website.AP_HomePage.ErrorMessage, Is.EqualTo("Epic sadface: Password is required"));
        }
        [Test]
        public void GivenIAmOnHomePage_WhenISigninWithoutInputtingAnFields_ThenIShouldBeGivenAnErrorMessage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUsername("");
            AP_Website.AP_HomePage.InputPassword("");
            AP_Website.AP_HomePage.ClickLoginButton();
            Assert.That(AP_Website.AP_HomePage.ErrorMessage, Is.EqualTo("Epic sadface: Username is required"));
        }
        [Test]
        public void GivenIAmOnHomePage_WhenISigninWithAValidPassword_ThenIShouldBeGivenAnErrorMessage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUsername("");
            AP_Website.AP_HomePage.InputPassword("secret_sauce");
            AP_Website.AP_HomePage.ClickLoginButton();
            Assert.That(AP_Website.AP_HomePage.ErrorMessage, Is.EqualTo("Epic sadface: Username is required"));
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
