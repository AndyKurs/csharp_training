using System;
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

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToContactPage();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            foreach (IWebElement element in elements)
            {
                var cels = element.FindElements(By.TagName("td"));
                string ln = cels[1].Text;
                string fn = cels[2].Text;
                contacts.Add(new ContactData(fn, ln));
            }
            return contacts;

        }

        public ContactHelper Modify(ContactData newDataC)
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
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper Remove()
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
            Type(By.Name("firstname"), contact.Fname);
            Type(By.Name("lastname"), contact.Lname);
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
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")).Click();     //By.Id("5")).Click(); //???
           
            acceptNextAlert = true;
            return this;
        }

        public bool IsContactPresent()
        {
            var elements = driver.FindElements(By.XPath("//img[@alt='Edit']"));
            return (elements.Count() == 1);
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
