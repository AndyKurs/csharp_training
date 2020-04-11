using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData newData = new GroupData("nnn");
            newData.Header = "ttt";
            newData.Footer = "vvv";
            app.Group.Modify(1, newData);


        }
    }
}
