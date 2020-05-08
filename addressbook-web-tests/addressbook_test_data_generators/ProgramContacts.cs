using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WebAdressbookTests;


namespace addressbook_test_data_generators
{
    class ProgramContacts
    {
        static void MainC(string[] args)
        {
            //System.Console.Out.WriteLine("Hello World!");
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10)));
                
            }
            //if (format == "Json")
            //{ 
            //writeContactsToJsonFile(contacts, writer);
            //}
            //else 
            if (format == "xml")
            {
                writeContactsToXmlFile(contacts, writer);
            }
            else
            {
                System.Console.Out.WriteLine("Unrecognized format" + format);
            }
            writer.Close();
        }

        

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
    }
}
