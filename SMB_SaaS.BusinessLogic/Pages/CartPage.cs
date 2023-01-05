using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SMB_SaaS.Core;
using SMB_SaaS.BusinessLogic.Elements;
using SMB_SaaS.Core.Utilities;
using SMB_SaaS.Core.Models;

namespace SMB_SaaS.BusinessLogic.Pages
{
    public class CartPage: BasePage
    {        
        private readonly string cartPage = "Checkout";
        private readonly By orderCompleted = By.XPath("//div[contains(text(),'Thanks!')]");
        private readonly By userName = By.XPath("//div[contains(text(), 'Full name')]/following::input[1]");
        private readonly By userEmail = By.XPath("//div[contains(text(), 'E-mail')]/following::input[1]");
        private readonly By userPhoneNumber= By.XPath("//div[contains(text(), 'Phone number')]/following::input[1]");
        private readonly By userCity = By.XPath("//div[contains(text(), 'Street')]/following::input[1]");
        private readonly By userStreet = By.XPath("//div[contains(text(), 'Street')]/following::input[1]");
        private readonly By userBuilding = By.XPath("//div[contains(text(), 'Building')]/following::input[1]");
        private readonly By placeOrderButtonLocator = By.XPath("//span[contains(text(),'Place order')]");
        private BaseElement UserNameField => new BaseElement(userName);
        private BaseElement UserEmailField => new BaseElement(userEmail);
        private BaseElement UserPhoneNumberField => new BaseElement(userPhoneNumber);
        private BaseElement UserStreetField => new BaseElement(userStreet);
        private BaseElement UserBuildinField => new BaseElement(userBuilding);
        private BaseElement PlaceOrderButton => new BaseElement(placeOrderButtonLocator);
        private BaseElement UserCityField => new BaseElement(placeOrderButtonLocator);
        public CartPage()
        {
            AssertPageIsOpened(cartPage);
        }
        protected void AssertPageIsOpened(string locator)
        {
            var title = JsGetTitle();
            if (title == locator) return;
            else throw new Exception();
        }
        public void SelectDeliveryMethod(string methodName)
        {
            var button = new BaseElement(By.XPath($"//span[contains(text(),'{methodName}')]"));
            button.Click();
        }
        public void InputUserData()
        {
            var userName = StringGenerator.GenerateString(11, GenerationOptions.LowerCaseLetters);
            var phoneNumber = StringGenerator.GenerateString(11, GenerationOptions.Numbers);
            var street = StringGenerator.GenerateString(15, GenerationOptions.MixedCase);
            var buildingNumber = StringGenerator.GenerateString(3, GenerationOptions.Numbers);

            UserNameField.SendKeys(userName);
            UserEmailField.SendKeys($"{userName}@test.com");
            UserPhoneNumberField.SendKeys(phoneNumber);
            UserStreetField.SendKeys(street);
            UserBuildinField.SendKeys(buildingNumber);
        }
        public void InpitUserAddress(string street, string building)
        {
            //var city = StringGenerator.GenerateString(15, GenerationOptions.MixedCase);
            //UserCityField.SendKeys(city);
            UserStreetField.SendKeys(street);
            UserBuildinField.SendKeys(building);
        }

        public void SelectPaymentMethod(string paymentMethod)
        {
            var button = new BaseElement(By.XPath($"//span[contains(text(),'{paymentMethod}')]"));
            button.Click();
        }
        public void PlaceAnOrder()
        {
            PlaceOrderButton.Click();
        }
        public bool IsOrderCompleted()
        {
           new BaseElement(orderCompleted).WaitForIsVisible();
           return true;
        }
    }
}
