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
    public partial class Loading : Form
    {
        //상수 선언부
        public const int min = 0;
        public const int value = 0;
        public const int step = 15;
        public const int max = 100;
        private const int interval = 500;

        private Timer timer;
        Main main = new Main();

        public Loading()
        {
            InitializeComponent();

            logoImage.Image = Image.FromFile("Resources/hansot_logo.png");
            SetTimer();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            InitProgressBar();
            timer.Start();
        }

        //progressBar속성 설정
        private void InitProgressBar()
        {
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Minimum = min;
            progressBar.Maximum = max;
            progressBar.Step = step;
            progressBar.Value = value;
        }

        private void SetTimer()
        {
            timer = new Timer
            {
                Interval = interval
            };
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value == progressBar.Maximum)
            {
                timer.Stop();
                this.Close();
            }
            progressBar.PerformStep();
        }

        ////ImagePath를 세팅하고 ProgressBarStep을 올려주는 함수
        //private void LoadMenuImagePath()
        //{
        //    foreach (MenuInfo menuInfo in Program.menuList)
        //    {
        //        //이걸 해도 실제 path와는 전혀 연관이 없음.
        //        menuInfo.SetImagePath(menuInfo.category, menuInfo.Name);
        //        progressBar.PerformStep();
        //    }
        //}
    }
}
