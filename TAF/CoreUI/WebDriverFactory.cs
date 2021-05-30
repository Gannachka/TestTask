using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;

namespace Core.UI
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(BrowserName browser)
        {
            IWebDriver driver;

            switch (browser)
            {
                case BrowserName.Chrome:
                    var chromeOption = new ChromeOptions();
                    chromeOption.AddArgument("headless");
                    driver = new ChromeDriver(chromeOption);
                    break;
                case BrowserName.FireFox:
                    var fireFoxOptions = new FirefoxOptions();
                    fireFoxOptions.AddArgument("--headless");
                    driver = new FirefoxDriver(fireFoxOptions);
                    break;
                case BrowserName.Opera:
                    driver = new OperaDriver();
                    break;
                default:
                    throw new PlatformNotSupportedException($"{browser} is not currently supported.");
            }

            return driver;
        }
    }
}
