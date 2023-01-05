using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SMB_SaaS.Core;
using SMB_SaaS.BusinessLogic.Elements;
using SMB_SaaS.Core.Utilities;
using SMB_SaaS.Core.Models;

namespace SMB_SaaS.BusinessLogic.Pages
{
    public class UserAccountPage: BasePage
    {
        private readonly string userAccount = "Account";
        private By OpenUserProfileButtonLocator => By.XPath("(//*[name()='use' and @*='/dist/store/icons/custom_v1.sprite.svg#s-icon-user'])[2]/ancestor::a");
        private readonly By FullNameLocator = By.XPath("//div[contains(text(), 'Full name')]/following::input[1]");
        private readonly By PhoneNumberLocator = By.XPath("//div[contains(text(), 'Phone number')]/following::input[1]");
        private readonly By PasswordFieldLocator = By.XPath("//div[contains(text(), 'Password')]/following::input[1]");
        private readonly By SaveProfileButtonLocator = By.XPath("//button/span[contains(text(),'Save')]");
        private readonly By AddMyAddressButtonLocator = By.XPath("//div[contains(text(), 'Street')]/following::input[1]");
        private readonly By DeleteAccountButtonLocator = By.XPath("//div[contains(text(), 'Building')]/following::input[1]");
        private readonly By UserEmailFieldLocator = By.XPath("//div[contains(text(), 'E-mail')]/following::input[1]");

        private BaseElement FullNameField => new BaseElement(FullNameLocator);
        private BaseElement PhoneNumberField => new BaseElement(PhoneNumberLocator);
        private BaseElement PasswordField => new BaseElement(PasswordFieldLocator);
        private BaseElement SaveProfileButton => new BaseElement(SaveProfileButtonLocator);
        private BaseElement OpenUserProfileButton => new BaseElement(OpenUserProfileButtonLocator);
        private BaseElement UserEmailField => new BaseElement(UserEmailFieldLocator);
        public UserAccountPage()
        {
            ClickOpenUserAccountButton();
            AssertPageIsOpened(userAccount);
        }
        public void UpdateUserProfile(string fullName, string phoneNumber, string password)
        {
            InputFullName(fullName);
            InputPhoneNumber(phoneNumber);
            InputPassword(password);
            SaveProfileData();
        }
        public string GetUserPrifileEmail()
        {
            UserEmailField.WaitForIsVisible();
            return UserEmailField.GetAttribute("value");
        }
        private void InputFullName(string fullName)
        {
            FullNameField.SendKeys(fullName);
        }
        private void InputPhoneNumber(string phoneNumber)
        {
            PhoneNumberField.SendKeys(phoneNumber);
        }
        private void InputPassword(string password)
        {
            PasswordField.SendKeys(password);
        }
        private void SaveProfileData()
        {
            SaveProfileButton.Click();
        }
        private void ClickOpenUserAccountButton()
        {
            OpenUserProfileButton.Click();
        }
        protected void AssertPageIsOpened(string locator)
        {
            var title = JsGetTitle();
            if (title == locator) return;
            else throw new Exception();
        }
    }
}
