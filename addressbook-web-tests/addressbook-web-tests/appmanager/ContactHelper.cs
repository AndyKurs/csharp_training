﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;


namespace WebAdressbookTests

{
    public class ContactHelper : HelperBase
    {
        protected bool acceptNextAlert = true;

        public ContactHelper createContact(ContactData contact)
        {
            manager.Navigator.GoToContactPage();
            InitNewContact();
            FillContactForm(contact);
            SubmitContactForm();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newDataC)
        {
            manager.Navigator.GoToContactPage();
            manager.Navigator.GoToHomePage();
            SelectContactModification();
            FillContactForm(newDataC);
            SubmitContactModificationForm();


            return this;
        }

        public ContactHelper SubmitContactModificationForm()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper SelectContactModification()
        {
            driver.FindElement(By.Id("6")).Click();
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToContactPage();
            manager.Navigator.GoToHomePage();
            SelectContact();
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
          //
        }

        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
    

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Fname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lname);
            return this;
        }
    

        public ContactHelper InitNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }
    

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.Id("5")).Click(); //???
           acceptNextAlert = true;
            return this;
        }
    



        protected string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}