using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdressbookTests
{
    class ContactData
    {
        private string fname;
        private string sname = "";
        private string lname = "";

        public ContactData(string fname)
        {
            this.fname = fname;
        }

        public string Fname
        {
            get
            {
                return fname;
            }
            set
            {
                fname = value;
            }
        }

        public string Sname
        {
            get
            {
                return sname;
            }
            set
            {
                sname = value;
            }
        }

        public string Lname
        {
            get
            {
                return lname;
            }
            set
            {
                lname = value;
            }
        }
    }
}
