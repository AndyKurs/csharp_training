using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantisBT_Tests

{
    public class ProjectHelper : HelperBase
    {
      
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {
         
        }

        public ProjectHelper createProject(ProjectData project) 
        {
            manager.Navigator.GoToProjectsPage();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            return this;
        }

        private List<ProjectData> projectCache = null;

        public int GetProjectCount()
        {
            manager.Navigator.GoToProjectsPage();
            return driver.FindElements(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr")).Count;
        }

        public List<ProjectData> GetProjectList()
        {
            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();
                manager.Navigator.GoToProjectsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr"));
                foreach (IWebElement element in elements)
                {
                    IWebElement t = element.FindElement(By.XPath("./td/a"));
                    projectCache.Add(new ProjectData(t.Text));
                   
                }
            }

            return new List<ProjectData>(projectCache);

        }




        public ProjectHelper Remove()
        {
            manager.Navigator.GoToProjectsPage();
            SelectProject();
            RemoveProject();
            
            return this;
        }

       

        public ProjectHelper SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
            projectCache = null;
            return this;
        }

        public ProjectHelper FillProjectForm(ProjectData project) 
        {
            
            Type(By.Name("name"), project.Name);
            return this;
        }

        
        public ProjectHelper InitProjectCreation()
        {
            driver.FindElement(By.CssSelector("button.btn.btn-primary.btn-white.btn-round")).Click();
            return this;
        }

        public ProjectHelper RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            projectCache = null;
            return this;
        }

        public bool IsProjectPresent()
        {
            var elements = driver.FindElements(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td/a"));
            return (elements.Count() == 1);
        }

        public ProjectHelper SelectProject()
        {
            driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td/a")).Click();      //"//span[" + (v + 1) + "]/input")).Click(); //By.Name("selected[]")).Click();
            return this;
        }
    }
}
