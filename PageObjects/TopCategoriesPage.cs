using AltimetrikTest.HelperFunctions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AltimetrikTest.PageObjects
{
    public class TopCategoriesPage
    {
        private IWebDriver _webDriver;
        WebDriverWait wait;

        public TopCategoriesPage(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
            wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        }
        //Finding web elements 
        private IWebElement _hamburgerMenuPanel => _webDriver.FindElement(By.Id("nav-hamburger-menu"));
        private IWebElement _hamburgerMenuItem => _webDriver.FindElement(By.XPath("//ul[@class='hmenu hmenu-visible']"));
        private IWebElement _softwareItem => _webDriver.FindElement(By.XPath("//ul[@class='hmenu hmenu-visible hmenu-translateX']//a[text()=' Software ']"));
        private IWebElement _AntiVirusLogo => _webDriver.FindElement(By.XPath("img[alt='Antivirus']"));
        private IWebElement _OfficeLogo => _webDriver.FindElement(By.XPath("//img[@alt='Office']"));
        private IWebElement _ELearningLogo => _webDriver.FindElement(By.XPath("//img[@alt='Elearning']"));
        private IWebElement _EnterpriseSoftwareLogo => _webDriver.FindElement(By.XPath("img[alt='Enterprise software']"));

        public void ClickHamburgerMenuButton()
        {
            waitForElementVisible(By.Id("nav-hamburger-menu"));
            _hamburgerMenuPanel.Click();
            //sometimes menu click fails randomly - hence adding a recovery step to continue the flow.
            try
            {
                waitForElementVisible(By.XPath("//ul[@class='hmenu hmenu-visible']"));
            }catch(Exception e)
            {
                //if menu options are not visible, click at the hamberger menu button once again
                _hamburgerMenuPanel.Click();
            }
        }
        public void SelectHamburgerMenuOption(string itemValue)
        {
            waitForElementVisible(By.XPath("//ul[@class='hmenu hmenu-visible']"));
            IWebElement ul = _hamburgerMenuItem;
            By _menuButtons = By.XPath("//a[@class='hmenu-item']/div");
            IList<IWebElement> options = ul.FindElements(_menuButtons);
            foreach (IWebElement option in options)
            {
                if (itemValue.Equals(option.Text))
                {
                    option.Click();
                    break;
                }
            }
            waitForElementVisible(By.XPath("//ul[@class='hmenu hmenu-visible hmenu-translateX']//a[text()=' Software ']"));
        }
        public void ClickSoftware()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("arguments[0].click();", _softwareItem);
            waitForElementVisible(By.XPath("//div[contains(@class,'bxc-grid__mp-gutter-layout')]//img"));
        }

        public bool VerifyAntivirusLogo()
        {
            IWebElement img = getImgLogo("Antivirus");
            return img.Displayed;
        }

        public bool VerifyOfficeSoftwareLogo()
        {
            IWebElement img = getImgLogo("Office");
            return img.Displayed;
        }

        public bool VerifyELearningLogo()
        {
            IWebElement img = getImgLogo("Elearning");
            return img.Displayed;
        }

        public bool VerifyEntSoftwareLogo()
        {
            IWebElement img = getImgLogo("Enterprise software");
            return img.Displayed;
        }

        private IWebElement getImgLogo(String imgAltName)
        {
            IList<IWebElement> imgLogos = _webDriver.FindElements(By.XPath("//div[contains(@class,'bxc-grid__mp-gutter-layout')]//img"));

            IWebElement resElement = null;
            foreach (var element in imgLogos)
            {
                if (element.GetAttribute("alt").Equals(imgAltName))
                {
                    resElement = element;
                    break;
                }

            }
            return resElement;
        }

        private void waitForElementVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(Utility.menuOptionVisibilityWaitTimeInSecs));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

    }
}
