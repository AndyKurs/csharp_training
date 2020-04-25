using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Ivan", "Grozniy");
            //contact.Sname = "Petrovich";
            //contact.Lname = "Pupkin";
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.createContact(contact);
            List<ContactData> newContacts = app.Contact.GetContactList();
            //Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
    
}

