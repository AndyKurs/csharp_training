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
            app.Navigator.GoToContactPage();
            if (!app.Contact.IsContactPresent())
            {
                ContactData newDataC = new ContactData("Vasya", "Ivanchikoff");
                app.Contact.createContact(newDataC);
            }

            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Remove();
            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
           ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            //Assert.AreEqual(oldContacts, newContacts);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }

}
