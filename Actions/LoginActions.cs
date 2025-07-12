using OpenQA.Selenium;
using specflowdemo.Utilities.Configuration;

namespace MagentoSpecflowAutomation.Actions
{
    public class LoginActions
    {
        private readonly IWebDriver _driver;

        public LoginActions(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl(ConfigReader.GetUrl("LoginPage"));
        }

        public void FillInLoginForm(string emailKey, string passwordKey)
        {
            _driver.FindElement(By.CssSelector(ConfigReader.GetLocator("LoginEmailField")))
                   .SendKeys(ConfigReader.GetAccountValue(emailKey));

            _driver.FindElement(By.CssSelector(ConfigReader.GetLocator("LoginPasswordField")))
                   .SendKeys(ConfigReader.GetAccountValue(passwordKey));
        }

        public void SubmitLogin()
        {
            _driver.FindElement(By.CssSelector(ConfigReader.GetLocator("LoginSubmitButton"))).Click();
        }

        public string GetMyAccountHeader()
        {
            return _driver.FindElement(By.CssSelector(ConfigReader.GetLocator("MyAccountHeader"))).Text;
        }
    }
}
