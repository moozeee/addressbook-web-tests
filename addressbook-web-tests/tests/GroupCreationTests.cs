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
            GroupData group = new GroupData(appManager.Groups.GetRandomWord());
            appManager.Groups.CreateGroup(group);

            var newGroupList = appManager.Groups.GetGroupList();
            oldGroupList.Add(group);
            oldGroupList.Sort();
            newGroupList.Sort();
            Assert.AreEqual(oldGroupList, newGroupList);

            //Assert.AreEqual(oldGroupList.Count + 1, newGroupList.Count);

            //for (int i = 0; i < 10; i++)
            //{
            // Here Should be any code for executing in cycle
            //    
            //}


            appManager.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            appManager.Navigator.GoToGroupsPage();
            List<GroupData> oldGroupList = appManager.Groups.GetGroupList();
            appManager.Groups.CreateGroup(true);
            var newGroupList = appManager.Groups.GetGroupList();
            oldGroupList.Add(new GroupData(""));
            oldGroupList.Sort();
            newGroupList.Sort();
            Assert.AreEqual(oldGroupList, newGroupList);
            appManager.Auth.Logout();
        }
    }
}
