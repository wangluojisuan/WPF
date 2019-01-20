﻿using System;
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
using System.Windows.Shapes;

namespace 让物体动起来
{
    /// <summary>
    /// StoryboardWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StoryboardWindow : Window
    {
        Rectangle rect = null;
        public StoryboardWindow()
        {
            InitializeComponent();

            // 创建一个方块
            rect = new Rectangle();
            rect.Fill = new SolidColorBrush(Colors.Red);
            rect.Width = 50;
            rect.Height = 50;
            rect.RadiusX = 5;
            rect.RadiusY = 5;
            Carrier.Children.Add(rect);
            Canvas.SetLeft(rect, 0);
            Canvas.SetTop(rect, 0);
        }

        private void Carrier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 创建移动动画
            Point p = e.GetPosition(this.Carrier);
            Storyboard storyboard = new Storyboard();
            // 创建X轴动画
            DoubleAnimation doubleAnimation = new DoubleAnimation(Canvas.GetLeft(rect), p.X, new Duration(TimeSpan.FromMilliseconds(500)));
            Storyboard.SetTarget(doubleAnimation, rect);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Left)"));
            storyboard.Children.Add(doubleAnimation);

            // 创建Y轴动画
            doubleAnimation = new DoubleAnimation(Canvas.GetTop(rect), p.Y, new Duration(TimeSpan.FromMilliseconds(500)));
            //doubleAnimation = new DoubleAnimation();
            //doubleAnimation.From = Double.IsNaN(Canvas.GetTop(rect)) ? 0 : Canvas.GetTop(rect);
            //doubleAnimation.To = p.Y;
            //doubleAnimation.Duration = TimeSpan.FromMilliseconds(500);
            Storyboard.SetTarget(doubleAnimation, rect);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(doubleAnimation);

            // 将动画动态加载进资源内
            if (!Resources.Contains("rectAnimation"))
            {
                Resources.Add("rectAnimation", storyboard);
            }

            // 动画播放
            storyboard.Begin();
        }
    }
}
