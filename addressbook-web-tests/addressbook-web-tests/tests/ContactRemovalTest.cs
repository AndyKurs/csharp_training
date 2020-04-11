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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToContactPage();
            app.Navigator.GoToHomePage();
            app.Contact.SelectContact();
            app.Contact.RemoveContact();
            app.Navigator.GoToHomePage();
            app.Auth.Logout();
        }
    }

}
