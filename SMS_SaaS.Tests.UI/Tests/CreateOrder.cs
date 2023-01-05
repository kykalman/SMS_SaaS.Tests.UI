using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMB_SaaS.BusinessLogic.Pages;
using SMS_SaaS.Tests.UI.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_SaaS.Tests.UI.Tests
{
    [TestClass]
    public class CreateOrder: BaseTest
    {
        private TestContext testContext;
        public TestContext TestContext
        {

            get { return testContext; }
            set { testContext = value; }
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\data\data.csv", "data#csv", DataAccessMethod.Sequential)]

        public void BuyProductWithNewUser()
        {
            var product = TestContext.DataRow["product"].ToString();
            var storeTitle = TestContext.DataRow["storeTitle"].ToString();
            var deliveryMethod = TestContext.DataRow["deliveryMethod"].ToString();
            var paymentMethod = TestContext.DataRow["paymentMethod"].ToString();

            var homePage = new HomePage(storeTitle);
            homePage.OpenProductPage(product);

            var productPage = new ProductPage(product);
            productPage.AddProductToCart();
            productPage.GoToGart();

            var cartPage = new CartPage();
            cartPage.SelectDeliveryMethod(deliveryMethod);
            cartPage.InputUserData();
            cartPage.SelectPaymentMethod(paymentMethod);
            cartPage.PlaceAnOrder();

            var isOrderPlaced = cartPage.IsOrderCompleted();

            Assert.IsTrue(isOrderPlaced, $"Order is not created");
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\data\byuproduct_existinguser.csv", "byuproduct_existinguser#csv", DataAccessMethod.Sequential)]
        public void BuyProductWithExistingUser()
        {
            var email = TestContext.DataRow["email"].ToString();
            var password = TestContext.DataRow["password"].ToString();
            var product = TestContext.DataRow["product"].ToString();
            var street = TestContext.DataRow["street"].ToString();
            var building = TestContext.DataRow["building"].ToString();
            var storeTitle = TestContext.DataRow["storeTitle"].ToString();

            var homePage = new HomePage(storeTitle);

            homePage.LoginPanel.LoginWithExistingUser(email, password);
            homePage.OpenProductPage(product);

            var productPage = new ProductPage(product);
            productPage.AddProductToCart();
            productPage.GoToGart();

            var cartPage = new CartPage();
            cartPage.SelectDeliveryMethod("Express delivery");
            cartPage.InpitUserAddress(street, building);
            cartPage.SelectPaymentMethod("Cash On Delivery");
            cartPage.PlaceAnOrder();

            var isOrderPlaced = cartPage.IsOrderCompleted();

            Assert.IsTrue(isOrderPlaced, $"Order is not created");
        }
    }
}
