using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Core;

namespace Core.UI
{
    public class Browser : IBrowser
    {
        private IWebDriver webDriver;
        private int waitTimeInSeconds = ApplicationConfig.ExplicitTimeout;

        public Browser(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public void ImplicitWaight(double seconds)
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
           
        public Actions actions => new Actions(webDriver);
        public WebDriverWait DriverWait => new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitTimeInSeconds));
       
        public IElement FindElement(By by)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitTimeInSeconds));
               var webElement = wait.Until(drv => drv.FindElement(by));

                Logger.Information("Element was found {0}", by);

                  return new Element(webElement, by);
            }
            catch (Exception e)
            {
             
                throw e;
            }
        }
       

        public IReadOnlyCollection<IElement> FindElements(By by)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitTimeInSeconds));
                wait.Until(drv => drv.FindElements(by).Count > 0);
                var webElements = webDriver.FindElements(by);
                var elements = new List<IElement>();

                foreach (IWebElement webElement in webElements)
                {
                    elements.Add(new Element(webElement, by));
                }

                return elements.ToList();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string Url
        {
            get => webDriver.Url;
            set => webDriver.Url = value;
        }

        public string Title => webDriver.Title;

        public WebDriverWait WebBrowserWait() => new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitTimeInSeconds));

        public string PageSource => webDriver.PageSource;

        public string CurrentWindowHandle => webDriver.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => webDriver.WindowHandles;

        public IOptions Manage()
        {
            return webDriver.Manage();
        }

        public INavigation Navigate()
        {
            return webDriver.Navigate();
        }

        public ITargetLocator SwitchTo()
        {
            return webDriver.SwitchTo();
        }

        public Screenshot TakeScreenshot()
        {
            return ((ITakesScreenshot)webDriver).GetScreenshot();
        }

        public void Quit()
        {
            webDriver.Quit();
        }

        public void Close()
        {
            webDriver.Close();
        }

        public void Dispose()
        {
            webDriver.Dispose();
        }
    }
}
