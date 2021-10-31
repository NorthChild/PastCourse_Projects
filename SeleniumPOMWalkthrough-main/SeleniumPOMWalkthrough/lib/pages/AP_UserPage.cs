using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOMWalkthrough.lib.pages
{
    public class AP_UserPage
    {
        private IWebDriver _seleniumDriver;
        private string _UserPageUrl = AppConfigReader.UserPageURL;
        private IWebElement _shoppingCartButton => _seleniumDriver.FindElement(By.Id("shopping_cart_container"));
        private IWebElement _header => _seleniumDriver.FindElement(By.Id("header_container"));
        private IWebElement _addBackPackToCart => _seleniumDriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement _addLightToCart => _seleniumDriver.FindElement(By.Name("add-to-cart-sauce-labs-bike-light"));
        private IWebElement _addTShirtToCart => _seleniumDriver.FindElement(By.Name("add-to-cart-sauce-labs-bolt-t-shirt"));
        private IWebElement _addFleeceToCart => _seleniumDriver.FindElement(By.Name("add-to-cart-sauce-labs-fleece-jacket"));
        private IWebElement _addOnesieToCart => _seleniumDriver.FindElement(By.Name("add-to-cart-sauce-labs-onesie"));
        private IWebElement _addRedTShirtToCart => _seleniumDriver.FindElement(By.Name("add-to-cart-test.allthethings()-t-shirt-(red)"));
        private IWebElement _checkoutButton => _seleniumDriver.FindElement(By.Id("checkout"));
        public AP_UserPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }
        public void GoToUserPage() => _seleniumDriver.Navigate().GoToUrl(_UserPageUrl);
        public void ClickShoppingButton() => _shoppingCartButton.Click();
        public string GetHeaderText() => _header.Text;
        public void ClickAddAllToCart()
        {
            _addBackPackToCart.Click();
            _addTShirtToCart.Click();
            _addFleeceToCart.Click();
            _addOnesieToCart.Click();
            _addLightToCart.Click();
            _addRedTShirtToCart.Click();
        }
        public void ClickCheckoutButton() => _checkoutButton.Click();
    }
}
