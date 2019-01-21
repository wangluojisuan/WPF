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

namespace 让物体动起来
{
    /// <summary>
    /// CompositionTargetWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CompositionTargetWindow : Window
    {
        Rectangle rect;     // 创建一个方块
        double speed = 5;   // 设置移动速度
        Point moveTo;       // 设置移动目标
        public CompositionTargetWindow()
        {
            InitializeComponent();

            rect = new Rectangle();
            rect.Fill = new SolidColorBrush(Colors.Red);
            rect.Width = 50;
            rect.Height = 50;
            rect.RadiusX = 5;
            rect.RadiusY = 5;
            this.Carrier.Children.Add(rect);
            Canvas.SetLeft(rect, 0);
            Canvas.SetTop(rect, 0);

            // 注册界面刷新事件
            CompositionTarget.Rendering += new EventHandler(Timer_Tick);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Double rect_x = Canvas.GetLeft(rect);
            Double rect_y = Canvas.GetTop(rect);
            Canvas.SetLeft(rect, rect_x + (rect_x < moveTo.X ? speed : -speed));
            Canvas.SetTop(rect, rect_y + (rect_y < moveTo.Y ? speed : -speed));
        }

        private void Carrier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.moveTo = e.GetPosition(this.Carrier);
        }
    }
}
