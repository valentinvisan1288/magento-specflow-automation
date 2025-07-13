using OpenQA.Selenium;
using TechTalk.SpecFlow;
using specflowdemo.Utilities.Config;
using specflowdemo.Utilities;

namespace specflowdemo.StepDefinitions
{
    [Binding]
    public class RegisterSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly RegisterActions _registerActions;

        public RegisterSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            _registerActions = new RegisterActions(_driver);
        }

        [Given("an anonymous user has navigated to create an account from the main page")]
        public void GivenUserNavigatesToRegisterPage()
        {
            _driver.Navigate().GoToUrl(ConfigReader.GetUrl("RegisterPage"));
        }

        [When("the anonymous user submits the mandatory account details")]
        public void WhenUserSubmitsMandatoryDetails()
        {
            string firstName = "Valentin";
            string lastName = "Test";
            string password = "StrongPassword123!";
            string uniqueEmail = DataGenerator.GenerateUniqueEmail();

            _registerActions.FillRegistrationForm(firstName, lastName, uniqueEmail, password);
            _registerActions.SubmitForm();
        }

        [Then("the anonymous user will be redirected to the account page as a registered user")]
        public void ThenUserShouldLandOnAccountPage()
        {
            string expectedUrl = "https://magento.softwaretestingboard.com/customer/account/";
            string actualUrl = _driver.Url;

            if (!actualUrl.StartsWith(expectedUrl))
            {
                throw new Exception($"Expected to land on account page. Actual URL: {actualUrl}");
            }
        }
    }
}
