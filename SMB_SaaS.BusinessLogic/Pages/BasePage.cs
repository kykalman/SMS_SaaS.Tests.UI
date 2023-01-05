using OpenQA.Selenium.Support.UI;
using System;
using SMB_SaaS.Core;
using SMB_SaaS.BusinessLogic.Elements;
using OpenQA.Selenium;
using SMB_SaaS.BusinessLogic.Panel;

namespace SMB_SaaS.BusinessLogic.Pages
{
    public abstract class BasePage
    {
        public LoginPanel LoginPanel => new LoginPanel();
        public string JsGetTitle()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)BrowserHelper.GetDriver();
            return executor.ExecuteScript("return document.title;").ToString();
        }

        public void WaitForNewWindowOpens()
        {
            var wait = new WebDriverWait(BrowserHelper.GetDriver(), new TimeSpan(0, 0, 30));
            wait.Until(ws => ws.WindowHandles.Count == 2);
        }

        public void CloseNewWindowAndSwitchToOriginal(string originalWindowHandle)
        {
            BrowserHelper.GetDriver().Close();
            BrowserHelper.GetDriver().SwitchTo().Window(originalWindowHandle);
        }

        public void SwitchToNewOpenedWindow()
        {
            WaitForNewWindowOpens();
            BrowserHelper.GetDriver().SwitchTo().Window(BrowserHelper.GetDriver().WindowHandles[1]);
        }
    };
}
