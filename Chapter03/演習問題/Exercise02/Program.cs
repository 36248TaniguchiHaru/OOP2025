
using System.Runtime.InteropServices;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(cities);
            Console.WriteLine();

           

        }
        

        private static void Exercise2_1(List<string> cities) {
                Console.WriteLine("都市名を入力。空白にしたら終了");
            while (true) {
                var city = Console.ReadLine();
                if (String.IsNullOrEmpty(city)) 
                    break;
                var index = cities.FindIndex(s => s == city);
                Console.WriteLine(index);
            }
        }


        private static void Exercise2_2(List<string> cities) {
            var count = cities.Count(s => s.Contains ('o'));
                Console.WriteLine(count);
        }
        
        private static void Exercise2_3(List<string> cities) {
            var where = cities.Where(s => s.Contains('o')).ToArray();
            foreach (var name in where) {
                Console.WriteLine(name);
            }
           
        }

        private static void Exercise2_4(List<string> names) {
            var selected = names.Where(s => s.StartsWith('B'))
                                .Select(s=>s.Length);
            foreach(var name in selected) {
                Console.WriteLine(name);
            }
        }
    }
}
