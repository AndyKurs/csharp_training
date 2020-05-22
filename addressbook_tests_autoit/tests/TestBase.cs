using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_tests_autoit
{
    public class TestBase
    {
        public ApplicationManager app;


        [OneTimeSetUp]
        public void initApplication()
        {
            app = new ApplicationManager();
        }

        [OneTimeTearDown]
        public void stopApplication()
        {
            app.Stop();
        }

    }
}
