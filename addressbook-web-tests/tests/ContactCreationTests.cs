using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            appManager.Contacts.CreateContact();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            appManager.Contacts.CreateEmptyContact();
        }
    }
}
