using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            //appManager.Navigator.GoToGroupsPage();
            //for (int i = 0; i < 5; i++)
            //{
            //appManager.Groups.Remove(1);
            //appManager.Auth.Logout();
            //}
            //appManager.Auth.Logout();

            appManager.Contacts.RemoveContact(1);
        }
    }
}
