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
    public class GroupRemovalTests : GroupTestBase
    {
       

        [Test]
        public void GroupRemovalTest()
        {
            GroupData newData = new GroupData("eee");
            newData.Header = "ffdgf";
            newData.Footer = "fhhky";
            int groupIndex = 1;
            app.Navigator.GoToGroupsPage();
            if (!app.Group.IsGropPresent(groupIndex))
            {
                app.Group.createGroup(newData);
            }
            List<GroupData> oldGroups = GroupData.GetAll();  //app.Group.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];

            app.Group.Remove(toBeRemoved);//(0);
            Assert.AreEqual(oldGroups.Count - 1, app.Group.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll(); //app.Group.GetGroupList();
            //GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }

    }
}
