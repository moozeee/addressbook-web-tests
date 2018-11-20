using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            appManager.Navigator.GoToMainPage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
            appManager.Groups.InitNewContactCreation();
            appManager.Contacts.FillContactForm(GetRandomContactData());
            appManager.Auth.Logout();
        }
    }
}
