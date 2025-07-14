using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using specflowdemo.Utilities.Config;
using System.Xml.Linq;

public class RegisterPage
{
    private readonly IWebDriver _driver;
    private readonly TimeSpan _timeout = TimeSpan.FromSeconds(15);

    public RegisterPage(IWebDriver driver)
    {
        _driver = driver;
    }

    private IWebElement WaitUntilClickable(By by)
    {
        var wait = new WebDriverWait(_driver, _timeout);
        return wait.Until(driver =>
        {
            var element = driver.FindElement(by);
            return (element != null && element.Enabled && element.Displayed) ? element : null;
        });
    }

    public void FillFirstName()
        => WaitUntilClickable(By.XPath(ConfigReader.GetSetting("FirstNameTextBox")))
                .SendKeys(ConfigReader.GetSetting("FirstNameInput"));


    public void FillLastName()
        => WaitUntilClickable(By.XPath(ConfigReader.GetSetting("LastNameTextBox")))
            .SendKeys(ConfigReader.GetSetting("LastNameInput"));

    public void FillEmail()
        => WaitUntilClickable(By.XPath(ConfigReader.GetSetting("RegisterEmailTextBox")))
                  .SendKeys(ConfigReader.GetSetting("ValidEmail"));

    public void FillPassword()
        => WaitUntilClickable(By.XPath(ConfigReader.GetSetting("RegisterPasswordTextBox")))
                  .SendKeys(ConfigReader.GetSetting("ValidPassword"));

    public void FillConfirmPassword()
        => WaitUntilClickable(By.XPath(ConfigReader.GetSetting("RegisterConfirmPasswordTextBox")))
                  .SendKeys(ConfigReader.GetSetting("ValidPassword"));

    public void ClickCreateAccountButton()
        => WaitUntilClickable(By.XPath(ConfigReader.GetSetting("CreateAnAccountButton")))
                  .Click();
}
