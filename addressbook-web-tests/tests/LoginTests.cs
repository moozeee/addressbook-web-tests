using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            appManager.Auth.Logout();
            AccountData contact = new AccountData("admin", "secret");
            appManager.Auth.Login(contact);
            Assert.IsTrue(appManager.Auth.isLoggedIn(contact));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            appManager.Auth.Logout();
            AccountData contact = new AccountData("admin", "111");
            appManager.Auth.Login(contact);
            Assert.IsFalse(appManager.Auth.isLoggedIn(contact));
        }
    }
}
