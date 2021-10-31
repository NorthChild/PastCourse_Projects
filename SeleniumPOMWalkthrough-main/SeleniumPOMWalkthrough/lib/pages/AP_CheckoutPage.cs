using OpenQA.Selenium;
using SeleniumPOMWalkthrough.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOMWalkthrough.lib.pages
{
    public class AP_CheckoutPage
    {
        private IWebDriver _seleniumDriver;
        public string _cartPageUrl = AppConfigReader.CartPageURL;
        private IWebElement _firstNameField => _seleniumDriver.FindElement(By.Id("first-name"));
        private IWebElement _lastNameField => _seleniumDriver.FindElement(By.Id("last-name"));
        private IWebElement _postcode => _seleniumDriver.FindElement(By.Id("postal-code"));
        private IWebElement _continue => _seleniumDriver.FindElement(By.Id("continue"));
        private IWebElement _finish => _seleniumDriver.FindElement(By.Id("finish"));
        private IWebElement _total => _seleniumDriver.FindElement(By.ClassName("summary_total_label"));
        private IWebElement _errorMessage => _seleniumDriver.FindElement(By.CssSelector("*[data-test=\"error\"]"));
        public AP_CheckoutPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }
        public void VisitCheckoutPage() => _seleniumDriver.Navigate().GoToUrl(_cartPageUrl);
        public void InputFirstName(string firstname) => _firstNameField.SendKeys(firstname);
        public void InputLastName(string lastname) => _lastNameField.SendKeys(lastname);
        public void InputPostCode(string postcode) => _postcode.SendKeys(postcode);
        public string ErrorMessage() => _errorMessage.Text;
        public void InputPersonalDetails(PersonalDetails personalDetails)
        {
            _firstNameField.SendKeys(personalDetails.firstname);
            _lastNameField.SendKeys(personalDetails.lastname);
            _postcode.SendKeys(personalDetails.postcode);
        }
        public void ClickContinue() => _continue.Click();
        public void ClickFinish() => _finish.Click();
        public string TotalCost() => _total.Text;
    }
}
