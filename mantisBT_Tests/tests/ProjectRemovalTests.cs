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
    public class ProjectRemovalTests : AuthTestBase
    {
       

        [Test]
        public void ProjectRemovalTest()
        {
            ProjectData newData = new ProjectData("eee");
            newData.Name = "ffdgf";
           
            app.Navigator.GoToProjectsPage();
            if (!app.Project.IsProjectPresent())
            {
                app.Project.createProject(newData);
            }
           
            List<ProjectData> oldProjects = app.Project.GetProjectList();
            app.Project.Remove();
            Assert.AreEqual(oldProjects.Count - 1, app.Project.GetProjectCount());
            List<ProjectData> newProjects = app.Project.GetProjectList();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

           

        }

    }
}
