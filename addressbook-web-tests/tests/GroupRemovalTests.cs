using addressbook_web_tests;
using addressbook_web_tests.tests;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            appManager.Navigator.GoToGroupsPage();
            List<GroupData> oldGroupList = appManager.Groups.GetGroupList();
            int _rowNumToDelete = 1;

            appManager.Groups
                .RemoveGroup(_rowNumToDelete)
                .ReturnToGroupsPage();

            var newGroupList = appManager.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroupList[_rowNumToDelete - 1];
            oldGroupList.RemoveAt(_rowNumToDelete - 1);

            Assert.AreEqual(oldGroupList, newGroupList);

            foreach (GroupData group in newGroupList)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

            appManager.Auth.Logout();
        }
    }
}
