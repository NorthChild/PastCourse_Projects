using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumPOMWalkthrough.lib.driver_config;


namespace SeleniumPOMWalkthrough.lib.pages
{
    // Super class - essentially a service object for all pages
    public class AP_Website<T> where T : IWebDriver, new()
    {
        #region
        // Properties - accessing POs and Selenium Driver
        public IWebDriver SeleniumDriver { get; set; }
        public AP_HomePage AP_HomePage { get; set; }
        public AP_UserPage AP_UserPage { get; set; }
        public AP_ItemPage AP_ItemPage { get; set; }
        public AP_CheckoutPage AP_CheckoutPage { get; set; }
        #endregion
        // Constructor for driver and config for the service
        public AP_Website(int pageLoadInSecs = 10, int implicitWaitInSecs = 10)
        {
            // Instantiate the driver
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInSecs, implicitWaitInSecs).Driver;
            // Instantiate the page objects with the Selenium driver
            AP_HomePage = new AP_HomePage(SeleniumDriver);
            AP_UserPage = new AP_UserPage(SeleniumDriver);
            AP_ItemPage = new AP_ItemPage(SeleniumDriver);
            AP_CheckoutPage = new AP_CheckoutPage(SeleniumDriver);
        }
        public void DeleteCookies() => SeleniumDriver.Manage().Cookies.DeleteAllCookies();
    }
}
