using NUnit.Framework;
using System.Collections.Generic;
using addressbook_web_tests.tests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AuthorizationTests : AuthTestBase
    {
        [Test]
        public void LoginWithValidCredentialsTest()
        {
            appManager.Auth.Logout();
        }
    }
}
