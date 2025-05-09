using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator{
   public class Sale{
        public string ShopName { get; set; } = String.Empty;
        public string ProductCategory { get; set; } = String.Empty;
        public int Amount { get; set; }
    }
}
