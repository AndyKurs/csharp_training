using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> groups = GroupData.GetAll();

            if (groups.Count <= 0)
            {
                GroupData newData = new GroupData("nnn");
                newData.Header = null; // "ttt";
                newData.Footer = null; // "vvv";

                app.Group.createGroup(newData);

                groups = GroupData.GetAll();

                Assert.IsTrue(groups.Count > 0);
            }

            GroupData group = groups.First();

            List<ContactData> contacts = ContactData.GetAll();
            
            if (contacts.Count <= 0 )
            {
                ContactData newDataC = new ContactData("Juaroslav", "Ivanchikoff");
                app.Contact.createContact(newDataC);

                contacts = ContactData.GetAll();

                Assert.IsTrue(contacts.Count > 0);
            }

            List<ContactData> oldList = group.GetContacts();


            List<ContactData> availableContacts = ContactData.GetAll().Except(oldList).ToList();

            ContactData toAdd;

            if (availableContacts.Count <= 0)
            {
                toAdd = new ContactData("Juaroslav", "Ivanchikoff");
                app.Contact.createContact(toAdd);

                availableContacts = ContactData.GetAll().Except(oldList).ToList();

                Assert.IsTrue(availableContacts.Count > 0);
            }
            
            toAdd = availableContacts.First();

            app.Contact.AddContactToGroup(toAdd, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(toAdd);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
