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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 让物体动起来
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStoryboardWindow_Click(object sender, RoutedEventArgs e)
        {
            StoryboardWindow storyWindow = new StoryboardWindow();
            storyWindow.Show();
        }

        private void btnCompositionTargetWindow_Click(object sender, RoutedEventArgs e)
        {
            CompositionTargetWindow window = new CompositionTargetWindow();
            window.Show();
        }

        private void btnDispatcherTimerWindow_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimerWindow window = new DispatcherTimerWindow();
            window.Show();
        }

        private void btnBodyAnimationWindow_Click(object sender, RoutedEventArgs e)
        {
            BodyAnimationWindow window = new BodyAnimationWindow();
            window.Show();
        }

        private void btnAStartWindow_Click(object sender, RoutedEventArgs e)
        {
            AStartWindow window = new AStartWindow();
            window.Show();
        }
    }
}
