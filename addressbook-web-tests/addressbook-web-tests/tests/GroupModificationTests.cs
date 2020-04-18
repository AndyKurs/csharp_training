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
            int groupIndex = 1;
            app.Navigator.GoToGroupsPage();
            if (!app.Group.IsGropPresent(groupIndex))
            {
                app.Group.createGroup(newData);
            }
            app.Group.Modify(groupIndex, newData);
        }
    }
}
