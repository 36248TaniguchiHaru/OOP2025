namespace Exercise02 {
    internal class Program {
        private static object meter;

        static void Main(string[] args) {

            Console.WriteLine("１；ヤードからメートル");
            Console.WriteLine("２；メートルからヤード");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine("＞" + choice);

            Console.WriteLine("変換前の数値");

            if (choice == 1) {

                int yard = int.Parse(Console.ReadLine());
                double meter = YardConverter.ToMeter(yard);
                Console.WriteLine("変換前（ヤード）："+yard);
                Console.WriteLine($"{yard}yd = {meter:0.0000}m");
            
            }else if(choice == 2) {

                int meter = int.Parse(Console.ReadLine());
                double yard = YardConverter.ToYard(meter);
                Console.WriteLine("変換前（メートル）：" + meter);
                Console.WriteLine($"{meter}m = {yard:0.0000}yd");
          
            }
        }
    }
}