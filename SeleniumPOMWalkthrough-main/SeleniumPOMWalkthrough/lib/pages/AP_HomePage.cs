using OpenQA.Selenium;
using SeleniumPOMWalkthrough.utils;

namespace SeleniumPOMWalkthrough.lib.pages
{
    public class AP_HomePage
    {
        #region
        private IWebDriver _seleniumDriver;
        // Set the homepageurl
        private string _homePageUrl = AppConfigReader.BaseURL;
        // Create a private property that modelss the sing in link
        private IWebElement _signinButton => _seleniumDriver.FindElement(By.Id("login-button"));
        private IWebElement _passwordField => _seleniumDriver.FindElement(By.Id("password"));
        private IWebElement _usernameField => _seleniumDriver.FindElement(By.Id("user-name"));
        private IWebElement _errorMessage => _seleniumDriver.FindElement(By.CssSelector("*[data-test=\"error\"]"));
        //private IWebElement _errorMessage => _seleniumDriver.FindElement(By.CssSelector("css=*[data-test="error"]"));
        #endregion
        // Constructor that sets the driver to be driver from the config
        public AP_HomePage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;
        // Methods to interact with the web element
        public void VisitHomePage() => _seleniumDriver.Navigate().GoToUrl(_homePageUrl);
        public void ClickLoginButton() => _signinButton.Click();
        public void InputUsername(string username) => _usernameField.SendKeys(username);
        public void InputPassword(string password) => _passwordField.SendKeys(password);
        public string ErrorMessage() => _errorMessage.Text;
        public void InputSigninCredentials(Credentials credentials)
        {
            _usernameField.SendKeys(credentials.Email);
            _passwordField.SendKeys(credentials.Password);
        }
    }
}
