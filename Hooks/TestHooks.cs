using OpenQA.Selenium;
using specflowdemo.Drivers;
using TechTalk.SpecFlow;
//using ScreenshotImageFormat = OpenQA.Selenium.Screenshot;

namespace specflowdemo.Hooks
{
    [Binding]
    public sealed class TestHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver;

        public TestHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverManager.GetDriver();
            _scenarioContext["WebDriver"] = _driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverManager.QuitDriver();
        }

        //[AfterStep]
        //public void AfterStep()
        //{
        //    if (_scenarioContext.TestError != null)
        //    {
        //        var driver = (IWebDriver)_scenarioContext["WebDriver"];
        //        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        //        string fileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
        //        screenshot.SaveAsFile(fileName, OpenQA.Selenium.Screenshot);
        //    }
        //}
    }
}
