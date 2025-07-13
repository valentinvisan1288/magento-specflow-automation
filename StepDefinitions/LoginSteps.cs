using OpenQA.Selenium;
using specflowdemo.Utilities.Config;
using TechTalk.SpecFlow;
using MagentoSpecflowAutomation.Actions;
using FluentAssertions;


namespace specflowdemo.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly LoginActions _loginActions;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            _loginActions = new LoginActions(_driver);
        }

        [Given("a registered user has navigated to the login page from the main page")]
        [Given("an anonymous user has navigated to the login page from the main page")]
        public void GivenUserNavigatesToLoginPage()
        {
            _loginActions.NavigateToLoginPage();
        }

        [When("the registered user submits valid login credentials")]
        public void WhenRegisteredUserSubmitsValidCredentials()
        {
            _loginActions.FillInLoginForm(
                ConfigReader.GetCredential("ValidEmail"),
                ConfigReader.GetCredential("ValidPassword")
            );
        }

        [When("the anonymous user submits invalid login credentials")]
        public void WhenAnonymousUserSubmitsInvalidCredentials()
        {
            _loginActions.FillInInvalidLoginForm(
                ConfigReader.GetCredential("InvalidEmail"),
                ConfigReader.GetCredential("InvalidPassword")
            );
        }

        [Then("the registered user will be redirected to the account page")]
        public void ThenUserRedirectedToAccountPage()
        {
            _loginActions.IsAccountPageDisplayed().Should().BeTrue("the user should land on the account page");
        }

        [Then("the anonymous user will remain on the login page and see an error message")]
        public void ThenLoginErrorIsDisplayed()
        {
            _loginActions.IsLoginErrorMessageVisible().Should().BeTrue("an error message should be shown for invalid credentials");
        }
    }
}
