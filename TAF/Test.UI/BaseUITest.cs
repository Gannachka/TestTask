using NUnit.Framework;
using Core;
using Core.UI;
using System;

namespace Test.UI
{
    public class BaseUITest : BaseTest
    {
        protected IBrowser Browser;
        [SetUp]
        public void Setup()
        {
            Browser = BrowserSingleton.GetBrowser(ApplicationConfig.BrowserName);
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl(ApplicationConfig.URL);
        }

        [TearDown]
        public void CloseBrowser()
        {
            BrowserSingleton.ReleaseInstance();
            Browser.Close();
            Browser.Quit();
        }
    }
}