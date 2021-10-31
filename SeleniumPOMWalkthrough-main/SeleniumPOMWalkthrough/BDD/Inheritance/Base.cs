using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumPOMWalkthrough.lib.pages;
using SeleniumPOMWalkthrough.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumPOMWalkthrough.BDD
{
    public class BaseSteps
    {
        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();
        private Credentials _credentials;
        [Given(@"I want to sign in")]
        public virtual void GivenIWantToSignIn() 
        {
            AP_Website.AP_HomePage.VisitHomePage();
        }

        [Given(@"the following details")]
        public virtual void GivenTheFollowingDetails(Table table)
        {
            _credentials = table.CreateInstance<Credentials>();
            AP_Website.AP_HomePage.InputSigninCredentials(_credentials);
        }

        [When(@"I press sign in")]
        public virtual void WhenIPressSignIn()
        {
            AP_Website.AP_HomePage.ClickLoginButton();
        }

        [Then(@"I can see the next page")]
        public virtual void ThenICanSeeTheNextPage()
        {
            Assert.That(AP_Website.SeleniumDriver.Url.Contains("inventory"));
        }
    }
}
