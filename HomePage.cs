using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace QA_Project___saucedemo.com
{
    class HomePage
    {
        IWebDriver driver;
       
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement Button => driver.FindElement(By.ClassName("bm-burger-button"));
        IWebElement AddToCart1 => driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(1) > div.pricebar > button"));
        IWebElement MenuExit => driver.FindElement(By.ClassName("bm-cross-button"));
        IWebElement FirstItem => driver.FindElement(By.CssSelector("#item_4_title_link > div"));
        IWebElement ItemTitle => driver.FindElement(By.ClassName("inventory_details_name"));
        IWebElement ItemDesc => driver.FindElement(By.ClassName("inventory_details_desc"));
        IWebElement ItemPrice => driver.FindElement(By.ClassName("inventory_details_price"));
        IWebElement AddToCartThroughItem => driver.FindElement(By.CssSelector("#inventory_item_container > div > div > div > button"));
        IWebElement ShoppingCart => driver.FindElement(By.Id("shopping_cart_container"));
        IWebElement AllItemsContainer => driver.FindElement(By.XPath("//*[@id='inventory_container']/div/div[1]/div[3]/button"));
        IWebElement _AboutLoaded => driver.FindElement(By.ClassName("nav-image-link"));
        IWebElement LoginButton => driver.FindElement(By.Id("login-button"));


        public void ClickButton()
        {
            Button.Click();
        }

        public void ClickButton_Allitems()
        {
            Button.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement Button_Allitems = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("inventory_sidebar_link")));
            Button_Allitems.Click();
        }

        public void ClickButton_About()
        {
            Button.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement Button_About = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("about_sidebar_link")));
            Button_About.Click();
        }
        public void ClickButton_Logout()
        {
            Button.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement Button_Logout = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("logout_sidebar_link")));
            Button_Logout.Click();
        }
        public void Clickbutton_Reset()
        {
            Button.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement Button_Reset = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("reset_sidebar_link")));
            Button_Reset.Click();
            MenuExit.Click();
            

        }
        public void Click_AddToCart1()
        {
            AddToCart1.Click();
        }
        public string GetCartButtonState()
        {
            string CartButton = AddToCart1.Text;
            return CartButton;
        }
        public string GetCartIcon()
        {
            string IconState;
            try
            {
                IWebElement Icon = driver.FindElement(By.CssSelector("#shopping_cart_container > a > span"));
                IconState = "Displayed";
            }
            catch (Exception e)
            {
                IconState = "Not Displayed";
            }
            return IconState;
        }
        public void ClickFirstItem()
        {
            FirstItem.Click();
        }
        public string ReturnItemTitle()
        {
            string Title = ItemTitle.Text;
            return Title;
        }
        public string ReturnItemDesc()
        {
            string Desc = ItemDesc.Text;
            return Desc;
        }
        public string ReturnItemPrice()
        {
            string Price = ItemPrice.Text;
            return Price;
        }
        public void AddToCartItem()
        {
            AddToCartThroughItem.Click();
        }
        public string GetCartButtonStateInItem()
        {
            string State = AddToCartThroughItem.Text;
            return State;
        }
        public void ClickOnShoppingCart()
        {
            ShoppingCart.Click();
        }
        public bool ItemContainer()
        {
            bool ItemsAll = AllItemsContainer.Displayed;
            return ItemsAll;
        }
        public bool AboutLoaded()
        {
            bool About = _AboutLoaded.Displayed;
            return About;
        }
        public bool LoginButtonLoaded()
        {
            bool LoginButtonLoaded = LoginButton.Displayed;
            return LoginButtonLoaded;
        }

    }
}