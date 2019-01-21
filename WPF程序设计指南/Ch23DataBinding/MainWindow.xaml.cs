using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ch23DataBinding
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Binding bind = new Binding();
            bind.Source = this.scroll;
            bind.Path = new PropertyPath(ScrollBar.ValueProperty);
            //lbl.SetBinding(Label.ContentProperty, bind);
            BindingOperations.SetBinding(lbl, Label.ContentProperty, bind);
        }
    }
}
