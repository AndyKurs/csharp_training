﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using NUnit.Framework;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                      Header = parts[1],
                      Footer = parts[2]
                });
                   
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>)new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            //GroupData group = new GroupData("n98");
            //group.Header = "t98";
            //group.Footer = "v98";
            List<GroupData> oldGroups = GroupData.GetAll();  //app.Group.GetGroupList();
            app.Group.createGroup(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();  //app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDBConnectivity()
        {
            foreach (ContactData contact in GroupData.GetAll()[0].GetContacts())
            {
                System.Console.Out.WriteLine(contact);
            }
        }

        //[Test]
        //public void TestDBConnectivity()
        //{
        //    DateTime start = DateTime.Now;
        //    List<GroupData> fromUi = app.Group.GetGroupList();
        //    DateTime end = DateTime.Now;
        //    System.Console.Out.WriteLine(end.Subtract(start));
        //    start = DateTime.Now;
        //    List<GroupData> fromDb = GroupData.GetAll();
        //    end = DateTime.Now;
        //    System.Console.Out.WriteLine(end.Subtract(start));
        //}
        //[Test]
        //public void EmptyGroupCreationTest()
        //{
        //    GroupData group = new GroupData("");
        //    group.Header = "";
        //    group.Footer = "";
        //    List<GroupData> oldGroups = app.Group.GetGroupList();
        //    app.Group.createGroup(group);
        //    Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupCount());
        //    List<GroupData> newGroups = app.Group.GetGroupList();
        //    oldGroups.Add(group);
        //    oldGroups.Sort();
        //    newGroups.Sort();
        //    Assert.AreEqual(oldGroups, newGroups);
        //}
    }
}

