using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AltimetrikTest
{
    public class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static String _dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String _testResultPath = _dir.Replace("bin\\Debug\\net6.0", "TestResults");


        public static ExtentReports ExtentReportInit()
        {

            var _htmlReporter = new ExtentHtmlReporter(_testResultPath);
            _htmlReporter.Config.ReportName = "Altemetrik test automation Report";
            _htmlReporter.Config.DocumentTitle = "Altemetrik test automation Report";
            _htmlReporter.Config.Theme = Theme.Standard;
            _htmlReporter.Start();

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_htmlReporter);
            _extentReports.AddSystemInfo("Application", "Amazon");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            return _extentReports;
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        public static string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot _takesScreenshot = (ITakesScreenshot)driver;
            Screenshot _screenshot = _takesScreenshot.GetScreenshot();
            string _screenshotLocation = Path.Combine(_testResultPath, scenarioContext.ScenarioInfo.Title + ".png");
            _screenshot.SaveAsFile(_screenshotLocation);
            return _screenshotLocation;
        }

    }
}
