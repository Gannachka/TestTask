using Core.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObgects
{
    public class TradingPage : BasePage
    {
        public TradingPage(IBrowser driver) : base(driver)
        {
            this.Driver = driver;
        }

        public string URL => Driver.Url;
        
    }
}
