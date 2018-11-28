using System;
using System.Drawing;
using System.Windows.Forms;

namespace hansot_pos
{
    public partial class MenuListCtrl : UserControl
    {
        //public delegate void MenuClickHander(object sender, EventArgs args);
        public event EventHandler OnMenuClick;

        private MenuInfo menuInfo = new MenuInfo();

        public MenuListCtrl(MenuInfo menuList)
        {
            InitializeComponent();
            SetData(menuList);
        }

        private void SetData(MenuInfo menuList)
        {
            menuInfo = menuList;

            //이미지 Path 문법 찾아보기.
            MenuImage.Image = new Bitmap(ResizeImage(menuList.imagePath));
            lbMenuName.Text = menuList.Name;
            lbMenuPrice.Text = Convert.ToString(menuList.price)+" 원";
        }

        private Bitmap ResizeImage(string imagePath)
        {
            Bitmap originalImage = new Bitmap(imagePath);

            int width = originalImage.Width / 5;
            int height = originalImage.Height / 5;

            Size resize = new Size(width, height);
            Bitmap resizeImage = new Bitmap(originalImage, resize);

            return resizeImage;
        }

        private void MenuImage_Click(object sender, EventArgs e)
        {
            if (OnMenuClick != null)
            {
                OnMenuClick(this, null);
            }
        }

        public MenuInfo GetData()
        {
            return menuInfo;
        }
    }
}
