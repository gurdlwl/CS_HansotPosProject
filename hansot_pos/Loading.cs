using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// 한솥메뉴 링크 : https://www.hsd.co.kr/menu/menu_list

namespace hansot_pos
{
    public partial class Loading : Form
    {
        //상수 선언부
        public const int min = 0;
        public const int value = 0;
        public const int step = 1;

        public int max;

        public Loading()
        {
            InitializeComponent();

            LoadingImage.Image = Image.FromFile("Resources/hansot_logo.png");

            InitProgressBar();
            LoadMenuImagePath();
        }

        //progressBar속성 설정
        private void InitProgressBar()
        {
            max = Program.menuList.Count();

            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Minimum = min;
            progressBar.Maximum = max;
            progressBar.Value = value;
            progressBar.Step = step;
        }   

        //ImagePath를 세팅하고 ProgressBarStep을 올려주는 함수
        private void LoadMenuImagePath()
        {
            foreach(MenuInfo menuInfo in Program.menuList)
            {
                //이걸 해도 실제 path와는 전혀 연관이 없음.
                menuInfo.SetImagePath(menuInfo.category, menuInfo.Name);
                progressBar.PerformStep();
            }
            //this.Close();
        }
    }
}