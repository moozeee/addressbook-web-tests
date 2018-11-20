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
            appManager.Navigator.GoToMainPage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
            appManager.Navigator.GoToGroupsPage();
            appManager.Groups.InitNewGroupCreation();
            appManager.Groups.FillGroupFields(GetRandomGroupData());
            appManager.Groups.SubmitGroup();
            appManager.Groups.ReturnToGroupsPage();
            appManager.Auth.Logout();
        }
    }
}
