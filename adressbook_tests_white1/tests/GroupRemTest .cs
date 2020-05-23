using NUnit.Framework;
using System;
using System.Collections.Generic;



namespace adressbook_tests_white1
{
    [TestFixture]
    public class GroupRemTest : TestBase
    {
        [Test]
        public void TestGroupRem()
        {
           
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            if (oldGroups == null || oldGroups.Count <= 1)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "Add"
                };
                app.Groups.Add(newGroup);
                oldGroups = app.Groups.GetGroupList();
            }
            Assert.IsTrue(oldGroups.Count > 1);

            GroupData toRemovedGroup = oldGroups[0];
           
            app.Groups.Del();
            List<GroupData> newGroups = app.Groups.GetGroupList();
            newGroups.Add(toRemovedGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
       
    }
}