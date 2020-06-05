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
    public class ProjectCreationTests : AuthTestBase
    {

        [Test]
        public void ProjectCreationTest()
        {
            string now = DateTime.Now.ToString("u");

            ProjectData project = new ProjectData("n98+" + now);
            List<ProjectData> oldProjects = app.Project.GetProjectList();
            app.Project.createProject(project);


            Assert.AreEqual(oldProjects.Count + 1, app.Project.GetProjectCount());

            List<ProjectData> newProjects = app.Project.GetProjectList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }



    }
}

