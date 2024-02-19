using AltimetrikTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AltimetrikTest.StepDefinitions
{
    [Binding]
    public class AddToCartStepDefinitions : DriverBase
    {
        private IWebDriver _webDriver;
        CartPage _addToCartPage;
        ProductsPage _cartPage;

        public AddToCartStepDefinitions()
        {
            this._webDriver = GetWebDriver;
            this._addToCartPage = new CartPage(_webDriver);
            this._cartPage = new ProductsPage(_webDriver);
        }


        [When(@"User clicks at addtocart button")]
        public void WhenUserClicksAtAddToCartButton()
        {
            _addToCartPage.ClickAddToCartButton();
        }


        [Then(@"User validate added item is present in the shopping cart")]
        public void ThenUserValidateAddedItemIsPresentInTheShoppingCart()
        {
            bool status = false;
            _addToCartPage.ClickCartButton();
            String addedItemName = _cartPage.GetAddedItemName();
            String expResult = (String)ScenarioContext.Current["SelectedItem"];
            if (expResult == addedItemName)
                status = true;
            Assert.That(status, Is.True, "Selected item validated with added item in cart");

        }


    }
}
