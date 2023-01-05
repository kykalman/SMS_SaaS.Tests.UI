using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMB_SaaS.BusinessLogic.Pages;

namespace SMS_SaaS.Tests.UI.AssertionHelper
{
    public static class UserProfileAssertions
    {
        public static void AssertEmailProfileEqualsExpected(string email)
        {
            var userProfile = new UserAccountPage();
            var actualEmail = userProfile.GetUserPrifileEmail();
            Assert.AreEqual(actualEmail, email);
        }
    }
}
