using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOMWalkthrough.lib.pages
{
    public class AP_ItemPage
    {
        private IWebDriver _seleniumDriver;
        private string _ItemPageUrl = AppConfigReader.ItemPageURL;
        private IWebElement _itemPrice => _seleniumDriver.FindElement(By.ClassName("inventory_details_price"));
        private IWebElement _itemName => _seleniumDriver.FindElement(By.CssSelector("div.inventory_details_name.large_size"));
        private IWebElement _addToCart => _seleniumDriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement _removeFromCart => _seleniumDriver.FindElement(By.Id("remove-sauce-labs-backpack"));
        private IWebElement _noOfItemsInBasket => _seleniumDriver.FindElement(By.ClassName("shopping_cart_badge"));
        public AP_ItemPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }
        public string GetItemName() => _itemName.Text;
        public void GoToItemPage() => _seleniumDriver.Navigate().GoToUrl(_ItemPageUrl);
        public string GetItemPrice() => _itemPrice.Text;
        public void AddToCart() => _addToCart.Click();
        public string GetQuantity() => _noOfItemsInBasket.Text;
        public void RemoveFromCart() => _removeFromCart.Click();
    }
}
