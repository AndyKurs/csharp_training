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
    public class APIHelper : HelperBase
    {

        public APIHelper(ApplicationManager manager) : base(manager)
        { }


            public void createNewProject(AccountData account, Mantis.ProjectData data)
            {
                Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            //Mantis.ProjectData mData = new Mantis.ProjectData();
            //mData.name = data.Name;

           
            //project.name = "SOAP Project";
            client.mc_project_add(account.Username, account.Password, data);

            }

        public List<string> GetSoapProjectList(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] lists = client.mc_projects_get_user_accessible(account.Username, account.Password);

            List<string> res = new List<string>();
            foreach ( var p in lists)
            {
                res.Add(p.name);
            }
            return res;
        }

        //mc_project_get_id_from_name

        internal string SoapRemove(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] lists = client.mc_projects_get_user_accessible(account.Username, account.Password);
            string name = lists[0].name;
            var id = client.mc_project_get_id_from_name(account.Username, account.Password, lists[0].name);
            
            client.mc_project_delete(account.Username, account.Password,id);
            return name;
        }
    }
}
