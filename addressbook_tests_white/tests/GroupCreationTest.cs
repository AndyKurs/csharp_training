using NUnit.Framework;
using System;
using System.Collections.Generic;

//using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newGroup = new GroupData()
            {
                Name = "white"
            };

            app.Groups.Add(newGroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }

       
    }
}