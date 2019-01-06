using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            //appManager.Navigator.GoToGroupsPage();
            //for (int i = 0; i < 5; i++)
            //{
            //appManager.Groups.Remove(1);
            //appManager.Auth.Logout();
            //}
            //appManager.Auth.Logout();

            appManager.Groups.RemoveGroup(1);
        }
    }
}
