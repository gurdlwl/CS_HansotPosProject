using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace hansot_pos
{
    public partial class TableUserCtrl : UserControl
    {
        public string tableNumber = string.Empty;
        List<MenuInfo> list = new List<MenuInfo>();

        public TableUserCtrl()
        {
            InitializeComponent();
        }
        
        public void SetTableNum(string tableNum)
        {
            this.tableNumber = tableNum;
        }

        public void SetTableNumberLabel(string num)
        {
            this.TableNumber.Text = tableNumber;
            tableNumber = num;
        }

        private void Order_OnOrderComplete(object sender, EventArgs e)
        {
            SetList();
            SetListBox();
        }

        public void SetListBox()
        {   
            menuListBox.Items.Clear();
            
            for (int i = 0; i < list.Count; i++)
            {
                menuListBox.Items.Add(list[i].Name + " * " + list[i].cnt);
            }
            menuListBox.SelectionMode = SelectionMode.None;
            SetPgList();
        }

        private void Click(object sender, EventArgs e)
        {
            Order order = new Order(tableNumber);
            order.OnOrderComplete += Order_OnOrderComplete;
            order.Show();
        }

        private void SetList()
        {
            list.Clear();
            switch (tableNumber)
            {
                case "table1":
                    list = Program.table1Menu;
                    break;
                case "table2":
                    list = Program.table2Menu;
                    break;
                case "table3":
                    list = Program.table3Menu;
                    break;
                case "table4":
                    list = Program.table4Menu;
                    break;
                case "table5":
                    list = Program.table5Menu;
                    break;
                case "table6":
                    list = Program.table6Menu;
                    break;
            }
        }

        private void SetPgList()
        {
            switch (tableNumber)
            {
                case "table1":
                    Program.table1Menu = list;
                    break;
                case "table2":
                    Program.table2Menu = list;
                    break;
                case "table3":
                    Program.table3Menu = list;
                    break;
                case "table4":
                    Program.table4Menu = list;
                    break;
                case "table5":
                    Program.table5Menu = list;
                    break;
                case "table6":
                    Program.table6Menu = list;
                    break;
            }
        }
    }
}