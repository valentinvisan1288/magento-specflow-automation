﻿using OpenQA.Selenium;
using specflowdemo.Utilities.Config;

public class RegisterActions
{
    private readonly IWebDriver _driver;
    private readonly RegisterPage _registerPage;

    public RegisterActions(IWebDriver driver)
    {
        _driver = driver;
        _registerPage = new RegisterPage(driver);
    }

    public void NavigateToRegisterPage()
    {
        _driver.Navigate().GoToUrl(ConfigReader.GetUrl("RegisterPage"));
    }

    public void FillRegistrationForm()
    {
        _registerPage.FillFirstName();
        _registerPage.FillLastName();
        _registerPage.FillEmail();
        _registerPage.FillPassword();
        _registerPage.FillConfirmPassword();
    }

    public void SubmitForm()
    {
        _registerPage.ClickCreateAccountButton();
    }
}