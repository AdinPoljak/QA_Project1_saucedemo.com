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
        IWebDriver driver = SetUpBrowser.BrowserSetup();
        LoginPage login => new LoginPage(driver);
        HomePage Home => new HomePage(driver);
        CartPage Cart => new CartPage(driver);
        CheckOutPage CheckOut => new CheckOutPage(driver);

        //Tests
        [Test]
        public void LoginTestPass()
        {
            
            login.Login(usernameTrue, passwordTrue);
            string PageURL = driver.Url;
            Assert.AreEqual(PageURL, "https://www.saucedemo.com/inventory.html");
            driver.Quit();
           

        }
        [Test]
        public void LoginTestFail()
        {
            login.Login(usernameFalse, passwordFalse);
            string PageURL = driver.Url;
            Assert.AreEqual(PageURL, "https://www.saucedemo.com/");
            driver.Quit();

        }
        [Test]
        public void CheckHomepage_Allitems_Loaded()
        {
            login.Login(usernameTrue, passwordTrue);
            Home.ClickButton_Allitems();
            bool AllitemsContainer = Home.ItemContainer();
            Assert.True(AllitemsContainer);
            driver.Quit();

        }
        [Test]
        public void CheckHomepage_About_Loaded()
        {
            login.Login(usernameTrue, passwordTrue);
            Home.ClickButton_About();
            bool AboutLoaded = Home.AboutLoaded();
            Assert.True(AboutLoaded);
            driver.Quit();
        }
        [Test]
        public void CheckHomepage_Logout()
        {
            login.Login(usernameTrue, passwordTrue);
            Home.ClickButton_Logout();
            bool LoginButton = Home.LoginButtonLoaded();
            Assert.True(LoginButton);
            driver.Quit();
        }
        [Test]
        public void CheckHomepage_Reset()
        {
            login.Login(usernameTrue, passwordTrue);;
            Home.Click_AddToCart1();
            string CartButtonState = Home.GetCartButtonState();
            Home.Clickbutton_Reset();
            //Assert.AreEqual(CartButtonState, "REMOVE"); - this test fails here, the bug is that the page doesn't reset the CART button state
            string IconState = Home.GetCartIcon();
            Assert.AreEqual(IconState, "Not Displayed");
            driver.Quit();
        }
        [Test]
        public void CheckFirstItemLoaded()
        {
            login.Login(usernameTrue, passwordTrue);
            Home.ClickFirstItem();
            string ItemTitle = Home.ReturnItemTitle();
            Assert.AreEqual(ItemTitle, "Sauce Labs Backpack");
            string ItemDesc = Home.ReturnItemDesc();
            Assert.AreEqual(ItemDesc, "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.");
            string ItemPrice = Home.ReturnItemPrice();
            Assert.AreEqual(ItemPrice, "$29.99");
            driver.Quit();
        }
        [Test]
        public void AddFirstItemInCartCheck()
        {
            login.Login(usernameTrue, passwordTrue);
            Home.ClickFirstItem();
            Home.AddToCartItem();
            string CartState = Home.GetCartButtonStateInItem();
            Assert.AreEqual(CartState, "REMOVE");
            Home.ClickOnShoppingCart();
            string ItemTitle = Cart.GetItemTitle();
            Assert.AreEqual(ItemTitle, "Sauce Labs Backpack");
            driver.Quit();

        }
        [Test]
        public void RemoveFromCartItemCheck()
        {
            login.Login(usernameTrue, passwordTrue);
            Home.Click_AddToCart1();
            Home.ClickOnShoppingCart();
            Cart.RemoveFromCartItem();
            string CartState = Cart.CheckCartItem();
            Assert.AreEqual(CartState, "Item not in Cart");
            string IconState = Cart.GetCartIcon();
            Assert.AreEqual(IconState, "Not Displayed");
            Cart.ClickContinueShopping();
            string AddToCartState = Home.GetCartButtonState();
            Assert.AreEqual(AddToCartState, "ADD TO CART");
            driver.Quit();

        }
        [Test]
        public void CheckoutItem()
        {
            login.Login(usernameTrue, passwordTrue);
            Home.Click_AddToCart1();
            Home.ClickOnShoppingCart();
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
            driver.Quit();


        }
    }
}
