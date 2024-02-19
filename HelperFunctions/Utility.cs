using OpenQA.Selenium;

namespace AltimetrikTest.HelperFunctions
{
	public class Utility
	{
		public static int menuOptionVisibilityWaitTimeInSecs = 10;
		public static int newWindowLaunchWaitTimeInSecs = 60;
		public static IJavaScriptExecutor highlights(IWebDriver _driver, IWebElement element)
		{
			IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
			js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "color: red; border: 3px solid green;");

			js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "");
			return js;
		}

	}

}
