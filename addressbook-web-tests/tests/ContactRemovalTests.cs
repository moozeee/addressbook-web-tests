using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
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

            appManager.Contacts.RemoveContact(2);
            System.Threading.Thread.Sleep(5000);
        }
    }
}
