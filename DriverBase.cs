using OpenQA.Selenium;

namespace AltimetrikTest
{
    public class DriverBase
    {
        private static IWebDriver _webDriver = null;

        public static IWebDriver GetWebDriver
        {
            get { return _webDriver; }
            set { _webDriver = value; }
        }
    }
}
