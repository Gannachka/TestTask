using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.UI
{
    public class BrowserFactory
    {
        public static IBrowser Create(BrowserName browserName)
        {
            IWebDriver driver = WebDriverFactory.CreateWebDriver(browserName);

            return new Browser(driver);
        }
    }
}
