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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _01清空
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        // 定义命令
        private RoutedCommand clearCmd = new RoutedCommand("Clear", typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();
            this.InitializeCommand();
        }

        // 初始化命令
        private void InitializeCommand()
        {
            // 命令源
            this.btn1.Command = this.clearCmd;  // 命令源指定命令
            this.btn1.CommandTarget = this.rtxt1;   // 命令源指定命令目标

            // 命令添加快捷键
            this.clearCmd.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Control));

            // 绑定命令、命令关联
            CommandBinding cb = new CommandBinding(this.clearCmd);
            cb.CanExecute += Cb_CanExecute;     // 状态同步
            cb.Executed += Cb_Executed;         // 命令响应

            this.CommandBindings.Add(cb);
        }

        private void Cb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.rtxt1.Clear();

            e.Handled = true;
        }

        private void Cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.rtxt1.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
            e.Handled = true;
        }
    }
}
