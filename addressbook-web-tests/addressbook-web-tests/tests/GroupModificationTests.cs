using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {

            GroupData newData = new GroupData("nnn");
            newData.Header = null; // "ttt";
            newData.Footer = null; // "vvv";
            int groupIndex = 0;
            app.Navigator.GoToGroupsPage();
            if (!app.Group.IsGropPresent(groupIndex))
            {
                app.Group.createGroup(newData);
            }
            List<GroupData> oldGroups = app.Group.GetGroupList();
            GroupData oldData = oldGroups[0];
            app.Group.Modify(groupIndex, newData);
            Assert.AreEqual(oldGroups.Count , app.Group.GetGroupCount());
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
