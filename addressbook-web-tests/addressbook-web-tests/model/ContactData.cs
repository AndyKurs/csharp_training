using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebAdressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        //private string fname;
        //private string sname = "";
        //private string lname = "";

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

    }
}
