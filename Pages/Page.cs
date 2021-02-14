using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_Project___saucedemo.com.Pages
{
    class Page
    {
        protected IWebDriver driver;

        protected IWebElement FindElementById (string elementId)
        {
            return driver.FindElement(By.Id(elementId));
        }

        protected IWebElement FindElementByCssSelector(string elementSelector)
        {
            return driver.FindElement(By.CssSelector(elementSelector));
        }
    }
}
