using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SplashScreenInWpf05;
using System.Threading;

namespace SplashTestInForm
{
    public partial class Form1 : Form
    {
        public static Dictionary<string, object> Dic = new Dictionary<string, object>();
        public Form1()
        {
            InitializeComponent();

            Thread t = new Thread(() =>
            {
                SplashWindow sw = new SplashWindow();
                Dic["SplashWindow"] = sw;//储存
                sw.ShowDialog();//不能用Show
            });
            t.IsBackground = true;
            t.SetApartmentState(ApartmentState.STA);//设置单线程
            t.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
            this.Show();
            if (Form1.Dic.ContainsKey("SplashWindow"))
            {
                SplashWindow sw = Form1.Dic["SplashWindow"] as SplashWindow;
                sw.Dispatcher.Invoke((Action)(() => sw.Close()));//在sw的线程上关闭SplashWindow
            }
        }
    }
}
