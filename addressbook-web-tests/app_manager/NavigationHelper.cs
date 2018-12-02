using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string _baseURL;
        public NavigationHelper(AppManager _manager, string baseURL) : base(_manager)
        {
            _baseURL = baseURL;
        }

        public void GoToMainPage()
        {
            driver.Navigate().GoToUrl(_baseURL + "/addressbook");
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
