using NUnit.Framework;
using PageObgects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Test.UI
{
    [TestFixture]
    public class MainPageTest:BaseUITest
    {
        [TestCase("Русский",2)]
        public void LanguageChekingTest(string russian, int count)
        {
            MainPage mainPage = new MainPage(Browser);

            mainPage.LanguageChangingClick();
            mainPage.LanguageDroppDownCheking.Should().BeTrue();
            mainPage.LanguageDroppDownItems.Count.Should().Be(count);
            mainPage.RussianChecking.Should().NotBeNull();
            mainPage.EnglishChecking.Should().NotBeNull();

            if (!mainPage.CheckingChangingLanguage(russian))
            {
                mainPage.MarketWatchButton.Text.Should().Contain("MARKET WATCH");
                mainPage.PlaceLimitButton.Text.Should().Contain("PLACE LIMIT");
                mainPage.ExchangeTab.Text.Should().Contain("EXCHANGE");
                mainPage.TutorialLink.Text.Should().Contain("Tutorial");
            }
              
        }

        [TestCase ("https://demo-ticktrader.free2ex.com/trading")]
        public void TradingPageTest(string tradingUrl)
        {
            MainPage mainPage = new MainPage(Browser);
            mainPage.TradingClick().URL.Should().Contain(tradingUrl);
           
        }
    }
}
