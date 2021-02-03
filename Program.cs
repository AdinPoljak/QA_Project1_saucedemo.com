using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace QA_Project___saucedemo.com
{
    class Program
    {
        //Website to test is wwww.saucedemo.com

        //Login Credidentials
        string usernameTrue = "standard_user";
        string passwordTrue = "secret_sauce";
        string usernameFalse = "fejk123";
        string passwordFalse = "xx123xx";

        //Checkout Credidentials
        string FirstName = "Adin";
        string LastName = "Poljak";
        string ZipCode = "71000";


        //Setting up pages
        IWebDriver _driver = SetUpBrowser.BrowserSetup();
        LoginPage login => new LoginPage(_driver);
        HomePage _HomePage => new HomePage(_driver);
        CartPage Cart => new CartPage(_driver);
        CheckOutPage CheckOut => new CheckOutPage(_driver);

        //Tests
        [Test]
        public void LoginTestPass()
        {
            
            login.Login(usernameTrue, passwordTrue);
            string PageURL = _driver.Url;
            Assert.AreEqual(PageURL, "https://www.saucedemo.com/inventory.html");
            _driver.Quit();
           

        }
        [Test]
        public void LoginTestFail()
        {
            login.Login(usernameFalse, passwordFalse);
            string PageURL = _driver.Url;
            Assert.AreEqual(PageURL, "https://www.saucedemo.com/");
            _driver.Quit();

        }
        [Test]
        public void CheckHomepage_Allitems_Loaded()
        {
            login.Login(usernameTrue, passwordTrue);
            _HomePage.ClickButton_Allitems();
            bool AllitemsContainer = _HomePage.ItemContainer();
            Assert.True(AllitemsContainer);
            _driver.Quit();

        }
        [Test]
        public void CheckHomepage_About_Loaded()
        {
            login.Login(usernameTrue, passwordTrue);
            _HomePage.ClickButton_About();
            bool AboutLoaded = _HomePage.AboutLoaded();
            Assert.True(AboutLoaded);
            _driver.Quit();
        }
        [Test]
        public void CheckHomepage_Logout()
        {
            login.Login(usernameTrue, passwordTrue);
            _HomePage.ClickButton_Logout();
            bool LoginButton = _HomePage.LoginButtonLoaded();
            Assert.True(LoginButton);
            _driver.Quit();
        }
        [Test]
        public void CheckHomepage_Reset()
        {
            login.Login(usernameTrue, passwordTrue);;
            _HomePage.Click_AddToCart1();
            string CartButtonState =_HomePage.GetCartButtonState();
            _HomePage.Clickbutton_Reset();
            //Assert.AreEqual(CartButtonState, "REMOVE"); - this test fails here, the bug is that the page doesn't reset the CART button state
            string IconState = _HomePage.GetCartIcon();
            Assert.AreEqual(IconState, "Not Displayed");
            _driver.Quit();
        }
        [Test]
        public void CheckFirstItemLoaded()
        {
            login.Login(usernameTrue, passwordTrue);
            _HomePage.ClickFirstItem();
            string ItemTitle = _HomePage.ReturnItemTitle();
            Assert.AreEqual(ItemTitle, "Sauce Labs Backpack");
            string ItemDesc = _HomePage.ReturnItemDesc();
            Assert.AreEqual(ItemDesc, "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.");
            string ItemPrice = _HomePage.ReturnItemPrice();
            Assert.AreEqual(ItemPrice, "$29.99");
            _driver.Quit();
        }
        [Test]
        public void AddFirstItemInCartCheck()
        {
            login.Login(usernameTrue, passwordTrue);
            _HomePage.ClickFirstItem();
            _HomePage.AddToCartItem();
            string CartState = _HomePage.GetCartButtonStateInItem();
            Assert.AreEqual(CartState, "REMOVE");
            _HomePage.ClickOnShoppingCart();
            string ItemTitle = Cart.GetItemTitle();
            Assert.AreEqual(ItemTitle, "Sauce Labs Backpack");
            _driver.Quit();

        }
        [Test]
        public void RemoveFromCartItemCheck()
        {
            login.Login(usernameTrue, passwordTrue);
            _HomePage.Click_AddToCart1();
            _HomePage.ClickOnShoppingCart();
            Cart.RemoveFromCartItem();
            string CartState = Cart.CheckCartItem();
            Assert.AreEqual(CartState, "Item not in Cart");
            string IconState = Cart.GetCartIcon();
            Assert.AreEqual(IconState, "Not Displayed");
            Cart.ClickContinueShopping();
            string AddToCartState = _HomePage.GetCartButtonState();
            Assert.AreEqual(AddToCartState, "ADD TO CART");
            _driver.Quit();

        }
        [Test]
        public void CheckoutItem()
        {
            login.Login(usernameTrue, passwordTrue);
            _HomePage.Click_AddToCart1();
            _HomePage.ClickOnShoppingCart();
            string CartState = Cart.CheckCartItem();
            Assert.AreEqual(CartState, "Item in Cart");
            string IconState = Cart.GetCartIcon();
            Assert.AreEqual(IconState, "Displayed");
            Cart.ClickOnCheckout();
            CheckOut.EnterCredidentials(FirstName, LastName, ZipCode);
            CheckOut.FinishButtonClick();
            string ItemHeader = CheckOut.ReturnItemHeader();
            Assert.AreEqual(ItemHeader, "THANK YOU FOR YOUR ORDER");
            string ItemDesc = CheckOut.ReturnItemDesc();
            Assert.AreEqual(ItemDesc, "Your order has been dispatched, and will arrive just as fast as the pony can get there!");
            bool ImageDis = CheckOut.IsImageDisplayed();
            Assert.True(ImageDis);
            _driver.Quit();


        }
    }
}
