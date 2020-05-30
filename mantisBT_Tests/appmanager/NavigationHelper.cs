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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
           
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/mantisbt-2.24.1/mantisbt-2.24.1/login_page.php")
              
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/mantisbt-2.24.1/mantisbt-2.24.1/login_page.php");
        }

        public void GoToProjectsPage()
        {
            if(driver.Url == baseURL + "/mantisbt-2.24.1/mantisbt-2.24.1/manage_proj_page.php"
                && IsElementPresent(By.Name("Проекты")))
            {
                return;
            }
            driver.FindElement(By.CssSelector("i.menu-icon.fa.fa-gears")).Click();
            driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/ul/li[3]/a")).Click();
        }
    }
}
