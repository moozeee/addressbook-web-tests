﻿using addressbook_web_tests;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected AppManager _manager;
        protected IWebDriver driver;

        public enum availableData { Contact, Group };

        public HelperBase(AppManager manager)
        {
            this._manager = manager;
            driver = _manager.Driver;
        }

        public string GetRandomWord()
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

        protected void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        protected bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
