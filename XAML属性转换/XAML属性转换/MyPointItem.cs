using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAML属性转换
{
    [TypeConverter(typeof(MyPointItemConverter))]
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

        internal static MyPointItem Parse(String data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return new MyPointItem();
            }

            String[] items = data.Split(',');
            if (items.Count() != 2)
            {
                throw new FormatException("Should have both latitude and longitude");
            }

            double lat, lon;
            try
            {
                lat = Convert.ToDouble(items[0]);
            }
            catch (Exception ex)
            {
                throw new FormatException("Latitude value cannot be converted", ex);
            }
            try
            {
                lon = Convert.ToDouble(items[1]);
            }
            catch(Exception ex)
            {
                throw new FormatException("Longitude value cannot be converted", ex);
            }

            return new MyPointItem() { Latitude = lat, Longitude = lon };
        }

        public override string ToString()
        {
            return String.Format("纬度：{0}，经度：{1}", this.Latitude, this.Longitude);
        }
    }
}
