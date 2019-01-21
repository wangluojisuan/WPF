using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace 让物体动起来
{
    /// <summary>
    /// BodyAnimationWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BodyAnimationWindow : Window
    {
        Image spirit = null;
        int count = 1;
        String spiritPath = String.Empty;
        public BodyAnimationWindow()
        {
            InitializeComponent();

            // 创建精灵
            spirit = new Image();
            spirit.Width = 100;
            spirit.Height = 100;
            this.Carrier.Children.Add(spirit);

            // 获取图片路径
            this.spiritPath = AppDomain.CurrentDomain.BaseDirectory + @"Images\Players\0\";

            // 添加动画
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(80);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            spirit.Source = new BitmapImage(new Uri(this.spiritPath + "1-" + count + ".png", UriKind.Absolute));
            count = (count >= 20 ? 0 : count + 1);
        }
    }
}
