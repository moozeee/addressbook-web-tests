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
            var newGroup = new GroupData(appManager.Groups.GetRandomWord());

            var oldGroupList = appManager.Groups.GetGroupList();

            appManager.Groups.ModifyGroup(rowNum, newGroup);

            var newGroupList = appManager.Groups.GetGroupList();
            oldGroupList[rowNum - 1].Name = newGroup.Name;
            oldGroupList.Sort();
            newGroupList.Sort();
            Assert.AreEqual(oldGroupList, newGroupList);

            appManager.Auth.Logout();
        }
    }
}
