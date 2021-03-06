﻿using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(AppManager _manager) : base(_manager)
        {
        }

        private List<ContactData> contactCache = null;

        public ContactHelper CreateContact(bool empty)
        {
            _manager.Navigator.GoToContactsPage();
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

        public ContactHelper ModifyContact(int contactNum, ContactData data)
        {
            _manager.Navigator.GoToContactsPage();
            InitContactModification(contactNum);
            FillContactForm(data);
            UpdateContact();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper ModifyContact(int contactNum)
        {
            _manager.Navigator.GoToContactsPage();
            InitContactModification(contactNum);
            FillContactForm(GetRandomContactData());
            UpdateContact();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper RemoveContact(int contactNum)
        {
            _manager.Navigator.GoToContactsPage();
            SelectContact(contactNum);
            ClickRemoveButton();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int rowNum)
        {
            CreateContactIfItIsNotPresent();
            //var rowNum = contactNum + 1;
            _manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("//table[@id='maintable']//tr[@name='entry'][" + rowNum + "]/td[8]/a/img")).Click();
            return this;
        }

        private void ClickRemoveButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
        }

        private void UpdateContact()
        {
            driver.FindElement(By.XPath("//input[@name='update']")).Click();
            contactCache = null;
        }

        public ContactHelper SelectContact(int contactNum)
        {
            CreateContactIfItIsNotPresent();
            //var rowNum = contactNum + 1;
            driver.FindElement(By.XPath("//table//tr[@name='entry'][" + contactNum + "]//input")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData _contactData)
        {
            Type(By.Name("firstname"), _contactData.FirstName);
            Type(By.Name("middlename"), _contactData.MiddleName);
            Type(By.Name("lastname"), _contactData.LastName);
            Type(By.Name("nickname"), _contactData.NickName);
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

        public ContactData GetRandomContactData()
        {
            //ContactData contact = HelperBase.GetRandomObjectData(HelperBase.availableData.Contact);
            ContactData contact = new ContactData(GetRandomWord(), GetRandomWord());
            contact.MiddleName = GetRandomWord();
            contact.NickName = GetRandomWord();
            return contact;
        }

        private void CreateContactIfItIsNotPresent()
        {
            IWebElement itemsAmount = driver.FindElement(By.Id("search_count"));
            if (Int32.Parse(itemsAmount.Text) == 0)
            {
                _manager.Contacts.CreateContact(false);
                _manager.Navigator.GoToHomePage();
            }
        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                _manager.Navigator.GoToContactsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    var info = element.FindElements(By.CssSelector("td"));
                    var contact = new ContactData(info[2].Text, info[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    };
                    contactCache.Add(contact);
                }
            }
            
            return new List<ContactData>(contactCache);
        }

        public ContactData GetContactData(int rowNum)
        {
            IWebElement element = driver.FindElement(By.XPath("//tr[@name='entry'][" + rowNum + "]"));

            ContactData data = new ContactData();
            data.LastName = element.FindElement(By.XPath("td[2]")).Text;
            data.FirstName = element.FindElement(By.XPath("td[3]")).Text;
            data.Id = element.FindElement(By.TagName("input")).GetAttribute("id");
            return data;
        }

        public bool IsContactInContactList(ContactData data, List<ContactData> list)
        {
            return list.Contains(data);
        }
    }
}
