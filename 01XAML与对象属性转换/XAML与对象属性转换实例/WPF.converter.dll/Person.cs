using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.converter.dll
{
    [TypeConverter(typeof(PersonConverter))]
    public class Person
    {
        public String Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public override string ToString()
        {
            return String.Format("姓名：{0}，年龄：{1}", this.Name, this.Age);
        }

        public static Person Parse(String value)
        {
            if(String.IsNullOrEmpty(value))
            {
                return new Person() { Name = "", Age = -1 };
            }

            String[] items = value.Split(',');
            String name = items[0];
            int age = int.Parse(items[1]);

            return new Person() { Name = name, Age = age };
        }
    }
}
