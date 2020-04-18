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
    public class GroupRemovalTests : AuthTestBase
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
            app.Group.Remove(1);
           
        }

    }
}
