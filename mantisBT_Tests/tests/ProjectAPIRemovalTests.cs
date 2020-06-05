using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantisBT_Tests
{
    [TestFixture]
    public class ProjectAPIRemovalTests : AuthTestBase
    {
       

        [Test]
        public void ProjectAPIRemovalTest()
        {
            string now = DateTime.Now.ToString("u");

            AccountData account = new AccountData("administrator", "password");

            Mantis.ProjectData data = new Mantis.ProjectData();
            data.name = "SoapPr" + now;

            List<string> oldProjects = app.API.GetSoapProjectList(account);

            
            if (oldProjects == null || oldProjects.Count <= 0)
            {
              app.API.createNewProject(account, data);
                oldProjects = app.API.GetSoapProjectList(account);
            }

            var name = app.API.SoapRemove(account);

            List<string> newProjects = app.API.GetSoapProjectList(account);
            newProjects.Add(name); 
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

           

        }

    }
}
