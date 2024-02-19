using AltimetrikTest.HelperFunctions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AltimetrikTest.PageObjects
{
    public class HomePage
    {
        private IWebDriver _webDriver;

        public HomePage(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }

        private IWebElement amazonLogo => _webDriver.FindElement(By.Id("nav-logo-sprites"));

        public void navigateToAmazonWebsite(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        public Boolean VerifyAmazonLogo()
        {
            Boolean res = false;
            try
            {
                var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(2));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nav-logo-sprites")));
                Utility.highlights(_webDriver, amazonLogo);
                res = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
            return res;
        }

    }
}
