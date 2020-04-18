using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {


        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            //app.Auth.Login(new AccountData("admin", "secret"));
        }


        //[TearDown]
        //public void StopApplicationManager()
        //{
        //    ApplicationManager.GetInstance().Stop();
        //}
    }
}
