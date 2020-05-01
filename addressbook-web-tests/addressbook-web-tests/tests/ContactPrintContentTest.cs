using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactPrintContentTest : AuthTestBase
    {
        [Test]
        public void ContactContentTest()
        {
            System.Console.Out.WriteLine("let's start!");
            //string text = app.Contact.GetContactInformationFromPersonForm();
            //System.Console.Out.WriteLine(text);

            //ContactData data = app.Contact.GetContactInformationFromEditForm(0);
            //string cd_text = data.ToContentCompare();
            //System.Console.Out.WriteLine(cd_text);

            //Assert.AreEqual(text, cd_text);

            System.Console.Out.Write("hey1111!");
        }
    }
}
