using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace hansot_pos
{
    public partial class TableUserCtrl : UserControl
    {
        public string tableNumber = string.Empty;
        ListSet listSet = new ListSet();

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
            this.lbTableNumber.Text = this.tableNumber;
            this.tableNumber = num;
        }

        public void SetListBox()
        {
            menuListBox.Items.Clear();

            for (int i = 0; i < Program.tempList.Count; i++)
            {
                menuListBox.Items.Add(Program.tempList[i].Name + " * " + Program.tempList[i].cnt);
            }
            menuListBox.SelectionMode = SelectionMode.None;
        }

        private void Clicked(object sender, EventArgs e)
        {
            Order order = new Order(this.tableNumber);
            order.OnOrderComplete += Order_OnOrderComplete; //주문 완료 델리게이트
            order.setListBox += Order_setListBox;
            order.Show();
        }

        private void Order_setListBox()
        {
            SetListBox();
        }

        private void Order_OnOrderComplete(object sender, EventArgs e)
        {
            listSet.SetList(this.tableNumber);
            SetListBox();
        }
    }
}