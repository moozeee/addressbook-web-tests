using addressbook_web_tests;
using addressbook_web_tests.tests;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            appManager.Navigator.GoToMainPage();

            List<ContactData> oldContactList = appManager.Contacts.GetContactList();
            
            appManager.Contacts
                .RemoveContact(1)
                .ReturnToContactsPage();

            var newContactList = appManager.Contacts.GetContactList();
            oldContactList.RemoveAt(0);

            Assert.AreEqual(oldContactList, newContactList);

            appManager.Auth.Logout();
        }
    }
}
