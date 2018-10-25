using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAML属性转换
{
    class MyPointItemConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if(sourceType == typeof(String))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if(destinationType == typeof(MyPointItem))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is String)
            {
                try
                {
                    return MyPointItem.Parse(value as String);
                }
                catch (Exception ex)
                {
                    throw new Exception(String.Format("Can not convert '{0}' ({1}) because {2}", value, value.GetType(), ex.Message), ex);
                }
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if(destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }

            MyPointItem gpoint = value as MyPointItem;
            if(gpoint != null)
            {
                if(this.CanConvertTo(context, destinationType))
                {
                    return gpoint.ToString();
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
