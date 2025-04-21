
namespace DistanceConverter {
    internal class Program {
        static void Main(string[] args) {

            int stert = int.Parse(args[1]);
            int end = int.Parse(args[2]);

            if (args.Length >= 1 && args[0] == "-tom") {
                PrintFeetToMeterList(stert, end);
            } else {
                PrintMeterToFeetList(stert, end);
            }
        }

        private static void PrintFeetToMeterList(int stert, int end) {
            throw new NotImplementedException();
        }

        private static void PrintMeterToFeetList(int stert, int end) {
            throw new NotImplementedException();
        }

        static void PrintFeetToMeter(int stert, int end) {
                for (int feet = stert; feet <= end; feet++) {
                    double meter = FeetToMeter(feet);
                    Console.WriteLine($"{feet}ft={meter:0.0000}m");
                }

            }

            static void PrintMaterToFeetList(int stert, int end) {
                for (int meter = stert; meter <= end; meter++) {
                    double feet = MeterToFeet(meter);
                    Console.WriteLine($"{meter}m={feet:0.0000}ft");
                }
            }



            static double FeetToMeter(int feet) {
                return feet * 0.3048;
            }

            static double MeterToFeet(int meter) {
                return meter / 0.3048;
            }
        
    }
}
