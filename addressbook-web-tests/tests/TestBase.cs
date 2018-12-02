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
            appManager.Navigator.GoToMainPage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            appManager.Auth.Logout();
            appManager.StopDriver();
        }
    }
}
