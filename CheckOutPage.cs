using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QA_Project___saucedemo.com
{
    class CheckOutPage
    {
        IWebDriver driver;
        public CheckOutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement FirstName => driver.FindElement(By.Id("first-name"));
        IWebElement LastName => driver.FindElement(By.Id("last-name"));
        IWebElement ZipCode => driver.FindElement(By.Id("postal-code"));
        IWebElement ContinueButton => driver.FindElement(By.CssSelector("#checkout_info_container > div > form > div.checkout_buttons > input"));
        IWebElement CancelButton => driver.FindElement(By.CssSelector("#checkout_summary_container > div > div.summary_info > div.cart_footer > a.cart_cancel_link.btn_secondary"));
        IWebElement FinishButton => driver.FindElement(By.CssSelector("#checkout_summary_container > div > div.summary_info > div.cart_footer > a.btn_action.cart_button"));
        IWebElement InventoryFirstItemTitle => driver.FindElement(By.ClassName("inventory_item_name"));
        IWebElement InventoryFirstItemDesc => driver.FindElement(By.ClassName("inventory_item_desc"));
        IWebElement InventoryFirstItemPrice => driver.FindElement(By.ClassName("inventory_item_price"));
        IWebElement FinishHeader => driver.FindElement(By.ClassName("complete-header"));
        IWebElement FinishDesc => driver.FindElement(By.ClassName("complete-text"));
        IWebElement FinishImage => driver.FindElement(By.ClassName("pony_express"));
        public void EnterCredidentials(string name, string surname, string id)
        {
            FirstName.SendKeys(name);
            LastName.SendKeys(surname);
            ZipCode.SendKeys(id);
            ContinueButton.Click();
        }
        public void FinishButtonClick()
        {
            FinishButton.Click();
        }
        public string ReturnItemHeader()
        {
            string ItemHeader = FinishHeader.Text;
            return ItemHeader;
        }
        public string ReturnItemDesc()
        {
            string Desc = FinishDesc.Text;
            return Desc;
        }
        public bool IsImageDisplayed()
        {
            bool ImageDis = FinishImage.Displayed;
            return ImageDis;
        }

            

    }
}
