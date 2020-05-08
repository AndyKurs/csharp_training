using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace WebAdressbookTests
{
    public class ContactData : Data, IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        //private string fname;
        //private string sname = "";
        //private string lname = "";

        public ContactData()
        {
        }
        public ContactData(string fname, string lname)
        {
            Fname = fname;
            Lname = lname;
        }

        public override string ToString()
        {
            return "Contact fname: \"" + Fname + "\", sname: \"" + "sname" + "\", lname: \"" + Lname + "\"";
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Fname == other.Fname) && (Lname == other.Lname);
        }

        public override int GetHashCode()
        {
            string str = Fname + ":" + Lname;
            return str.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int ret = Lname.CompareTo(other.Lname);
            if (ret == 0)
            {
                return Fname.CompareTo(other.Fname);
            }
            else 
            return ret;
        }

        public string Fname { get; set; }
        
        public string Sname { get; set; }

        public string Lname { get; set; }

        public string Id { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string ToContentCompare()

        {
            string textAddr = "";
            string textPhones = "";
            string textMails = "";

            string text = Fname + " " + Lname;
            if (Address != null && Address.Length > 0)
            {
                textAddr = "\r\n" + Address;
            }
            //text += "\r\n";
            if (HomePhone != null && HomePhone.Length > 0)
            {
                textPhones = "\r\nH: " + HomePhone;
            }
            if (MobilePhone != null && MobilePhone.Length > 0)
            {
                textPhones += "\r\nM: " + MobilePhone;
            }
            if (WorkPhone != null && WorkPhone.Length > 0)
            {
                textPhones += "\r\nW: " + WorkPhone;
            }
            //text += "\r\n";
            if (Email != null && Email.Length > 0)
            {
                textMails = "\r\n" + Email;
            }
            if (Email2 != null && Email2.Length > 0)
            {
                textMails += "\r\n" + Email2;
            }
            if (Email3 != null && Email3.Length > 0)
            {
                textMails += "\r\n" + Email3;
            }
            if (textAddr.Length > 0)
            {
                text += textAddr;
            }
            if (textPhones.Length>0)
            {
                text += "\r\n" + textPhones;
            }
            if (textMails.Length > 0)
            {
                text += "\r\n" + textMails;
            }

            return text;

          
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpM(Email) + CleanUpM(Email2) + CleanUpM(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ ()-]","") + "\r\n";
        }

        private string CleanUpM(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email.Replace(" ", "") + "\r\n";
        }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }
    }
}
