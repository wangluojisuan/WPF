using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace 程序集资源
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Image img = null;
        public MainWindow()
        {
            InitializeComponent();

            img = new Image();

            //// 获取资源1
            //StreamResourceInfo reInfo = Application.GetResourceStream(new Uri("Images/3.jpg", UriKind.Relative));
            //BitmapImage bitmap = new BitmapImage();
            //bitmap.BeginInit();
            //bitmap.StreamSource = reInfo.Stream;
            //bitmap.EndInit();
            //img.Source = bitmap;

            //// 获取资源2
            //Assembly assembly = Assembly.GetAssembly(this.GetType());
            //String resourceName = assembly.GetName().Name + ".g";
            //ResourceManager reManager = new ResourceManager(resourceName, assembly);
            //BitmapImage bitmap = new BitmapImage();
            //ResourceSet reSet = reManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);
            //UnmanagedMemoryStream unMemStream = (UnmanagedMemoryStream)reSet.GetObject("Images/2.jpg", true);
            //bitmap.BeginInit();
            //bitmap.StreamSource = unMemStream;
            //bitmap.EndInit();
            //img.Source = bitmap;

            // 获取资源3
            img.Source = new BitmapImage(new Uri("Images/1.jpg", UriKind.Relative));

            //this.Carrier.Children.Add(img);
        }
    }
}
