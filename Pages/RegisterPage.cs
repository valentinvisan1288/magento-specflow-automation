using OpenQA.Selenium;
using specflowdemo.Utilities.Config;

public class RegisterPage
{
    private readonly IWebDriver _driver;

    public RegisterPage(IWebDriver driver)
    {
        _driver = driver;
    }
    public void FillFirstName(string firstName)
        => _driver.FindElement(By.XPath(LocatorsReader.Get("FirstNameTextBox"))).SendKeys(firstName);
    public void FillLastName(string lastName)
        => _driver.FindElement(By.XPath(LocatorsReader.Get("LastNameTextBox"))).SendKeys(lastName);
    public void FillEmail(string email)
        => _driver.FindElement(By.XPath(LocatorsReader.Get("RegisterEmailTextBox"))).SendKeys(email);
    public void FillPassword(string password)
        => _driver.FindElement(By.XPath(LocatorsReader.Get("RegisterPasswordTextBox"))).SendKeys(password);
    public void FillConfirmPassword(string password)
        => _driver.FindElement(By.XPath(LocatorsReader.Get("RegisterConfirmPasswordTextBox"))).SendKeys(password);
    public void ClickCreateAccountButton()
        => _driver.FindElement(By.XPath(LocatorsReader.Get("CreateAnAccountButton"))).Click();
}
