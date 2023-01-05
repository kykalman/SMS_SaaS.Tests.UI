using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using WebDriverManager;
using System;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SMB_SaaS.Core
{
	public class BrowserFactory
	{
		public enum BrowserType
		{
			Chrome,
			Firefox,
			remoteFirefox,
			remoteChrome
		}

		public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
		{
			IWebDriver driver = null;

			switch (type)
			{
				case BrowserType.Chrome:
					{
						new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
						var service = ChromeDriverService.CreateDefaultService();
						var option = new ChromeOptions();
						option.AddArgument("disable-infobars");
						option.AddArgument("--start-maximized");
						option.AddArguments("--no-sandbox");
						//option.AddArguments("--headless");
						//option.AddArguments("--disable-gpu");
						//option.AddArguments("--ignore-certificate-errors");
						//option.AddArguments("--allow-running-insecure-content");
						driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
						break;
					}
				case BrowserType.Firefox:
					{
						var service = FirefoxDriverService.CreateDefaultService();
						var options = new FirefoxOptions();
						driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
						break;
					}
				case BrowserType.remoteFirefox:
					{
						var cability = new FirefoxOptions();
						driver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), cability);
						break;
					}
				case BrowserType.remoteChrome:
					{
						var option = new ChromeOptions();
						option.AddArgument("disable-infobars");
						option.AddArgument("--start-maximized");
						option.AddArgument("--no-sandbox");
						driver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), option.ToCapabilities());
						break;
					}
			}
			return driver;
		}
	}
}
