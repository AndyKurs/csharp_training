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
using Newtonsoft.Json;


namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Console.Out.WriteLine("Hello World!");
            string associations = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            //StreamWriter writerC = new StreamWriter(args[2]);
            string format = args[3];

            List<Data> dataList = new List<Data>();

            if (associations == "groups")
            {
                for (int i = 0; i < count; i++)
                {
                  
                    dataList.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
            }
            else if (associations == "contacts")
            { 
                for (int i = 0; i < count; i++)
                {
                    ContactData d = new ContactData()
                    {
                        Fname = TestBase.GenerateRandomString(10),
                        Lname = TestBase.GenerateRandomString(10)
                    };
                    System.Console.Out.WriteLine("New Contact: " + d);
                    dataList.Add(d);
                }
            }

            else
            {
                System.Console.Out.WriteLine("bad associations");
                return;
            }


            if (format == "csv")
            { 
              writeGroupsToCsvFile(dataList, writer);
            }
            else if (format == "xml")
            {
                writeDataToXmlFile(dataList, writer);
            }
            else if (format == "json")
            {
                writeDataToJsonFile(dataList, writer);
            }
            else
            {
                System.Console.Out.WriteLine("Unrecognized format" + format);
                return;
            }
            writer.Close();
        }

        static void writeGroupsToCsvFile(List<Data> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
           
        }

        static void writeDataToXmlFile(List<Data> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<Data>)).Serialize(writer, groups);
        }

        static void writeDataToJsonFile(List<Data> groups, StreamWriter writer)
        {
          writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writerC)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writerC, contacts);
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writerC)
        {
            writerC.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
            // System.Console.Out.WriteLine("Number of contacts: " + contacts.Count);

            //string encodedData = JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented);
            // System.Console.Out.WriteLine("Contacts data: " + encodedData);

            // writerC.Write(encodedData);
            // writerC.Flush();
        }
    }
}
