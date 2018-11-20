using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(IWebDriver _driver) : base (_driver)
        {
        }

        public ContactHelper CreateContact(bool empty)
        {
            InitNewContactCreation();
            FillContactForm(GetRandomContactData(empty));
            return this;
        }

        public ContactHelper FillContactForm(ContactData _contactData)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(_contactData.FirstName);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(_contactData.MiddleName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(_contactData.LastName);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(_contactData.NickName);
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.XPath("(//input[@name='submit'])")).Click();
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public static ContactData GetRandomContactData(bool empty)
        {
            ContactData contact;
            if (empty)
            {
                contact = new ContactData();
            }
            else
            {
                contact = HelperBase.GetRandomObjectData(HelperBase.availableData.Contact);
            }
            return contact;
        }
    }
}
