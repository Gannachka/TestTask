using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Collections.ObjectModel;

namespace Core.UI
{
    public class Element : IElement
    {
        protected IWebElement WebElement;
        protected By By;
        private readonly Browser browser;

        public Element(IWebElement element, By by)
        {
            WebElement = element;
            By = by;
        }
        
        public string TagName => WebElement.TagName;

        public string Text => WebElement.Text;

        public bool Enabled => WebElement.Enabled;

        public bool Selected => WebElement.Selected;

        public Point Location => WebElement.Location;

        public Size Size => WebElement.Size;

        public bool Displayed => WebElement.Displayed;

        public SelectElement SelectElement => throw new NotImplementedException();

        public void Clear()
        {
            WebElement.Clear();
        }

        public void Click() 
        {
           WebElement.Click();
        }

        public IElement FindElement(By by)
        {
            try
            {
                var wait = browser.WebBrowserWait();
                var webElement = wait.Until(drv => drv.FindElement(by));

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
                var wait = browser.WebBrowserWait();
                wait.Until(drv => drv.FindElements(by).Count > 0);
                IReadOnlyCollection<IWebElement> webELements = WebElement.FindElements(by);
                List<IElement> elements = new List<IElement>();

                foreach (IWebElement element in webELements)
                {
                    elements.Add(new Element(element, by));
                }

                return elements.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetAttribute(string attributeName)
        {
            return WebElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return WebElement.GetCssValue(propertyName);
        }

        public string GetProperty(string propertyName)
        {

            return WebElement.GetProperty(propertyName);
        }

        public void SendKeys(string text)
        {
            WebElement.SendKeys(text);
        }

        public void Submit()
        {
            WebElement.Submit();
        }

        IWebElement ISearchContext.FindElement(By by)
        {
            throw new NotImplementedException();
        }

        ReadOnlyCollection<IWebElement> ISearchContext.FindElements(By by)
        {
            throw new NotImplementedException();
        }
    }
}
