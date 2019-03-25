using addressbook_web_tests;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            appManager.Navigator.GoToMainPage();
            List<ContactData> oldContactList = appManager.Contacts.GetContactList();
            
            appManager.Contacts.SelectContact(0)
                .RemoveContact()
                .ReturnToContactsPage();

            var newContactList = appManager.Contacts.GetContactList();
            oldContactList.RemoveAt(0);

            Assert.AreEqual(oldContactList, newContactList);

            appManager.Auth.Logout();
        }
    }
}
