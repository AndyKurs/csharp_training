using System;
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
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newDataC = new ContactData("Ivanchikoff");
            //newDataC.Sname = "Petrovichus";
            newDataC.Lname = null; // "Pupkinov";
            app.Navigator.GoToContactPage();
            if (!app.Contact.IsContactPresent())
            {
                app.Contact.createContact(newDataC);
            }
            app.Contact.Modify(newDataC);
        }
    }
}
