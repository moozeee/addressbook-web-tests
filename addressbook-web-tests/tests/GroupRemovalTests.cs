using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            appManager.Navigator.GoToGroupsPage();
            appManager.Groups.SelectGroup(2)
                .RemoveGroup()
                .ReturnToGroupsPage();
            appManager.Auth.Logout();
        }
    }
}
