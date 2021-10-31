using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SeleniumPOMWalkthrough
{
    // This class is created to be a global reader for the app.config attributes
    public static class AppConfigReader
    {
        public static readonly string BaseURL = ConfigurationManager.AppSettings["base_url"];
        public static readonly string UserPageURL = ConfigurationManager.AppSettings["userpage_url"];
        public static readonly string ItemPageURL = ConfigurationManager.AppSettings["item_url"];
        public static readonly string CartPageURL = ConfigurationManager.AppSettings["cart_url"];
    }
}
