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
   
    public class GroupRemovalTests : TestBase
    {
       

        [Test]
        public void GroupRemovalTest()
        {
            app.Group.Remove(2);
           
        }

    }
}
