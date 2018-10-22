using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConverterTest
{
    [TypeConverter(typeof(StringToHumanTypeConverter))]
    class Human
    {
        public String Name
        {
            get;
            set;
        }
        public Human Child
        {
            get;
            set;
        }
    }
}
