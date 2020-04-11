using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {


        [Test]
        public void ContactRemovalTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToContactPage();
            GoToHomePage();
            SelectContact();
            RemoveContact();
            GoToHomePage();
            Logout();
        }
    }

}
