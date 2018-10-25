using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace WPF.Controls
{
    [MarkupExtensionReturnType(typeof(Thickness))]
    public class MyThicknessExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new Thickness(this.Left,this.Top, this.Right,this.Bottom);
        }

        //public MyThicknessExtension()
        //{
        //    // 留空
        //}

        public double Bottom { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
        public double Top { get; set; }
    }
}
