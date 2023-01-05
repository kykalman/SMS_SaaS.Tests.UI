using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMB_SaaS.Core;
using SMB_SaaS.Core.Models;
using SMB_SaaS.Core.Utilities;

namespace SMS_SaaS.Tests.UI.Base
{
    [TestClass]
    public class BaseTest
    {
        static Settings TestSettings => Configuration.Settings;

        [TestInitialize]
        public void OpenHomePage()
        {
            BrowserHelper Browser = BrowserHelper.Instance;
            Browser = BrowserHelper.Instance;
            BrowserHelper.NavigateTo(TestSettings.BaseUrl);
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            BrowserHelper.Quit();
        }
    }
}
