using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QA_Project___saucedemo.com.Pages
{
    class LoginPage : Page
    {
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement username => driver.FindElement(By.Id("user-name"));
        IWebElement password => driver.FindElement(By.Id("password"));
        IWebElement LoginButton => driver.FindElement(By.Id("login-button"));

        public void Login(string _username, string _password)
        {
            username.SendKeys(_username);
            password.SendKeys(_password);
            LoginButton.Click();
        }
    }
}
