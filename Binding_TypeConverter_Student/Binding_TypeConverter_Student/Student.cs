using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding_TypeConverter_Student
{
    [TypeConverter(typeof(StringToStudentTypeConverter))]
    class Student
    {
        public int Id
        {
            get;
            set;
        }

        public Person PersonalMessage
        {
            get;
            set;
        }
    }

    public class StringToStudentTypeConverter:TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if(value is String)
            {
                Student p = new Student();
                p.PersonalMessage.Name = value as String;
                return p;
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            //if(sourceType == typeof(String))
            //{
            //    return true;
            //}
            //return base.CanConvertFrom(context, sourceType);
            return true;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            //return base.CanConvertTo(context, destinationType);
            return true;
        }
    }
}
