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

        public void FillInInvalidLoginForm(string emailKey, string passwordKey)
        {
            _driver.FindElement(By.CssSelector(ConfigReader.GetSetting("InvalidEmail")))
                   .SendKeys(ConfigReader.GetCredential("ValidEmail"));

            _driver.FindElement(By.CssSelector(ConfigReader.GetSetting("InvalidPassword")))
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

        public void NavigateToLoginPage(string url)
        {
            _driver.Navigate().GoToUrl(ConfigReader.GetUrl("LoginPage"));
        }
        public void Login(string email, string password)
        {
            _driver.FindElement(By.CssSelector(ConfigReader.GetSetting("LoginEmailInput"))).SendKeys(email);
            _driver.FindElement(By.CssSelector(ConfigReader.GetSetting("LoginPasswordInput"))).SendKeys(password);
            _driver.FindElement(By.CssSelector(ConfigReader.GetSetting("SignInButton"))).Click();
        }

        public bool IsAccountPageDisplayed()
        {
            try
            {
                return _driver.Url.Contains("/customer/account");
            }
            catch
            {
                return false;
            }
        }

        public bool IsLoginErrorMessageVisible()
        {
            try
            {
                var errorElement = _driver.FindElement(By.XPath(ConfigReader.GetSetting("LoginErrorMessage")));
                return errorElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
