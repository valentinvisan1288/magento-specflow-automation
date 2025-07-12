using OpenQA.Selenium;
using specflowdemo.Pages;
using specflowdemo.Utilities;
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
        _registerPage.FillFirstName(LocatorReader.Get(firstNameKey));
        _registerPage.FillLastName(LocatorReader.Get(lastNameKey));
        _registerPage.FillEmail(LocatorReader.Get(emailKey));
        _registerPage.FillPassword(LocatorReader.Get(passwordKey));
        _registerPage.FillConfirmPassword(LocatorReader.Get(passwordKey)); // usually same as password
    }

    public void SubmitForm()
    {
        _registerPage.ClickCreateAccountButton();
    }
}
