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
    public class LoginHelper : HelperBase
    {
       
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountData account)
        {
           
            Type(By.Name("username"), account.Username);
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();

            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
        }

        public void Logout()

        {
           
            driver.FindElement(By.XPath("//div[@id='navbar-container']/div[2]/ul/li[3]/a/i[2]")).Click();
            driver.FindElement(By.XPath("//div[@id='navbar-container']/div[2]/ul/li[3]/ul/li[4]/a")).Click();
        }
    }
}
