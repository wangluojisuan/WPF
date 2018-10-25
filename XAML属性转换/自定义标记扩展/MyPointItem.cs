using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义标记扩展
{
    class MyPointItem
    {
        public double Latitude
        {
            get;
            set;
        }

        public double Longitude
        {
            get;
            set;
        }

        public override string ToString()
        {
            return String.Format("纬度：{0}，经度：{1}", this.Latitude, this.Longitude);
        }
    }
}
