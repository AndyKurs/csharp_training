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

        private List<ContactData> contactCache = null;

        public int GetContactCount()
        {
            manager.Navigator.GoToContactPage();
            return driver.FindElements(By.Name("entry")).Count;
        }

        public List<ContactData> GetContactList()
        {

            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToContactPage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    var cels = element.FindElements(By.TagName("td"));
                    string ln = cels[1].Text;
                    string fn = cels[2].Text;
                    //ContactData contact = new ContactData(fn, ln)
                    //{
                    //    Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    //};
                    contactCache.Add(new ContactData(fn, ln)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
   
            return new List<ContactData>(contactCache);

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
            contactCache = null;
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
            contactCache = null;
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
            contactCache = null;
            return this;
        }
    

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")).Click();   ////table[@id='maintable']/tbody/tr[2]/td[8]/a/img  
           // driver.FindElements(By.Name("entry"))[0]
           //.FindElements(By.TagName("tg"))[7]       // 8 ?
           //.FindElement(By.TagName("a")).Click();
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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEMails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEMails
            };
            //throw new NotImplementedException();
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContactModification();
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string eMail = driver.FindElement(By.Name("email")).GetAttribute("value");
            string eMail2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string eMail3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = eMail,
                Email2 = eMail2,
                Email3 = eMail3

            };
            //throw new NotImplementedException();
        }

    }
}
