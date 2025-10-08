using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter{
    internal class MetricUnit:DistanceUnit{
        private static List<MetricUnit> units = new List<MetricUnit> {
            new MetricUnit{Name="mm",Confficient=1,},
            new MetricUnit{Name="cm",Confficient=10,},
            new MetricUnit{Name="m",Confficient=10*100,},
            new MetricUnit{Name="km",Confficient=10*100*1000,},
        };
        public static ICollection<MetricUnit> Units { get => units; }

        /// <summary>
        /// ヤード単位からメートル単位に変換します
        /// </summary>
        /// <proam name="unit">変換元の単位</proam>
        /// <proam name="value">変換する値</proam>
        /// <returns>変換した値</returns>
        public double FromImperialUnit(ImperialUnit unit, double value) {
            return (value * unit.Confficient) * 25.4 / Confficient;
        }
    }
}
