using OpenQA.Selenium;
using specflowdemo.Utilities.Config;
using MagentoSpecflowAutomation.Actions;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;

namespace specflowdemo.StepDefinitions
{
    [Binding]
    public class RegisterSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly RegisterActions _registerActions;
        private readonly LoginActions _loginActions;

        public RegisterSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            _registerActions = new RegisterActions(_driver);
            _loginActions = new LoginActions(_driver);
        }

        [Given("an anonymous user has navigated to create an account from the main page")]
        public void GivenUserNavigatesToRegisterPage()
        {
            _registerActions.NavigateToRegisterPage();
        }

        [When("the anonymous user submits the mandatory account details")]
        public void WhenUserSubmitsMandatoryDetails()
        {
            _loginActions.DismissNoticeIfPresent();
            _registerActions.FillRegistrationForm();
            _registerActions.SubmitForm();
        }

        [Then("the anonymous user will be redirected to the account page as a registered user")]
        public void ThenUserShouldLandOnAccountPage()
        {
            _loginActions.IsAccountPageDisplayed().Should().BeTrue("User should be redirected to the account page after registration.");
        }
    }
}
