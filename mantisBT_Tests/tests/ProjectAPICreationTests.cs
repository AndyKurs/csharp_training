using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using NUnit.Framework;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace mantisBT_Tests
{
    [TestFixture]
    public class ProjectAPICreationTests : AuthTestBase
    {
       
        [Test]
        public void ProjectAPICreationTest()
        {
            string now = DateTime.Now.ToString("u");

            AccountData account = new AccountData("administrator", "password");

            Mantis.ProjectData data = new Mantis.ProjectData();
            data.name = "SoapPr" + now;

            List<string> oldProjects = app.API.GetSoapProjectList(account);

            app.API.createNewProject(account, data);

            List<string> newProjects = app.API.GetSoapProjectList(account);
            oldProjects.Add(data.name);   
            oldProjects.Sort();
            newProjects.Sort();
             Assert.AreEqual(oldProjects, newProjects);
        }


       
    }
}

