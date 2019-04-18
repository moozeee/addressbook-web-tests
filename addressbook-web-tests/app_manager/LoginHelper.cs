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
            return isLoggedIn() && GetLoggedUserName() == account.Username;
        }

        private string GetLoggedUserName()
        {
            string text = driver.FindElement(By.Name("logout"))
                .FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }

        public bool isLoggedIn()
        {
            return (IsElementPresent(By.Name("logout")));
        }

        private bool isNameCorrect(AccountData account)
        {
            if (GetLoggedUserName().Equals(account.Username))
            {
                return true;
            }
            return false;
        }

        public void Logout()
        {
            if (isLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool AssertLoginSuccess(AccountData account)
        {
            if (isLoggedIn() && isNameCorrect(account))
                {
                    return true;
                }
            return false;
        }
    }
}
