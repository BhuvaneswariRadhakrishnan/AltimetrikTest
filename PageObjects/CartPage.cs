using AltimetrikTest.HelperFunctions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AltimetrikTest.PageObjects
{
    public class CartPage
    {
        private IWebDriver _webDriver;

        public CartPage(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }
        private IWebElement _addToCartButton => _webDriver.FindElement(By.Id("add-to-cart-button"));
        private IWebElement _cartButton => _webDriver.FindElement(By.XPath("//span[@id='attach-sidesheet-view-cart-button']/span/input"));
        private By _successMsg => By.XPath("//div[@id='attach-added-to-cart-message']//h4");
        
        public void ClickAddToCartButton()
        {
            int i = 0;
            while(this._webDriver.WindowHandles.Count == 1 && i<(Utility.newWindowLaunchWaitTimeInSecs*10))
            {
                // wait for new window to be launched
                Thread.Sleep(100);
                i++;
            }
            this._webDriver.SwitchTo().Window(this._webDriver.WindowHandles[1]);
            
            _addToCartButton.Click();
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(Utility.newWindowLaunchWaitTimeInSecs));
            wait.Until(ExpectedConditions.ElementIsVisible(_successMsg));

        }

        public void ClickCartButton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("arguments[0].click();", _cartButton);

        }

    }
}
