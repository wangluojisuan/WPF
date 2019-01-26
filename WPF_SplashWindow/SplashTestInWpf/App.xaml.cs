using SplashScreenInWpf03;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SplashTestInWpf
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static Dictionary<string, object> Dic = new Dictionary<string, object>();
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Thread t = new Thread(() =>
            {
                SplashWindow sw = new SplashWindow();
                Dic["SplashWindow"] = sw;//储存
                sw.ShowDialog();//不能用Show
            });
            t.IsBackground = true;
            t.SetApartmentState(ApartmentState.STA);//设置单线程
            t.Start();

            MainWindow mainWindow = new MainWindow();
            Thread.Sleep(5000);

            if (App.Dic.ContainsKey("SplashWindow"))
            {
                SplashWindow sw = App.Dic["SplashWindow"] as SplashWindow;
                sw.Dispatcher.Invoke((Action)(() => sw.Close()));//在sw的线程上关闭SplashWindow
            }

            mainWindow.Focus();
            mainWindow.Show();            
        }
    }
}
