using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    class DellitingContactFromGroupTest : AuthTestBase
    {
        [Test]
        public void TestDellitingContactFromGroup()
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

            if (contacts.Count <= 0)
            {
                ContactData newDataC = new ContactData("Juaroslav", "Ivanchikoff");
                app.Contact.createContact(newDataC);

                contacts = ContactData.GetAll();

                Assert.IsTrue(contacts.Count > 0);
            }

            List<ContactData> oldList = group.GetContacts();
            ContactData toDelete;

            if (oldList.Count <= 0)
            {
                toDelete = ContactData.GetAll().First();
                app.Contact.AddContactToGroup(toDelete, group);
                oldList = group.GetContacts();

                Assert.IsTrue(oldList.Count > 0);
            }

            ContactData contact = oldList.First();
            app.Contact.DelContactFromGroup(contact, group);
            List<ContactData> newList = group.GetContacts();
            newList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
