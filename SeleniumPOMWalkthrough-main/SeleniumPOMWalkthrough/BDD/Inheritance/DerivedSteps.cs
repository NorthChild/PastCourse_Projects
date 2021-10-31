using NUnit.Framework;
using SeleniumPOMWalkthrough.utils;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(8)]
namespace SeleniumPOMWalkthrough.BDD
{
    [Binding]
    [Scope(Tag ="Base")]
    public class SigninSteps : BaseSteps
    {
        [Given(@"I want to sign in")]
        public override void GivenIWantToSignIn()
        {
            base.GivenIWantToSignIn();
        }
        
        [Given(@"the following details")]
        public override void GivenTheFollowingDetails(Table table)
        {
            base.GivenTheFollowingDetails(table);
        }
        
        [When(@"I press sign in")]
        public override void WhenIPressSignIn()
        {
            base.WhenIPressSignIn();
        }
        
        [Then(@"I can see the next page")]
        public override void ThenICanSeeTheNextPage()
        {
            base.ThenICanSeeTheNextPage();
        }
        [AfterScenario]
        public void DisposeWebDriver()
        {
            AP_Website.SeleniumDriver.Quit();
        }
    }
}
