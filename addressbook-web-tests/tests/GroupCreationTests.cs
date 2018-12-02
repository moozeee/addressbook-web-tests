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
            appManager.Groups.CreateGroup();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            appManager.Groups.CreateEmptyGroup();
        }
    }
}
