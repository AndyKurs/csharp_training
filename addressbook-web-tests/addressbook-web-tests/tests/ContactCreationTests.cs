﻿using System;
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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                // TODO: why do you need to initialze fields twice???
                contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(10)));
                //{
                //    Fname = GenerateRandomString(10),
                //    Lname = GenerateRandomString(10)
                //});
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
             //= new ContactData("Ivan", "Grozniy");
            //contact.Sname = "Petrovich";
            //contact.Lname = "Pupkin";
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.createContact(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());
            List<ContactData> newContacts = app.Contact.GetContactList();
            //Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
    
}

