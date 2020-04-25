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
            ContactData newDataC = new ContactData("Juaroslav", "Ivanchikoff");
            //newDataC.Sname = "Petrovichus";
            //newDataC.Lname = null; // "Pupkinov";
            app.Navigator.GoToContactPage();
            if (!app.Contact.IsContactPresent())
            {
                app.Contact.createContact(newDataC);
            }
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Modify(newDataC);
            List<ContactData> newContacts = app.Contact.GetContactList();
            
            oldContacts[0].Fname = newDataC.Fname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
