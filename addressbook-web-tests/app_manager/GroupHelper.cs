using addressbook_web_tests;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(AppManager _manager) : base(_manager)
        {
        }

        public GroupHelper CreateEmptyGroup()
        {
            _manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            SubmitGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper CreateGroup()
        {
            _manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupFields(GetRandomGroupData());
            SubmitGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper RemoveGroup(int groupNumber)
        {
            _manager.Navigator.GoToGroupsPage();
            SelectGroup(groupNumber);
            ClickRemoveButton();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper ModifyGroup(int groupNum)
        {
            _manager.Navigator.GoToGroupsPage();
            SelectGroup(groupNum);
            InitGroupModification();
            FillGroupFields(GetRandomGroupData());
            UpdateGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper ModifyGroup(int groupNum, GroupData data)
        {
            _manager.Navigator.GoToGroupsPage();
            SelectGroup(groupNum);
            InitGroupModification();
            FillGroupFields(data);
            UpdateGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            CreateGroupIfItIsNotPresent();
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper SubmitGroup()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper UpdateGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private void ClickRemoveButton()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
        }

        public GroupHelper FillGroupFields(GroupData data)
        {
            Type(By.Name("group_name"), data.Name);
            Type(By.Name("group_header"), data.Header);
            Type(By.Name("group_footer"), data.Footer);
            return this;
        }

        public GroupHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public static GroupData GetRandomGroupData()
        {
            //GroupData group = HelperBase.GetRandomObjectData(HelperBase.availableData.Group);
            GroupData group = new GroupData(GetRandomWord());
            group.Header = GetRandomWord();
            group.Footer = GetRandomWord();
            return group;
        }
        private void CreateGroupIfItIsNotPresent()
        {
            if (!IsElementPresent(By.Name("selected[]")))
            {
                _manager.Groups.CreateEmptyGroup();
                _manager.Navigator.GoToGroupsPage();
            }
        }
    }
}
