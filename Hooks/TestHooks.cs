using OpenQA.Selenium;
using WebDriverManager;

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
            new DriverManager().SetUpDriver(new WebDriverManager.DriverConfigs.Impl.ChromeConfig());
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _scenarioContext["WebDriver"] = _driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver?.Quit();
        }
    }
}
