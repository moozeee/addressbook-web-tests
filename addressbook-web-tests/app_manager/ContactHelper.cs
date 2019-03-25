﻿using System;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(AppManager _manager) : base(_manager)
        {
        }

        public ContactHelper CreateContact()
        {
            _manager.Navigator.GoToContactsPage();
            InitNewContactCreation();
            FillContactForm(GetRandomContactData());
            SubmitContact();
            return this;
        }

        public ContactHelper CreateEmptyContact()
        {
            _manager.Navigator.GoToContactsPage();
            InitNewContactCreation();
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
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int contactNum)
        {
            CreateContactIfItIsNotPresent();
            var rowNum = contactNum + 1;
            _manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + rowNum + "]/td[8]/a/img")).Click();
            return this;
        }

        private void ClickRemoveButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        }

        private void UpdateContact()
        {
            driver.FindElement(By.XPath("//input[@name='update']")).Click();
        }

        public ContactHelper SelectContact(int contactNum)
        {
            CreateContactIfItIsNotPresent();
            var rowNum = contactNum + 1;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + rowNum + "]/td/input")).Click();
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

        public static ContactData GetRandomContactData()
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
                _manager.Contacts.CreateEmptyContact();
                _manager.Navigator.GoToHomePage();
            }
        }
        //просто так
    }
}
