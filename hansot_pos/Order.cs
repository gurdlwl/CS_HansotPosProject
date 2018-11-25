using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using static hansot_pos.FoodType;

namespace hansot_pos
{
    public partial class Order : Form
    {
        public delegate void OrderCompleteHandler(object sender, EventArgs e);
        public event OrderCompleteHandler OnOrderComplete;

        //상수 선언부
        private const int interval = 1000;

        private string tableNumber = string.Empty;
        string[] menuArr = new string[3];

        private Timer timer;
        MenuListCtrl menuListCtrl;

        public Order(string tableNumber)
        {
            InitializeComponent();
            this.tableNumber = tableNumber; //넘어온 TableNumber를 이 클래스 내부 TableNumber에 넣어준다

            if (Program.list != null)
            {
                SetList();
                UpdateListView();
            }
        }

        public void Order_Load(object sender, EventArgs e)
        {
            this.nowDateTIme.Text = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            Timer_Set();
            AddTablePanel();
            
            this.tableNum.Text = tableNumber;
            totalPrice.Text = "총 금액 : 0";

            SetOrderMenuListView();
        }

        private void SetOrderMenuListView()
        {
            //ref. http://cocomo.tistory.com/484 
            //ref. https://docs.microsoft.com/ko-kr/dotnet/api/system.windows.forms.columnheader.textalign?redirectedfrom=MSDN&view=netframework-4.7.2#System_Windows_Forms_ColumnHeader_TextAlign

            OrderMenuListView.Columns.Add("메뉴이름", 380);
            OrderMenuListView.Columns.Add("수량", 110, HorizontalAlignment.Center);
            OrderMenuListView.Columns.Add("가격", 150, HorizontalAlignment.Center);

            OrderMenuListView.View = View.Details;
            OrderMenuListView.FullRowSelect = true;
            OrderMenuListView.GridLines = true;
            OrderMenuListView.EndUpdate();
        }

        public void AddTablePanel()
        {
            int column = 0, row = 0;
            int menuListCnt = Program.menuList.Count;

            for(int index = 0; index < menuListCnt; index++)
            {
                menuListCtrl = new MenuListCtrl(Program.menuList[index]);
                MenuListTablePanel.Controls.Add(menuListCtrl, column++, row);
                menuListCtrl.OnMenuClick += MenuListCtrl_OnMenuClick;

                if (column % 2 == 0)
                {
                    row++;
                    column = 0;
                }
            }
        }

        public void AddTablePanel(foodType category)
        {
            int column = 0, row = 0;
            int menuListCnt = Program.menuList.Count;

            for (int index = 0; index < menuListCnt; index++)
            {
                if (Program.menuList[index].category == category)
                {
                    menuListCtrl = new MenuListCtrl(Program.menuList[index]); ;
                    MenuListTablePanel.Controls.Add(menuListCtrl, column++, row);
                    menuListCtrl.OnMenuClick += MenuListCtrl_OnMenuClick;
                    if (column % 2 == 0)
                    {
                        row++;
                        column = 0;
                    }
                }
            }
        }

        private void MenuListCtrl_OnMenuClick(object sender, EventArgs e)
        {
            MenuListCtrl menuCtrl = sender as MenuListCtrl;
            if (menuCtrl == null)
                return;

            MenuInfo info = menuCtrl.GetData();
            
            AddListView(info);

            SetTotalPrice();
            SelectedImage.Image = new Bitmap(info.imagePath);
        }

        private void AddListView(MenuInfo info)
        {
            int cnt = 0;

            for (int index = 0; index < OrderMenuListView.Items.Count; index++)
            {
                if (info.Name == OrderMenuListView.Items[index].SubItems[0].Text)
                {
                    int count = int.Parse(OrderMenuListView.Items[index].SubItems[1].Text) + 1;
                    int price = int.Parse(OrderMenuListView.Items[index].SubItems[2].Text);

                    OrderMenuListView.Items[index].SubItems[1].Text = count.ToString();
                    OrderMenuListView.Items[index].SubItems[2].Text = (info.price * count).ToString();

                    return;
                }
            }

            cnt = info.cnt + 1;

            menuArr[0] = info.Name;
            menuArr[1] = cnt.ToString();
            menuArr[2] = info.price.ToString();

            ListViewItem lvi = new ListViewItem(menuArr);
            OrderMenuListView.Items.Add(lvi);
        }

        public void UpdateListView()
        {
            for(int index = 0; index < Program.list.Count; index++)
            {
                menuArr[0] = Program.list[index].Name;
                menuArr[1] = Program.list[index].cnt.ToString();
                menuArr[2] = Program.list[index].price.ToString();

                ListViewItem lvi = new ListViewItem(menuArr);
                OrderMenuListView.Items.Add(lvi);
            }
        }

        private void SetList()
        {
            switch (tableNumber)
            {
                case "table1":
                    Program.list = Program.table1Menu;
                    break;
                case "table2":
                    Program.list = Program.table2Menu;
                    break;
                case "table3":
                    Program.list = Program.table3Menu;
                    break;
                case "table4":
                    Program.list = Program.table4Menu;
                    break;
                case "table5":
                    Program.list = Program.table5Menu;
                    break;
                case "table6":
                    Program.list = Program.table6Menu;
                    break;
            }
        }

