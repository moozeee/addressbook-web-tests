using NUnit.Framework;
using WebAddressbookTests;

namespace addressbook_web_tests.tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            appManager.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
