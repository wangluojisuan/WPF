using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.converter.dll
{
    public class Student
    {
        public String ID
        {
            get;
            set;
        }

        public Person PersonalMessage
        {
            get;
            set;
        }

        public override string ToString()
        {
            return String.Format("ID：{0}，{1}", this.ID, this.PersonalMessage.ToString());
        }
    }
}
