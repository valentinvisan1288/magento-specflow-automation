using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
            _driver.FindElement(By.XPath(ConfigReader.GetSetting("LoginEmailInput")))
                   .SendKeys(ConfigReader.GetSetting("ValidEmail"));

            _driver.FindElement(By.XPath(ConfigReader.GetSetting("LoginPasswordInput")))
                   .SendKeys(ConfigReader.GetSetting(passwordKey));
        }

        public void FillInInvalidLoginForm(string emailKey, string passwordKey)
        {
            _driver.FindElement(By.XPath(ConfigReader.GetSetting("InvalidEmail")))
                   .SendKeys(ConfigReader.GetSetting("ValidEmail"));

            _driver.FindElement(By.XPath(ConfigReader.GetSetting("InvalidPassword")))
                   .SendKeys(ConfigReader.GetSetting(passwordKey));
        }

        public void SubmitLogin()
        {
            _driver.FindElement(By.XPath(ConfigReader.GetSetting("LoginSubmitButton"))).Click();
        }

        public string GetMyAccountHeader()
        {
            return _driver.FindElement(By.XPath(ConfigReader.GetSetting("MyAccountHeader"))).Text;
        }

        public void NavigateToLoginPage(string url)
        {
            _driver.Navigate().GoToUrl(ConfigReader.GetUrl("LoginPage"));
        }
        public void Login(string email, string password)
        {
            _driver.FindElement(By.XPath(ConfigReader.GetSetting("LoginEmailInput"))).SendKeys(email);
            _driver.FindElement(By.XPath(ConfigReader.GetSetting("LoginPasswordInput"))).SendKeys(password);
            _driver.FindElement(By.XPath(ConfigReader.GetSetting("SignInButton"))).Click();
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
        public void DismissNoticeIfPresent()
        {
            var dismissLocator = ConfigReader.GetSetting("DismissNoticeButton");
            if (string.IsNullOrEmpty(dismissLocator))
                return;

            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                var button = wait.Until(driver =>
                {
                    var elements = driver.FindElements(By.XPath(dismissLocator));
                    return elements.Count > 0 && elements[0].Displayed && elements[0].Enabled ? elements[0] : null;
                });
                button?.Click();
            }
            catch (WebDriverTimeoutException)
            {
              
            }
        }
    }
}
