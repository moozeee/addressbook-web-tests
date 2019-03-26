using NUnit.Framework;
using System.Collections.Generic;
using addressbook_web_tests.tests;
using System;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModifyingTests : AuthTestBase
    {
        [Test]
        public void ContactModifyTest()
        {
            appManager.Navigator.GoToMainPage();
            var rowNum = new Random().Next(1, appManager.Contacts.GetContactList().Count);
            var modifiedContact = appManager.Contacts.GetContactData(rowNum);
            appManager.Contacts.ModifyContact(rowNum);
            List<ContactData> ContactList = appManager.Contacts.GetContactList();
            appManager.Contacts.IsContactInContactList(modifiedContact, ContactList);

            appManager.Auth.Logout();
        }
    }
}
