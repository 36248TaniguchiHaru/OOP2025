using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02{
    public class YearMonth {
        public int Year { get; init; }
        public int Month { get; init; }
        public YearMonth(int year, int month) {
            this.Year = year;
            this.Month = month;
        }
        public bool Is21Century => 2001 <= Year && Year <= 2100;
        public YearMonth AddOneMonth() {
            int newYear = Year;
            int newMonth = Month;
            if (newMonth == 12) {
                newYear += 1;
                newMonth = 1;
            } else {
                newMonth += 1;
            }
            return new YearMonth(newYear, newMonth);
        }
        public override string ToString() => $"{Year}年{Month}月";
        
        
       

    }
}

