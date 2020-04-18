using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests

{
    public class GroupHelper : HelperBase
    {
      
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
         
        }

        public GroupHelper createGroup(GroupData group) 
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            //ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();


            return this;
        }

       public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group) //string name, string header, string footer)
        {
            
            // driver.FindElement(locator).Click();
            Type(By.Name("group_name"), group.Name);
            //driver.FindElement(By.Name("group_header")).Click();
            Type(By.Name("group_header"), group.Header);
            // driver.FindElement(By.Name("group_footer")).Click();
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int v)
        {
            driver.FindElement(By.XPath("//span[" + v + "]/input")).Click(); //By.Name("selected[]")).Click();
            //By.XPath("//input[@name='selected[]'])[" + v + "]")).Click();
            return this;
        }
    }
}
