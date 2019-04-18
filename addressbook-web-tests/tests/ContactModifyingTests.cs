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

            var newContact = new ContactData(appManager.Contacts.GetRandomWord(), appManager.Contacts.GetRandomWord());
            List<ContactData> OldContactList = appManager.Contacts.GetContactList();
            appManager.Contacts.ModifyContact(rowNum, newContact);

            List<ContactData> NewContactList = appManager.Contacts.GetContactList();
            foreach (ContactData contact in OldContactList)
            {
                if (contact.Id.ToString() == modifiedContact.Id.ToString())
                {
                    contact.FirstName = newContact.FirstName;
                    contact.LastName = newContact.LastName;
                    break;
                }
            }
            OldContactList.Sort();
            NewContactList.Sort();
            Assert.AreEqual(OldContactList, NewContactList);

            appManager.Auth.Logout();
        }
    }
}
