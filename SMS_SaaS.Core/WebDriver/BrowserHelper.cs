using System;
using OpenQA.Selenium;
using SMB_SaaS.Core.Models;
using SMB_SaaS.Core.Utilities;

namespace SMB_SaaS.Core
{
    public class BrowserHelper
    {
        private static BrowserHelper _currentInstance;
        private static BrowserFactory.BrowserType CurrentBrowser;
        private static IWebDriver _driver;
        private static Settings TestSettings => Configuration.Settings;
        
        public static BrowserHelper Instance => _currentInstance ?? (_currentInstance = new BrowserHelper());

        public static IWebDriver GetDriver()
        {
            return _driver;
        }

        public static void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public static void Quit()
        {
            _driver.Quit();
            _driver = null;
            _currentInstance = null;
        }
        
        private BrowserHelper()
        {
            if (!Enum.TryParse(TestSettings.Browser, out CurrentBrowser))
            {
                CurrentBrowser = BrowserFactory.BrowserType.Chrome;
            };

            _driver = BrowserFactory.GetDriver(CurrentBrowser, 30);
        }
    }
}
