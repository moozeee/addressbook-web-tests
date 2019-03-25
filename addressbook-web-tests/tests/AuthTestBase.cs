using addressbook_web_tests;
using NUnit.Framework;

namespace WebAddressbookTests
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
