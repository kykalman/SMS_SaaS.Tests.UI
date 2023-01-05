using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMB_SaaS.BusinessLogic.Pages;
using SMB_SaaS.Core.Utilities;
using SMS_SaaS.Tests.UI.Base;

namespace SMS_SaaS.Tests.UI.Tests
{
    [TestClass]
    public class CreateUsers : BaseTest
    {
       
        private TestContext testContext;
        public TestContext TestContext
        {

            get { return testContext; }
            set { testContext = value; }
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\data\users.csv", "users#csv", DataAccessMethod.Sequential)]
        public void CreateNewUser()
        {
            var email = TestContext.DataRow["email"].ToString();
            var password = TestContext.DataRow["password"].ToString();
            var storeTitle = TestContext.DataRow["storeTitle"].ToString();

            var homePage = new HomePage(storeTitle);
            homePage.LoginPanel.CreateNewUserAccount(email, password);

            AssertionHelper.UserProfileAssertions.AssertEmailProfileEqualsExpected(email);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\data\newusers.csv", "newusers#csv", DataAccessMethod.Sequential)]
        public void CreateNewUserAndUpdateUserProfile()
        {
            var email = TestContext.DataRow["email"].ToString();
            var password = TestContext.DataRow["password"].ToString();
            var storeTitle = TestContext.DataRow["storeTitle"].ToString();

            var homePage = new HomePage(storeTitle);
            homePage.LoginPanel.CreateNewUserAccount(email, password);

            var userAccountPage = new UserAccountPage();
            
            userAccountPage.UpdateUserProfile(StringGenerator.GenerateFullName(), StringGenerator.GeneratePhoneNumber(), password);            
        }
    }
}
