using AltimetrikTest.HelperFunctions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AltimetrikTest.PageObjects
{
    public class ProductsPage
    {
        private IWebDriver _webDriver;

        public ProductsPage(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }
        private IWebElement _addedItemTitle => _webDriver.FindElement(By.XPath("//span[contains(@class,'sc-product-title sc-grid-item-product-title')]//span[@class='a-truncate-cut']"));

        public String GetAddedItemName()
        {
            String res = "";
            if (_addedItemTitle != null)
                res = _addedItemTitle.Text;
            return res;
        }

    }
}
