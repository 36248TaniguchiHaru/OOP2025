namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("１；インチからメートル");
            Console.WriteLine("２；メートルからインチ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("はじめ");
            int start = int.Parse(Console.ReadLine());
            Console.WriteLine("おわり");
            int end = int.Parse(Console.ReadLine());

            Console.WriteLine("＞" + choice);
            Console.WriteLine("はじめ;" + start);
            Console.WriteLine("おわり;" + end);

            // インチからメートルへの対応表を出力

            if (choice == 1) {
                for (int inch = start; inch <= end; inch++) {
                    double meter = InchConverter.ToMeter(inch);
                    Console.WriteLine($"{inch}inch = {meter:0.0000}m");
                }
            }else if(choice == 2) {

                // メートルからインチへの対応表を出力

                for (int meter = start; meter <= end; meter++) {
                    double inch = InchConverter.ToInch(meter);
                    Console.WriteLine($"{meter}m = {inch:0.0000}inch");
                }
            }
        }
    }
}