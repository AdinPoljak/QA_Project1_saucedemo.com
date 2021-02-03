using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QA_Project___saucedemo.com
{
    
    class SetUpBrowser
    {
        static IWebDriver driver = new ChromeDriver();

        public static IWebDriver BrowserSetup()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            return driver;
        }
    }
}
