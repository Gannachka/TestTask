using Core;
using Core.UI;
using System;
using System.Threading;

namespace CoreUI
{
    public class BrowserSingleton
    {
        private static ThreadLocal<IBrowser> instance = new ThreadLocal<IBrowser>();

        public static IBrowser GetBrowser(BrowserName browserName)
        {
            if (instance.Value == null)
            {
                instance.Value = BrowserFactory.Create(browserName);
            }

            return instance.Value;
        }

        public static void ReleaseInstance()
        {
            instance.Value = null;
        }
    }
}
