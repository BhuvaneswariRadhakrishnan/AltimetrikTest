using System.Text;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;
using System.Drawing;

namespace AltimetrikTest
{
    [Binding]
    public class Hooks
    {
        private static ExtentTest _featureName;
        private static ExtentTest _scenario;
        private static ExtentReports _extentReports;
        public static IWebDriver _driver = null;

        [BeforeTestRun()]
        public static void BeforTestRun()
        {
            _extentReports = ExtentReport.ExtentReportInit();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            _driver = new ChromeDriver();
            DriverBase.GetWebDriver = _driver;
            _driver.Manage().Window.Maximize();
            _featureName = _extentReports.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            Console.WriteLine("BeforeFeature");
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            Console.WriteLine("BeforeScenario");
            _scenario = _featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }


        [AfterFeature]
        public static void AfterFeature()
        {
            _driver.Quit();
        }

        [AfterStep]
        public static void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    _scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                string screenShotPath = ExtentReport.addScreenshot(_driver, ScenarioContext.Current);

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                }
            }
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            _driver.Quit();
            ExtentReport.ExtentReportTearDown();
        }

    }
}
