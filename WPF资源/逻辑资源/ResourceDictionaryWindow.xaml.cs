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

namespace 逻辑资源
{
    /// <summary>
    /// ResourceDictionaryWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ResourceDictionaryWindow : Window
    {
        public ResourceDictionaryWindow()
        {
            InitializeComponent();
        }

        private void btnChangeViewport_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = (ImageBrush)this.Resources["TileBrush"];
            brush.Viewport = new Rect(0, 0, 5, 5);
        }

        private void btnChangeBrush_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["TileBrush"] = new SolidColorBrush(Colors.LightBlue);
        }
    }
}
