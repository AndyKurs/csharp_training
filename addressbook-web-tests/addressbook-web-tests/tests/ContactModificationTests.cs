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
            //newDataC.Sname = "Petrovichus";
            //newDataC.Lname = null; // "Pupkinov";
            app.Navigator.GoToContactPage();
            if (!app.Contact.IsContactPresent())
            {
                ContactData newDataC = new ContactData("Juaroslav", "Ivanchikoff");
                app.Contact.createContact(newDataC);
            }
            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData oldData = oldContacts[0];

            ContactData update = new ContactData("Peter", "The Great");
            app.Contact.Modify(update);

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());
            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts[0] = update;

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(update.Lname, contact.Lname);
                    Assert.AreEqual(update.Fname, contact.Fname);
                }
               
            }
        }
    }
}
