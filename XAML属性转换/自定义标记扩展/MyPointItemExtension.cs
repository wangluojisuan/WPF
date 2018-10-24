using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace 自定义标记扩展
{
    [MarkupExtensionReturnType(typeof(MyPointItem))]
    class PointItemExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new MyPointItem() { Longitude = this.Lon, Latitude = this.Lat };
        }

        public double Lon;
        public double Lat;
    }
}
