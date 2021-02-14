using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QA_Project___saucedemo.com
{
    
    class SetUpBrowser
    {
        public static IWebDriver BrowserSetup(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            return driver;
        }
    }
}
