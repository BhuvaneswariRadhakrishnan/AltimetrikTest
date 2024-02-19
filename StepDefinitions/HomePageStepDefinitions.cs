using OpenQA.Selenium;
using AltimetrikTest.PageObjects;
using TechTalk.SpecFlow;

namespace AltimetrikTest.StepDefinitions
{
    [Binding]
    public class HomePageStepDefinitions : DriverBase
    {
        HomePage _homePageObject;
        private IWebDriver _webDriver;

        public HomePageStepDefinitions()
        {
            this._webDriver = GetWebDriver;
            this._homePageObject = new HomePage(_webDriver);

        }     

        [Given(@"User has navigated to Amazon website of url ""([^""]*)""")]
        public void GivenUserHasNavigatedToAmazonWebsiteOfUrl(string url)
        {
            _homePageObject.navigateToAmazonWebsite(url);
        }

        [Given(@"User validate Amazon logo in top left corner")]
        [Then(@"User validate Amazon logo in top left corner")]
        public void ThenUserValidateAmazonLogoInTopLeftCorner()
        {
            _homePageObject.VerifyAmazonLogo();
        }

    }
}
