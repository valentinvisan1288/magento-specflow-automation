using OpenQA.Selenium;
using specflowdemo.Pages;
using specflowdemo.Utilities.Config;

public class RegisterActions
{
    private readonly IWebDriver _driver;
    private readonly HomePage _homePage;
    private readonly RegisterPage _registerPage;

    public RegisterActions(IWebDriver driver)
    {
        _driver = driver;
        _homePage = new HomePage(driver);
        _registerPage = new RegisterPage(driver);
    }

    public void NavigateToRegisterPage()
    {
        _driver.Navigate().GoToUrl(ConfigReader.GetUrl("RegisterPage"));
    }

    public void FillRegistrationForm(string firstNameKey, string lastNameKey, string emailKey, string passwordKey)
    {
        _registerPage.FillFirstName(ConfigReader.GetSetting(firstNameKey));
        _registerPage.FillLastName(ConfigReader.GetSetting(lastNameKey));
        _registerPage.FillEmail(ConfigReader.GetSetting(emailKey));
        _registerPage.FillPassword(ConfigReader.GetSetting(passwordKey));
        _registerPage.FillConfirmPassword(ConfigReader.GetSetting(passwordKey));
    }

    public void SubmitForm()
    {
        _registerPage.ClickCreateAccountButton();
    }
}