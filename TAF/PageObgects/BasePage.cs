using Core.UI;
using System;

namespace PageObgects
{
    public class BasePage
    {
        protected IBrowser Driver;


        protected BasePage(IBrowser driver)
        {
            Driver = driver;
        }
    }
}
