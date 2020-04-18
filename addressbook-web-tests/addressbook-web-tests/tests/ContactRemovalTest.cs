using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    [TestFixture]
   
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData newDataC = new ContactData("Ivanchikoff");
            newDataC.Lname = "Pupkinov";
            app.Navigator.GoToContactPage();
            if (!app.Contact.IsContactPresent())
            {
                app.Contact.createContact(newDataC);
            }
            app.Contact.Remove();

        }
    }

}
