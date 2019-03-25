using addressbook_web_tests;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected HelperBase helperBase;
        protected AppManager appManager;

        [SetUp]
        public void SetupAppManager()
        {
            appManager = AppManager.GetInstance();
        }
    }
}
