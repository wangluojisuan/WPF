using QX.Game.PathFinder;
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
    /// AStartWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AStartWindow : Window
    {
        Rectangle rect = default(Rectangle);
        IPathFinder pathFinder = null;
        Byte[,] matrix = new Byte[1024, 1024];
        int gridSize = 20;
        Point start = default(Point);
        Point end = default(Point);
        public AStartWindow()
        {
            InitializeComponent();

            this.ResetMatrix();
        }

        private void ResetMatrix()
        {
            for(int y = 0; y < this.matrix.GetUpperBound(1); y++)
            {
                for(int x = 0; x < this.matrix.GetUpperBound(0); x++)
                {
                    this.matrix[x, y] = 1;
                }
            }

            // 构建障碍物
            for(int i = 0; i < 18; i++)
            {
                this.matrix[i, 12] = 0;
                rect = new Rectangle();
                rect.Fill = new SolidColorBrush(Colors.Red);
                rect.Width = this.gridSize;
                rect.Height = this.gridSize;
                this.Carrier.Children.Add(rect);
                Canvas.SetLeft(rect, i * gridSize);
                Canvas.SetTop(rect, 12 * gridSize);
            }

            for(int i = 12; i < 17; i++)
            {
                this.matrix[17, i] = 0;
                rect = new Rectangle();
                rect.Fill = new SolidColorBrush(Colors.Red);
                rect.Width = this.gridSize;
                rect.Height = this.gridSize;
                this.Carrier.Children.Add(rect);
                Canvas.SetLeft(rect, 17 * gridSize);
                Canvas.SetTop(rect, i * gridSize);
            }

            for (int i = 3; i < 18; i++)
            {
                this.matrix[i, 16] = 0;
                rect = new Rectangle();
                rect.Fill = new SolidColorBrush(Colors.Red);
                rect.Width = this.gridSize;
                rect.Height = this.gridSize;
                this.Carrier.Children.Add(rect);
                Canvas.SetLeft(rect, i * gridSize);
                Canvas.SetTop(rect, 16 * gridSize);
            }

            this.start = new Point(1, 1);
        }

        private void Carrier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this.Carrier);
            int x = (int)p.X / this.gridSize;
            int y = (int)p.Y / this.gridSize;
            this.end = new Point(x, y);

            this.pathFinder = new PathFinderFast(this.matrix);
            this.pathFinder.Formula = HeuristicFormula.Manhattan;
            this.pathFinder.SearchLimit = 2000;

            System.Drawing.Point pStart = new System.Drawing.Point((int)this.start.X, (int)this.start.Y);
            System.Drawing.Point pEnd = new System.Drawing.Point((int)this.end.X, (int)this.end.Y);
            List<PathFinderNode> path = this.pathFinder.FindPath(pStart, pEnd);

            if(path == null)
            {
                MessageBox.Show("路径不存在");
            }else
            {
                String output = String.Empty;
                for(int i = path.Count - 1; i >= 0; i--)
                {
                    output = String.Format(output + "{0}" + path[i].X.ToString() + "{1}" + path[i].Y.ToString() + "{2}", "(", ",", ")");
                    rect = new Rectangle();
                    rect.Fill = new SolidColorBrush(Colors.Green);
                    rect.Width = this.gridSize;
                    rect.Height = this.gridSize;
                    this.Carrier.Children.Add(rect);
                    Canvas.SetLeft(rect, path[i].X * this.gridSize);
                    Canvas.SetTop(rect, path[i].Y * this.gridSize);
                }
                MessageBox.Show("路径坐标分别是：" + output);
            }
        }
    }
}
