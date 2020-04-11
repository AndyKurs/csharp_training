using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        

        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToContactPage();
            app.Contact.InitNewContact();
            ContactData contact = new ContactData("Ivan");
            //contact.Sname = "Petrovich";
            contact.Lname = "Pupkin";
            app.Contact.FillContactForm(contact);
            app.Contact.SubmitContactForm();
            app.Auth.Logout();
        }

    }
}

