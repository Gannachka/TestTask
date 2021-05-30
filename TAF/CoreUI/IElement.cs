using OpenQA.Selenium;
using System.Collections.Generic;
using System.Drawing;

namespace Core.UI
{
    public interface IElement
    {
        string TagName { get; }

        string Text { get; }

        bool Enabled { get; }

        bool Selected { get; }

        Point Location { get; }

        Size Size { get; }

        bool Displayed { get; }

        void Clear();

        void Click();

        string GetAttribute(string attributeName);

        string GetCssValue(string propertyName);

        string GetProperty(string propertyName);

        void SendKeys(string text);
        void Submit();

        IElement FindElement(By by);

        IReadOnlyCollection<IElement> FindElements(By by);
    }
}
