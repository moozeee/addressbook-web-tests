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
            GroupData group = new GroupData("Test Group");
            appManager.Groups.CreateGroup(group);

            var newGroupList = appManager.Groups. GetGroupList();
            oldGroupList.Add(group);
            oldGroupList.Sort();
            newGroupList.Sort();
            Assert.AreEqual(oldGroupList, newGroupList);
            //Assert.AreEqual(oldGroupList.Count + 1, newGroupList.Count);
            appManager.Auth.Logout();
        }
    }
}
