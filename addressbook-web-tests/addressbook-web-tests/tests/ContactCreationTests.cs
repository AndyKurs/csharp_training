﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Ivan");
            //contact.Sname = "Petrovich";
            contact.Lname = "Pupkin";
            app.Contact.createContact(contact);
            
            app.Auth.Logout();
        }

    }
}
