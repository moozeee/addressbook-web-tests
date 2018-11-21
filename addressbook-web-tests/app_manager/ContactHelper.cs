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
            if (!empty)
            {
                FillContactForm(GetRandomContactData());
            }
            SubmitContact();
            return this;
        }

        public ContactHelper CreateContact(string a, string b)
        {
            InitNewContactCreation();
            ContactData data = new ContactData(a, b);
            FillContactForm(data);
            SubmitContact();
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
            return this;
        }

        public ContactHelper SubmitContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])")).Click();
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public static ContactData GetRandomContactData()
        {
            //ContactData contact = HelperBase.GetRandomObjectData(HelperBase.availableData.Contact);
            ContactData contact = new ContactData(GetRandomWord(), GetRandomWord());
            contact.MiddleName = GetRandomWord();
            contact.NickName = GetRandomWord();
            return contact;
        }
    }
}
