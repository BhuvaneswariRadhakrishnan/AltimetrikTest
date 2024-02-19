using AltimetrikTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AltimetrikTest.StepDefinitions
{
    [Binding]
    public class TopCategoriesStepDefinitions : DriverBase
    {
        TopCategoriesPage _topCategoriesPage;
        private IWebDriver _webDriver;

        public TopCategoriesStepDefinitions()
        {
            this._webDriver = GetWebDriver;
            this._topCategoriesPage = new TopCategoriesPage(_webDriver);
        }

        [When(@"User clicks at Hamburger menu")]
        public void WhenUserClicksAtHamburgerMenu()
        {
            _topCategoriesPage.ClickHamburgerMenuButton();
        }

        [When(@"User selects option ""([^""]*)""")]
        public void WhenUserSelectsOption(string p0)
        {
            _topCategoriesPage.SelectHamburgerMenuOption(p0);
        }

        [When(@"User selects sub menu option Software")]
        public void WhenUserSelectsSubMenuOptionSoftware()
        {
            _topCategoriesPage.ClickSoftware();
        }

        [Then(@"User validates top categories logos displayed")]
        public void ThenUserValidatesTopCategoriesLogosDisplayed()
        {
            Assert.That(_topCategoriesPage.VerifyAntivirusLogo, Is.True, "Antivirus logo validated");
            Assert.That(_topCategoriesPage.VerifyELearningLogo, Is.True, "ELearning logo validated");
            Assert.That(_topCategoriesPage.VerifyEntSoftwareLogo, Is.True, "Enterprise Software logo validated");
            Assert.That(_topCategoriesPage.VerifyOfficeSoftwareLogo, Is.True, "Office Software logo validated");
        }

    }
}
