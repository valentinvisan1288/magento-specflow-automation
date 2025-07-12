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
            _driver.FindElement(By.CssSelector(LocatorReader.Get("LoginEmailField")))
                   .SendKeys(LocatorReader.Get(emailKey));

            _driver.FindElement(By.CssSelector(LocatorReader.Get("LoginPasswordField")))
                   .SendKeys(LocatorReader.Get(passwordKey));
        }

        public void SubmitLogin()
        {
            _driver.FindElement(By.CssSelector(LocatorReader.Get("LoginSubmitButton"))).Click();
        }

        public string GetMyAccountHeader()
        {
            return _driver.FindElement(By.CssSelector(LocatorReader.Get("MyAccountHeader"))).Text;
        }
    }
}
