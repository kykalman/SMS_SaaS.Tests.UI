using OpenQA.Selenium;
using SMB_SaaS.BusinessLogic.Elements;
using SMB_SaaS.Core.Models;
using SMB_SaaS.Core.Utilities;

namespace SMB_SaaS.BusinessLogic.Panel
{
    public class LoginPanel
    {        
        private By OpenLoginPanelLocator => By.XPath("(//*[name()='use' and @*='/dist/store/icons/custom_v1.sprite.svg#s-icon-user'])[2]/ancestor::button");
        private By UserEmailLocator => By.XPath("//div[contains(text(), 'E-mail')]/following::input[1]");
        private By UserPasswordLocator => By.XPath("//div[contains(text(), 'Password')]/following::input[1]");
        private By CloseLoginPanelLocator => By.XPath("(//*[name()='use' and @*='/dist/store/icons/custom_v1.sprite.svg#s-icon-close'])[3]/ancestor::button");
        private By LoginUserLocator => By.XPath("(//span[contains(text(),'Log in')])[2]");
        private By CreateAnAccountLinkLocator => By.XPath("//span[contains(text(),'Create an account')]");
        private By ConfirmComplianceCheckboxLocator => By.XPath("//div[@class='ssc-ui-checkbox__action']");
        private By CreateAnAccountButtonLocator => By.XPath("//span[contains(text(),'Create an account')]");

        private BaseElement UserEmailField => new BaseElement(UserEmailLocator);
        private BaseElement UserPasswordField => new BaseElement(UserPasswordLocator);
        private BaseElement CloseLoginPanelButton => new BaseElement(CloseLoginPanelLocator);
        private BaseElement LoginUserButton => new BaseElement(LoginUserLocator);
        private BaseElement OpenLoginPanelButton => new BaseElement(OpenLoginPanelLocator);
        private BaseElement CreateAnAccountLink => new BaseElement(CreateAnAccountLinkLocator);
        private BaseElement CreateAnAccountButton => new BaseElement(CreateAnAccountButtonLocator);
        private BaseElement ConfirmComplianceCheckbox => new BaseElement(ConfirmComplianceCheckboxLocator);
        public LoginPanel()
        {
            ClickOpenLoginPanelButton();
        }
        public void ClickCloseButton()
        {
            CloseLoginPanelButton.Click();
        }
        public void LoginWithExistingUser(string email, string password)
        {
            InputUserEmail(email);
            InputUserPassword(password);
            ClickLoginButton();
        }
        public void CreateNewUserAccount(string email, string password)
        {
            ClickCreateAnAccountLink();
            CreateAnAccountButton.WaitForIsVisible();
            InputUserEmail(email);
            InputUserPassword(password);
            ConfirmComplianceCheckbox.Click();
            ClickCreateAnAccountButton();
        }
        private void InputUserEmail(string email)
        {
            UserEmailField.SendKeys(email);
        }
        private void InputUserPassword(string password)
        {
            UserPasswordField.SendKeys(password);
        }
        private void ClickLoginButton()
        {
            LoginUserButton.Click();
        }
        public void ClickOpenLoginPanelButton()
        {
            OpenLoginPanelButton.Click();
        }
        private void ClickCreateAnAccountLink()
        {
            CreateAnAccountLink.Click();
        }
        private void ClickCreateAnAccountButton()
        {
            CreateAnAccountButton.Click();
        }
    }
}
