using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter{
    internal class MainWindowViewModel :ViewModel{

        //フィールド
        private double metricValue;
        private double imperialValue;

        //プロパティ
        public double MetricValue {
            get => metricValue;
            set {
                this.metricValue = value;
                this.OnPropertyChanged();
            }
        }

        public double ImperialValue {
            get => imperialValue;
            set {
                this.imperialValue = value;
                this.OnPropertyChanged();
            }
        }


        
    }
}
