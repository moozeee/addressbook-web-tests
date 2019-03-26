using NUnit.Framework;
using System.Collections.Generic;
using addressbook_web_tests.tests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            //appManager.Navigator.GoToMainPage();
            //List<ContactData> oldContactList = appManager.Contacts.GetContactList();

            //for (int i = 0; i < 10; i++)
            //{
            //    appManager.Contacts.CreateContact(false);

            //    List<ContactData> newContactList = appManager.Contacts.GetContactList();
            //    Assert.AreEqual(oldContactList.Count + 1, newContactList.Count);
            //}
            appManager.Navigator.GoToMainPage();
            List<ContactData> oldContactList = appManager.Contacts.GetContactList();
            appManager.Contacts.CreateContact(false);
            List<ContactData> newContactList = appManager.Contacts.GetContactList();
            Assert.AreEqual(oldContactList.Count + 1, newContactList.Count);

            appManager.Auth.Logout();
        }
    }
}
