using addressbook_web_tests;
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
            
            appManager.Groups.SelectGroup(0)
                .RemoveGroup()
                .ReturnToGroupsPage();

            var newGroupList = appManager.Groups.GetGroupList();
            oldGroupList.RemoveAt(0);

            Assert.AreEqual(oldGroupList, newGroupList);

            appManager.Auth.Logout();
        }
    }
}
