using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Reflection;
using System.Xml.Linq;

namespace ColorChecker{
    public class MyColor{
        public Color Color { get; set; }
        public string Name { get; set; }  
        public override string ToString() {
            return Name;
        }
    }
}



