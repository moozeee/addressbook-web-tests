using addressbook_web_tests;
using NUnit.Framework;
using System.Collections.Generic;
using addressbook_web_tests.tests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            appManager.Navigator.GoToGroupsPage();
            List<GroupData> oldGroupList = appManager.Groups.GetGroupList();

            appManager.Groups.CreateGroup(false);

            var newGroupList = appManager.Groups. GetGroupList();
            Assert.AreEqual(oldGroupList.Count + 1, newGroupList.Count);
            appManager.Auth.Logout();
        }
    }
}
