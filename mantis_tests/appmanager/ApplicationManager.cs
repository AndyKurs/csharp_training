using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        //protected StringBuilder verificationErrors;
        protected string baseURL;

        public RegistrationHelper Registration { get; private set; }
        public FTPHelper FTP { get; private set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver("C:\\Windows\\SysWOW64\\");
            baseURL = "http://localhost";
            Registration = new RegistrationHelper(this);
            FTP = new FTPHelper(this);
           
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.24.1/mantisbt-2.24.1/login_page.php";
                app.Value  = newInstance;
              
            }
            return app.Value;
        }

        //public void Stop()
        //{
        //    try
        //    {
        //        driver.Quit();
        //    }
        //    catch (Exception)
        //    {
        //        // Ignore errors if unable to close the browser
        //    }
        //    //Assert.AreEqual("", verificationErrors.ToString());
        //}

       

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    }
}
