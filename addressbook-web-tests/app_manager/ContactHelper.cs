using OpenQA.Selenium;
using System.Collections.Generic;

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

        public ContactHelper CreateContact(string firstname, string lastname)
        {
            InitNewContactCreation();
            ContactData data = new ContactData(firstname, lastname);
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

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.CssSelector("input[type='button'][value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
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

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//*[@id='maintable']/tbody/tr[@name='entry']"));
            foreach (IWebElement element in elements)
            {
                var tds = element.FindElements(By.CssSelector("td"));
                contacts.Add(new ContactData(tds[1].Text, tds[2].Text));
            }
            return contacts;
        }
    }
}
