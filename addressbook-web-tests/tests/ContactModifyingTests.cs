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
            //appManager.Contacts.ModifyContact(rowNum);

            //List<ContactData> ContactList = appManager.Contacts.GetContactList();
            //appManager.Contacts.IsContactInContactList(modifiedContact, ContactList);
            //appManager.Contacts.IsContactInContactList(modifiedContact, ContactList);

            var newContact = new ContactData(appManager.Contacts.GetRandomWord(), appManager.Contacts.GetRandomWord());
            List<ContactData> OldContactList = appManager.Contacts.GetContactList();
            appManager.Contacts.ModifyContact(rowNum, newContact);

            List<ContactData> NewContactList = appManager.Contacts.GetContactList();

            OldContactList[rowNum - 1].FirstName = newContact.FirstName;
            OldContactList[rowNum - 1].LastName = newContact.LastName;
            OldContactList.Sort();
            NewContactList.Sort();
            Assert.AreEqual(OldContactList, NewContactList);

            appManager.Auth.Logout();
        }
    }
}
