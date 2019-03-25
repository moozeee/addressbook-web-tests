using addressbook_web_tests;
using NUnit.Framework;
using Microsoft.CSharp;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            appManager.Navigator.GoToGroupsPage();
            List<GroupData> oldGroupList = appManager.Groups.GetGroupList();

            appManager.Groups.Create(false);

            var newGroupList = appManager.Groups.GetGroupList();
            Assert.AreEqual(oldGroupList.Count + 1, newGroupList.Count);
            appManager.Auth.Logout();
        }
    }
}
