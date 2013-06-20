using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace taoIP
{
    public partial class weatherdisplay : UserControl
    {
        
        public weatherdisplay()
        {
            InitializeComponent();
        }

        public void weatherinit(weatherinfo info)
        {
            try
            {
                this.txttime.Text = info.ptime;
                this.txtweather.Text = info.weather;
                this.txtcityname.Text = info.city;
                this.temp1.Text = info.temp1;
                this.temp2.Text = info.temp2;
                string d = Convert.ToInt32(info.img1.Split('.')[0].Replace("d", "")).ToString("00");
                string n = Convert.ToInt32(info.img2.Split('.')[0].Replace("n", "")).ToString("00");
                this.imgday.Image = Image.FromFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "weather\\" + d + ".png"));
                this.imgnight.Image = Image.FromFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "weather\\" + n + "_.png"));
            }
            catch
            {
                txtcityname.Text = "数据获取异常";
            }
            
        }

    }
}
