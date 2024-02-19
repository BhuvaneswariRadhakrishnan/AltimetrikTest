using NUnit.Framework;
using OpenQA.Selenium;
using AltimetrikTest.PageObjects;
using TechTalk.SpecFlow;

namespace AltimetrikTest.StepDefinitions
{
    [Binding]
    public class SearchItemsStepDefinitions : DriverBase
    {
        SearchPage _searchPageObject;
        private IWebDriver _webDriver;

        public SearchItemsStepDefinitions()
        {
            this._webDriver = GetWebDriver;
            this._searchPageObject = new SearchPage(_webDriver);

        }


        [When(@"User clears search box")]
        public void WhenUserClearsSearchBox()
        {
            _searchPageObject.FeedSearchInput("");
        }

        [When(@"User clicks at search button")]
        public void WhenUserClicksAtSearchButton()
        {
            _searchPageObject.ClickSearchButton();
        }



        [When(@"User enters ""([^""]*)"" in search inputbox")]
        public void WhenUserEntersInSearchInputbox(string productName)
        {
            _searchPageObject.ClearSearchInput();
            _searchPageObject.FeedSearchInput(productName);
        }

        [Then(@"User validates ""([^""]*)"" in search result info bar")]
        public void ThenUserValidatesInSearchResultInfoBar(string expName)
        {
            Assert.That(_searchPageObject.ValidateSearchResult(expName), Is.True, "Search text validated with serach result info bar value");

        }

        [When(@"User select first item from list")]
        public void WhenUserSelectFirstItemFromList()
        {
            String _selectedItem = _searchPageObject.SelectFirstItemInResults();
            ScenarioContext.Current.Add("SelectedItem", _selectedItem);
        }




    }
}
