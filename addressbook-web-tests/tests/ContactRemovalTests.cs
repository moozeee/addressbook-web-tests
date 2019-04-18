using addressbook_web_tests;
using addressbook_web_tests.tests;
using NUnit.Framework;
using System;
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
            int _rowNumToDelete = new Random().Next(1, oldContactList.Count);

            appManager.Contacts
                .RemoveContact(_rowNumToDelete)
                .ReturnToContactsPage();

            var newContactList = appManager.Contacts.GetContactList();


            ContactData toBeRemoved = oldContactList[_rowNumToDelete - 1];

            oldContactList.RemoveAt(_rowNumToDelete - 1);

            Assert.AreEqual(oldContactList, newContactList);

            foreach (ContactData contact in newContactList)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

            appManager.Auth.Logout();
        }
    }
}
