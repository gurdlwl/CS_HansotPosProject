using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hansot_pos
{
    public partial class Payment : Form
    {
        public delegate void ParentClose();
        public event ParentClose parentClose;

        string tableNumber = string.Empty;

        public Payment(string tablenumber)
        {
            InitializeComponent();

            this.tableNumber = tablenumber;

            SetListbox();
        }

        private bool CheckRadioBtn()
        {
            if(CashRadioBtn.Checked == true)
            {

                return true;
            }
            if(CardRadioBtn.Checked == true)
            {
                Program.
                return true;
            }

            return false;
        }

        private void PayBtn_Click(object sender, EventArgs e)
        {
           if (CheckRadioBtn() == true)
            {
                DialogResult result = MessageBox.Show("결제하시겠습니까?", "결제확인", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Program.statList.AddRange(Program.tempList);

                    MessageBox.Show("결제 완료");
                    parentClose();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("결제 취소");
                }
            }
            else
            {
                MessageBox.Show("결제 방법을 선택해 주세요.");
            }
        }

        private void SetListbox()
        {
            for (int index = 0; index < Program.tempList.Count; index++)
            {
                OrderedMenuListBox.Items.Add(Program.tempList[index].Name + " * " + Program.tempList[index].cnt);
            }
            OrderedMenuListBox.SelectionMode = SelectionMode.None;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
