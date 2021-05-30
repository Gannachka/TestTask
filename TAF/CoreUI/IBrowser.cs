using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.UI
{
    public interface IBrowser : IDisposable
    {
        string Url { get; set; }

        string Title { get; }

        string PageSource { get; }

        string CurrentWindowHandle { get; }

        ReadOnlyCollection<string> WindowHandles { get; }

        WebDriverWait WebBrowserWait();

        void Close();

        IOptions Manage();

        INavigation Navigate();

        void Quit();

        ITargetLocator SwitchTo();

        IElement FindElement(By by);

        IReadOnlyCollection<IElement> FindElements(By by);
        Screenshot TakeScreenshot();
    }
}
