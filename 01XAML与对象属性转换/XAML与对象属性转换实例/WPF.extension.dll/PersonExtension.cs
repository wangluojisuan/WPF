using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WPF.extension.dll
{
    [MarkupExtensionReturnType(typeof(Person))]
    public class PersonExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new Person() { Name = this.Name, Age = this.Age};
        }

        public PersonExtension() { }

        public PersonExtension(String name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

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
    }
}
