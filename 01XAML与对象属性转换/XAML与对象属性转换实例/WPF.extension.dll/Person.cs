using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.extension.dll
{
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
    }
}
