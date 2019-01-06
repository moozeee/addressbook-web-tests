using System;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(AppManager _manager) : base(_manager)
        {
        }

        public void Login(AccountData _account)
        {
            if (isLoggedIn())
            {
                if (isLoggedIn(_account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), _account.Username);
            Type(By.Name("pass"), _account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool isLoggedIn(AccountData account)
        {
            return (isLoggedIn()
                && driver.FindElement(By.Name("logout"))
                .FindElement(By.TagName("b")).Text == ("("+ account.Username + ")"));
        }

        public bool isLoggedIn()
        {
            return (IsElementPresent(By.Name("logout")));
        }

        public void Logout()
        {
            if (isLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
    }
}
