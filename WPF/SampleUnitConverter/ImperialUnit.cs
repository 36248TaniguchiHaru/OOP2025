using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter{
    internal class ImperialUnit:DistanceUnit{
        private static List<ImperialUnit> units = new List<ImperialUnit> {
            new ImperialUnit{Name="in",Confficient=1,},
            new ImperialUnit{Name="ft",Confficient=12,},
            new ImperialUnit{Name="yd",Confficient=12*3,},
            new ImperialUnit{Name="ml",Confficient=12*3*1760,},
        };
        public static ICollection<ImperialUnit> Units { get => units; }

        /// <summary>
        /// メートル単位からヤード単位に変換します
        /// </summary>
        /// <proam name="unit">変換元の単位</proam>
        /// <proam name="value">変換する値</proam>
        /// <returns>変換した値</returns>
        public double FromMetricUnit(MetricUnit unit,double value) {
            return (value * unit.Confficient) / 25.4 / Confficient;
        }
    }
}
