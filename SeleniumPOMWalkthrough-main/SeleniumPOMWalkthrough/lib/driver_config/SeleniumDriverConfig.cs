using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOMWalkthrough.lib.driver_config
{
    public class SeleniumDriverConfig<T> where T : IWebDriver, new()
    {
        public IWebDriver Driver { get; set; }
        // Constructor which calls a method to set up the driver depening oon the browser we want
        public SeleniumDriverConfig(int pageLoadInSecs, int implicitWaitInSec)
        {
            Driver = new T();
            DriverSetup(pageLoadInSecs, implicitWaitInSec);
        }

        public void DriverSetup(int pageLoadInSecs, int implicitWaitInSec)
        {
            // This is the time the driver will wait for teh apge to load
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSecs);
            // This is the time the driver waits for the element before the test fails
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSec);
        }
        public void SetHeadlessChromeBrowser()
        {
            Driver = new ChromeDriver();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
        }
    }
}
