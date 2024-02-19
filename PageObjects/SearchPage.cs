using AltimetrikTest.HelperFunctions;
using OpenQA.Selenium;

namespace AltimetrikTest.PageObjects
{
    public class SearchPage
    {
        private IWebDriver _webDriver;

        public SearchPage(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }
        private IWebElement _searchTextBox => _webDriver.FindElement(By.Id("twotabsearchtextbox"));
        private IWebElement _searchButton => _webDriver.FindElement(By.Id("nav-search-submit-button"));
        private IWebElement _searchResultText => _webDriver.FindElement(By.XPath("//span[@class='a-color-state a-text-bold']"));
        private IList<IWebElement> _searchedItems => _webDriver.FindElements(By.XPath("//div[@class='a-section a-spacing-none puis-padding-right-small s-title-instructions-style']/h2/a/span"));
        public void FeedSearchInput(string searchText)
        {
            _searchTextBox.SendKeys(searchText);
            Utility.highlights(_webDriver, _searchTextBox);

        }

        public void ClearSearchInput()
        {
            _searchTextBox.Clear();
            Utility.highlights(_webDriver, _searchTextBox);

        }
        public void ClickSearchButton()
        {
            _searchButton.Click();
            Utility.highlights(_webDriver, _searchButton);
        }
        public string GetSearchResult()
        {
            string searchedItem = _searchResultText.Text.Replace("\"", "");
            Utility.highlights(_webDriver, _searchResultText);
            return searchedItem;
        }

        public bool ValidateSearchResult(string expRes)
        {
            bool flag = false;
            flag = GetSearchResult().Equals(expRes);
            return flag;
        }

        public string SelectFirstItemInResults()
        {
            string res = "";
            if (_searchedItems.Count > 0)
            {
                Utility.highlights(_webDriver, _searchedItems[0]);
                res = _searchedItems[0].Text;
                _searchedItems[0].Click();
            }

            return res;
        }

    }
}
