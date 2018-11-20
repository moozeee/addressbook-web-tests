using addressbook_web_tests;
using OpenQA.Selenium;
using System;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected string baseURL;
        public enum availableData { Contact, Group };

        public HelperBase(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        public static string GetRandomWord()
        {
            int wordLength = new Random().Next(1, 13);
            string word = "";
            for (int i = 0; i < wordLength; i++)
            {
                string[] Alphabet = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
                int letterNumber = new Random().Next(1, 26);
                double register = new Random().NextDouble();
                System.Threading.Thread.Sleep(10);
                if (register >= 0.5)
                {
                    word += Alphabet[letterNumber].ToUpper();
                }
                else
                {
                    word += Alphabet[letterNumber];
                }
            }
            return word;
        }

        public static dynamic GetRandomObjectData(availableData data)
        {
            object defaultData = null;
            switch (data)
            {
                case availableData.Contact:
                    ContactData contactData = new ContactData(GetRandomWord(), GetRandomWord());
                    contactData.MiddleName = GetRandomWord();
                    contactData.NickName = GetRandomWord();
                    return contactData;
                case availableData.Group:
                    GroupData groupData = new GroupData(GetRandomWord());
                    groupData.Header = GetRandomWord();
                    groupData.Footer = GetRandomWord();
                    return groupData;
            }
            return defaultData;
        }
    }
}
