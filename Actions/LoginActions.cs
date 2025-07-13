using OpenQA.Selenium;
using specflowdemo.Utilities.Config;


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
            _driver.FindElement(By.CssSelector(ConfigReader.GetSetting("LoginEmailInput")))
                   .SendKeys(ConfigReader.GetCredential("ValidEmail"));

            _driver.FindElement(By.CssSelector(ConfigReader.GetSetting("LoginPasswordInput")))
                   .SendKeys(ConfigReader.GetCredential(passwordKey));
        }

        public void SubmitLogin()
        {
            _driver.FindElement(By.CssSelector(ConfigReader.GetSetting("LoginSubmitButton"))).Click();
        }

        public string GetMyAccountHeader()
        {
            return _driver.FindElement(By.CssSelector(ConfigReader.GetSetting("MyAccountHeader"))).Text;
        }
    }
}
