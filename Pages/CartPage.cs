using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA_Project___saucedemo.com.Selectors;

namespace QA_Project___saucedemo.com.Pages
{
    class CartPage : Page
    {
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement ItemTitle => FindElementByCssSelector(CartSelectors.ITEM_TITLE_SELECTOR);
        IWebElement RemoveFromCart => driver.FindElement(By.CssSelector(CartSelectors.REMOVE_FROM_CART_BUTTON_SELECTOR));
        IWebElement ContinueShopping => driver.FindElement(By.ClassName("btn_secondary"));
        IWebElement Checkout => driver.FindElement(By.CssSelector("#cart_contents_container > div > div.cart_footer > a.btn_action.checkout_button"));


        public string GetItemTitle()
        {
            string Title = ItemTitle.Text;
            return Title;
        }
        public void RemoveFromCartItem()
        {
            RemoveFromCart.Click();
        }
        public void ClickContinueShopping()
        {
            ContinueShopping.Click();
        }
        public string CheckCartItem()
        {
            string CartState;
            try
            {
                IWebElement ItemInCart = driver.FindElement(By.CssSelector("#item_4_title_link > div")); ;
                CartState = "Item in Cart";
            }
            catch (Exception e)
            {
                CartState = "Item not in Cart";
            }
            return CartState;
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
        public void ClickOnCheckout()
        {
            Checkout.Click();
        }
    }
}