        private void SetPgList()
        {
            switch (tableNumber)
            {
                case "table1":
                    Program.table1Menu = Program.list;
                    break;
                case "table2":
                    Program.table2Menu = Program.list;
                    break;
                case "table3":
                    Program.table3Menu = Program.list;
                    break;
                case "table4":
                    Program.table4Menu = Program.list;
                    break;
                case "table5":
                    Program.table5Menu = Program.list;
                    break;
                case "table6":
                    Program.table6Menu = Program.list;
                    break;
            }
        }

        private void SetTotalPrice()
        {
            int total = 0;

            foreach(ListViewItem item in OrderMenuListView.Items)
            {
                total += int.Parse(item.SubItems[2].Text);
            }

            totalPrice.Text = "총 금액 : " + total.ToString();
        }

        private void Timer_Set()
        {
            timer = new Timer
            {
                Interval = interval
            };
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.nowDateTIme.Text = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        }
        
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PaymentBtn_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Show();
        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < OrderMenuListView.Items.Count; index++)
            {
                MenuInfo menu = new MenuInfo();
                menu.Name = OrderMenuListView.Items[index].SubItems[0].Text;
                menu.cnt = int.Parse(OrderMenuListView.Items[index].SubItems[1].Text);
                menu.price = int.Parse(OrderMenuListView.Items[index].SubItems[2].Text);
               
                Program.list.Add(menu);
            }

            if(OnOrderComplete != null)
            {
                OnOrderComplete(this, e);
                MessageBox.Show("주문 완료");
            }

            SetPgList();
            this.Close();
        }

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            if (OrderMenuListView.SelectedItems.Count == 0)
                return;

            ListViewItem lvi = OrderMenuListView.SelectedItems[0];

            foreach (ListViewItem item in OrderMenuListView.Items)
            {
                if(item.SubItems[0].Text == lvi.Text)
                {
                    int count = int.Parse(item.SubItems[1].Text);
                    int price = int.Parse(item.SubItems[2].Text);

                    int unitPrice = price / count;

                    count += 1;

                    item.SubItems[1].Text = count.ToString();
                    item.SubItems[2].Text = (unitPrice * count).ToString();

                    SetTotalPrice();
                }
            }
        }

        private void MinusBtn_Click(object sender, EventArgs e)
        {
            if (OrderMenuListView.SelectedItems.Count == 0)
                return;

            ListViewItem lvi = OrderMenuListView.SelectedItems[0];
            
            foreach (ListViewItem item in OrderMenuListView.Items)
            {
                if (item.SubItems[0].Text == lvi.Text)
                {
                    int count = int.Parse(item.SubItems[1].Text);
                    int price = int.Parse(item.SubItems[2].Text);

                    int unitPrice = price / count;

                    count -= 1;

                    if(count == 0)
                    {
                        OrderMenuListView.Items.Remove(item);
                    }

                    item.SubItems[1].Text = count.ToString();
                    item.SubItems[2].Text = (unitPrice * count).ToString();

                    SetTotalPrice();
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (OrderMenuListView.SelectedItems.Count == 0)
                return;

            ListViewItem lvi = OrderMenuListView.SelectedItems[0];

            foreach (ListViewItem item in OrderMenuListView.Items)
            {
                if (item.SubItems[0].Text == lvi.Text)
                {
                    item.SubItems[1].Text = "0";
                    item.SubItems[2].Text = "0";
                    OrderMenuListView.Items.Remove(item);

                    SetTotalPrice();
                }
            }
        }

        private void AllCancelBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in OrderMenuListView.Items)
            {
                item.SubItems[1].Text = "0";
                item.SubItems[2].Text = "0";
                OrderMenuListView.Items.Remove(item);

                SetTotalPrice();
            }
        }

        private void AllViewBtn_Click(object sender, EventArgs e)
        {
            TablePanelClear();
            AddTablePanel();
        }

        private void PremiumGomeiViewBtn_Click(object sender, EventArgs e)
        {
            TablePanelClear();
            AddTablePanel(foodType.primeumGomei);
        }

        private void SqaureViewBtn_Click(object sender, EventArgs e)
        {
            TablePanelClear();
            AddTablePanel(foodType.square);
        }

        private void BowlViewBtn_Click(object sender, EventArgs e)
        {
            TablePanelClear();
            AddTablePanel(foodType.bowl);
        }

        private void SideViewBtn_Click(object sender, EventArgs e)
        {
            TablePanelClear();
            AddTablePanel(foodType.side);
        }

        private void DrinkViewBtn_Click(object sender, EventArgs e)
        {
            TablePanelClear();
            AddTablePanel(foodType.drink);
        }

        private void TablePanelClear()
        {
            MenuListTablePanel.Controls.Clear();
            MenuListTablePanel.RowStyles.Clear();
        }

        private string barcodeString = string.Empty;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            this.ActiveControl = null;
            if (msg.Msg == 0x100)
            {
                string log = string.Format("ProcessCmdKey KeyData: {0}", keyData);
                if (keyData == Keys.Return)
                {
                    MenuInfo food = GetSelectedFoodByBarcode(barcodeString);
                    if (food != null)
                    {
                        AddListView(food);
                    }
                    barcodeString = string.Empty;
                }
                else
                {
                    barcodeString += char.ConvertFromUtf32((int)keyData);
                }

                Debug.WriteLine(log);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private MenuInfo GetSelectedFoodByBarcode(string barcodeString)
        {
            foreach(MenuInfo list in Program.menuList)
            {
                if (list.barcodeString == barcodeString)
                    return list;
            }
            return null;
        }
    }
}