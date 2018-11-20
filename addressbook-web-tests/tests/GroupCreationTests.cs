using addressbook_web_tests;
using NUnit.Framework;
using Microsoft.CSharp;
using System;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            appManager.Navigator.GoToGroupsPage();
            appManager.Groups.Create(false);
            appManager.Auth.Logout();
        }
    }
}
