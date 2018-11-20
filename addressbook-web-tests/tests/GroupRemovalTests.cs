using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            appManager.Navigator.GoToMainPage();
            System.Threading.Thread.Sleep(2000);
            appManager.Auth.Login(new AccountData("admin", "secret"));
            System.Threading.Thread.Sleep(2000);
            appManager.Navigator.GoToGroupsPage();
            System.Threading.Thread.Sleep(2000);
            appManager.Groups.SelectGroup(2);
            System.Threading.Thread.Sleep(2000);
            appManager.Groups.RemoveGroup();
            System.Threading.Thread.Sleep(2000);
            appManager.Groups.ReturnToGroupsPage();
            System.Threading.Thread.Sleep(2000);
            appManager.Auth.Logout();
        }
    }
}
