﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newDataC = new ContactData("Ivanchik");
            //newDataC.Sname = "Petrovichus";
            newDataC.Lname = "Pupkinov";
            app.Contact.Modify(newDataC);
            app.Auth.Logout();

        }
    }
}
