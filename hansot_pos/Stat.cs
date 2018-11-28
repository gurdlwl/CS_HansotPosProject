using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hansot_pos
{
    public partial class Stat : Form
    {
        public Stat()
        {
            InitializeComponent();
            InitCategoryComboBoxData();
            InitMenuComboBoxData();
        }

        private void InitCategoryComboBoxData()
        {
            for (int index = 0; index < Program.menuList.Count; index++)
            {
                if(!(categoryComboBox.Items.Contains(Program.menuList[index].category)))
                categoryComboBox.Items.Add(Program.menuList[index].category);
            }
        }

        private void InitMenuComboBoxData()
        {
            for ( int index = 0; index < Program.menuList.Count; index++)
            {
                menuComboBox.Items.Add(Program.menuList[index].Name);
            }
        }

        private void categoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategory = categoryComboBox.SelectedIndex;
            Object selectedItem = categoryComboBox.SelectedItem;

            if (selectedCategory > -1)
            {
                String txt = selectedItem.ToString();

                lbCgPrice.Text = SetCgTotalPrice(txt) + " 원";
                lbCgSales.Text = SetCgTotalSalse(txt) + " 개";
            }
        }

        private void menuCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedMenu = menuComboBox.SelectedIndex;
            Object selectedItem = menuComboBox.SelectedItem;

            if (selectedMenu > -1)
            {
                String txt = selectedItem.ToString();

                lbMnPrice.Text = SetMnTotalPrice(txt) + " 원";
                lbMnSales.Text = SetMnTotalSalse(txt) + " 개";
            }
        }

        private string SetCgTotalPrice(string category)
        {
            int totalPrice = 0;

            for(int index = 0; index < Program.statList.Count; index++)
            {
                if(Program.statList[index].category.ToString() == category)
                {
                    totalPrice += Program.statList[index].price;
                }
            }

            return totalPrice.ToString();
        }

        private string SetCgTotalSalse(string category)
        {
            int totalCount = 0;

            for (int index = 0; index < Program.statList.Count; index++)
            {
                if (Program.statList[index].category.ToString() == category)
                {
                    totalCount += Program.statList[index].cnt;
                }
            }

            return totalCount.ToString();
        }

        private string SetMnTotalPrice(string Menu)
        {
            int totalPrice = 0;

            for (int index = 0; index < Program.statList.Count; index++)
            {
                if (Program.statList[index].Name == Menu)
                {
                    totalPrice += Program.statList[index].price;
                }
            }

            return totalPrice.ToString();
        }

        private string SetMnTotalSalse(string Menu)
        {
            int totalCount = 0;

            for (int index = 0; index < Program.statList.Count; index++)
            {
                if (Program.statList[index].Name == Menu)
                {
                    totalCount += Program.statList[index].cnt;
                }
            }

            return totalCount.ToString();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
