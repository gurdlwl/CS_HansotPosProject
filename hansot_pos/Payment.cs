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
        public Payment()
        {
            InitializeComponent();
        }

        private void Pay_Click(object sender, EventArgs e)
        {
            //ref. http://ojc.asia/bbs/board.php?bo_table=Cyber&wr_id=7312

            DialogResult result = MessageBox.Show("결제하시겠습니까?", "결제확인", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //결제 처리...
                

                MessageBox.Show("결제 완료");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("결제 취소");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //OrderMenuListBox에 Order.OrderMenuListView에서 받아온 값을 넣어주어야 함.

    }
}
