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
            if (driver.Url == _baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(_baseURL + "/addressbook/");
        }

        public void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == _baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            if (driver.Url == _baseURL + "/addressbook/"
                && IsElementPresent(By.Name("searchstring")))
            {
                return;
            }
        }
    }
}
