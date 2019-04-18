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

        private List<GroupData> groupCache = null;

        public GroupHelper CreateGroup(bool empty)
        {
            _manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            if (!empty)
            {
                FillGroupFields(GetRandomGroupData());
            }
            SubmitGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper CreateGroup(GroupData data)
        {
            _manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupFields(data);
            SubmitGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper RemoveGroup(int groupNumber)
        {
            _manager.Navigator.GoToGroupsPage();
            SelectGroup(groupNumber);
            ClickRemoveButton();
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
            driver.FindElement(By.XPath("//span[@class='group'][" + index + "]/input")).Click();
            return this;
        }

        private void CreateGroupIfItIsNotPresent()
        {
            if (!IsElementPresent(By.Name("selected[]")))
            {
                _manager.Groups.CreateGroup(true);
                _manager.Navigator.GoToGroupsPage();
            }
        }

        public GroupHelper SubmitGroup()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper UpdateGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        private GroupHelper ClickRemoveButton()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            groupCache = null;
            return this;
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

        public GroupData GetRandomGroupData()
        {
            //GroupData group = HelperBase.GetRandomObjectData(HelperBase.availableData.Group);
            GroupData group = new GroupData(GetRandomWord());
            group.Header = GetRandomWord();
            group.Footer = GetRandomWord();
            return group;
        }

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                _manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData>(groupCache);
        }

        public GroupData GetGroupData(int rowNum)
        {
            IWebElement element = driver.FindElement(By.XPath("//span[@class='group'][" + rowNum + "]"));
            return new GroupData(element.Text)
            {
                Id = element.FindElement(By.TagName("input")).GetAttribute("value")
            };
        }

        public bool IsGroupInGroupList(GroupData data, List<GroupData> list)
        {
            return list.Contains(data);
        }
    }
}
