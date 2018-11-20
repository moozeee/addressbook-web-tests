using addressbook_web_tests;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class TestBase
    {
        protected HelperBase helperBase;
        public AppManager appManager;

        [SetUp]
        public void SetupTest()
        {
            appManager = new AppManager();
        }

        [TearDown]
        public void TeardownTest()
        {
            appManager.StopDriver();
        }

        public static GroupData GetRandomGroupData()
        {
            GroupData group = HelperBase.GetRandomObjectData(HelperBase.availableData.Group);
            return group;
        }

        public static ContactData GetRandomContactData()
        {
            ContactData contact = HelperBase.GetRandomObjectData(HelperBase.availableData.Contact);
            return contact;
        }
    }
}
