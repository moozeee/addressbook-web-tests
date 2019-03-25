using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            appManager.Navigator.GoToMainPage();
            List<ContactData> oldContactList = appManager.Contacts.GetContactList();

            appManager.Contacts.CreateContact(false);

            List<ContactData> newContactList = appManager.Contacts.GetContactList();
            Assert.AreEqual(oldContactList.Count + 1, newContactList.Count);
            appManager.Auth.Logout();
        }
    }
}
