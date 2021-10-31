using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumPOMWalkthrough.lib.pages;
using SeleniumPOMWalkthrough.utils;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumPOMWalkthrough.BDD
{
    [Binding]
    public class AP_SigninSteps
    {
        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();
        private Credentials _credentials;
        [Given(@"I am on signin page")]
        public void GivenIAmOnSigninPage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
        }
        [Given(@"I have the following Credentials")]
        public void GivenIHaveTheFollowingCredentials(Table table)
        {
            _credentials = table.CreateInstance<Credentials>();
        }
        [When(@"I enter the credentials")]
        public void WhenIEnterTheCredentials()
        {
            AP_Website.AP_HomePage.InputSigninCredentials(_credentials);
        }
        [When(@"I click the sign in button")]
        public void WhenIClickTheSignInButton()
        {
            AP_Website.AP_HomePage.ClickLoginButton();
        }       
        [Then(@"I should be on the next page")]
        public void ThenIShouldBeOnTheNextPage()
        {
            Assert.That(AP_Website.SeleniumDriver.Url.Contains("inventory"));
        }
        [Then(@"I should be given a message saying ""(.*)""")]
        public void ThenIShouldBeGivenAMessageSaying(string expected)
        {
            Assert.That(AP_Website.AP_HomePage.ErrorMessage, Is.EqualTo(expected));
        }
        [AfterScenario]
        public void DisposeWebDriver()
        {
            AP_Website.SeleniumDriver.Quit();
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}
