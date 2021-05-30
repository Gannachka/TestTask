using Core.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace PageObgects
{
    public class MainPage : BasePage
    {
        public MainPage(IBrowser driver) : base(driver)
        {
            this.Driver = driver;
        }

        public IElement SignIn => Driver.FindElement(By.XPath("//a[@class='header__auth text_theme_auth']"));
        public IElement TradingItem => Driver.FindElement(By.XPath("//a[@href='/trading']"));
        public IElement LanguageChanging => Driver.FindElement(By.Id("list-language"));
        public IElement LanguageDroppDown => Driver.FindElement(By.Id("list-language-list"));
        public IElement LanguageList => Driver.FindElement(By.Id("list-language_listbox"));
        public IElement PlaceLimitButton => Driver.FindElement(By.Id("advanced-limit-trade"));
        public IElement ExchangeTab => Driver.FindElement(By.Id("exchange"));
        public IElement TutorialLink => Driver.FindElement(By.Id("tutorial-steps"));
        public IElement MarketWatchButton => Driver.FindElement(By.XPath("//*[@id='open-market-watch']//span[1]"));
        public IElement EnglishChecking => Driver.FindElement(By.XPath("//*[@id='list-language_listbox']//li//a[@data-code='en']"));
        public IElement RussianChecking => Driver.FindElement(By.XPath("//*[@id='list-language_listbox']//li//a[@data-code='ru']"));
        public IElement Language => Driver.FindElement(By.XPath("//span[@class='k-widget k-dropdown k-header select_theme_language select_theme_custom text_theme_input']/span/span[1]"));
        
        public IReadOnlyCollection<IElement> LanguageDroppDownItems => Driver.FindElements(By.XPath("//*[@id='list-language_listbox']/child::li"));

        public void LanguageChangingClick()
        {
            if (SignIn.Displayed)
            {
                Thread.Sleep(3000);
                LanguageChanging.Click();
            }
        }

        public TradingPage TradingClick()
        {  
            TradingItem.Click();
            Driver.Navigate().GoToUrl(TradingItem.GetAttribute("href"));

            return new TradingPage(Driver);
        }

        public bool LanguageDroppDownCheking => LanguageDroppDown.Displayed;

        public bool CheckingChangingLanguage(string russian)
        {
            LanguageChanging.Click();
            if (Language.Text == russian)
            {
                 return true;
            }
            else
            {
                 return false;
            }
        }
       
    }
}
