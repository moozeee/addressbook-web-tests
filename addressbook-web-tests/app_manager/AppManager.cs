using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class AppManager
    {
        private IWebDriver driver;
        public string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public AppManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            baseURL = "http://localhost";

            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }

        public void StopDriver()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
