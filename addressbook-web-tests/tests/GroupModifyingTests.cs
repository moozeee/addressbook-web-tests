using NUnit.Framework;
using System.Collections.Generic;
using addressbook_web_tests.tests;
using System;
using addressbook_web_tests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModifyingTests : AuthTestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            appManager.Navigator.GoToGroupsPage();
            var rowNum = new Random().Next(1, appManager.Groups.GetGroupList().Count);
            var modifiedGroup = appManager.Groups.GetGroupData(rowNum);
            appManager.Groups.ModifyGroup(rowNum);
            List<GroupData> GroupList = appManager.Groups.GetGroupList();
            appManager.Groups.IsGroupInGroupList(modifiedGroup, GroupList);

            appManager.Auth.Logout();
        }
    }
}
