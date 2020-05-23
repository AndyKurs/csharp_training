using System;
using System.Collections.Generic;
using System.Text;
using TestStack.White;
using TestStack.White.WindowsAPI;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using System.Windows.Automation;

namespace adressbook_tests_white1
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELGROUPWINTITLE = "Delete group";

       
        public GroupHelper(ApplicationManager manager) : base(manager) { }

       
        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialog = OpenGroupsDialog();
           Tree tree = dialog.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
            CloseGroupsDialog(dialog);
            return list;

        }

        public void Add(GroupData newGroup)
        {
            Window dialog = OpenGroupsDialog();
            dialog.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialog.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
           
            CloseGroupsDialog(dialog);

        }

        public void Del() 
        {
            Window dialog = OpenGroupsDialog();
            Tree tree = dialog.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            TreeNodes groupNodes = root.Nodes;
            TreeNode delNode = groupNodes[0];
            delNode.Click();
            Window delGropuDialog = DelGroupsDialog(dialog);
            delGropuDialog.Get<RadioButton>("uxDeleteAllRadioButton").Click();
            CloseDelGroupsDialog(delGropuDialog); 
            CloseGroupsDialog(dialog);
        }


        private void CloseGroupsDialog(Window dialog)
        {
            dialog.Get<Button>("uxCloseAddressButton").Click();
        }

        private Window OpenGroupsDialog()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }

        private Window DelGroupsDialog(Window dialog)
        {
            dialog.Get<Button>("uxDeleteAddressButton").Click();
            return dialog.ModalWindow(DELGROUPWINTITLE);
        }

        private Window CloseDelGroupsDialog(Window delGropuDialog)
        {
            delGropuDialog.Get<Button>("uxOKAddressButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }
    }
}