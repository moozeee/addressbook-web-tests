using NUnit.Framework;
using WebAddressbookTests;

namespace addressbook_web_tests.tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            AccountData user = new AccountData("admin", "secret");
            appManager.Auth.Login(user);
            appManager.Auth.AssertLoginSuccess(user);
        }
    }
}
