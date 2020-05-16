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
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
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
