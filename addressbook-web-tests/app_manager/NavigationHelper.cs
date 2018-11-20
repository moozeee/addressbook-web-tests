using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseUrl;

        public NavigationHelper(IWebDriver _driver, string _baseUrl) : base(_driver)
        {
            this.baseUrl = _baseUrl;
        }

        public void GoToMainPage()
        {
            driver.Navigate().GoToUrl(baseUrl + "/addressbook");
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
