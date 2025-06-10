using Exercise02;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var randamyear = new YearMonth[] { new YearMonth(2003, 12 ),
                                               new YearMonth(2004, 5),
                                               new YearMonth(2014,4),
                                               new YearMonth(2007,12),
                                               new YearMonth(2022,3)};

            Console.WriteLine("5.2.2");
            Exercise2(randamyear);

            Console.WriteLine("5.2.4");
            Exercise4(randamyear);

            Console.WriteLine("5.2.5");
            Exercise5(randamyear);
        }

        private static void Exercise2(YearMonth[] randamyear) {
            foreach(var item in randamyear) {
                Console.WriteLine(item.ToString());
            }
        }

        private static YearMonth? FindFirst21C(YearMonth[] randamyear) {
            var se=randamyear.FirstOrDefault(s => s.Year > 2000 && s.Year < 2100);
            if (se is not null) {
                return se;
            } else {
                return null;
            }
        }

        private static void Exercise4(YearMonth[] randamyear) {
            var se=FindFirst21C(randamyear);
            if(se is not null) {
                Console.WriteLine(se.ToString());
            } else {
                Console.WriteLine("21世紀のデータはありません");
            }
        }

        private static void Exercise5(YearMonth[] randamyear) {
            var nextYear = randamyear.Select(s => s.AddOneMonth())
                                     .OrderBy(s => s.Year)
                                     .ThenBy(s => s.Month);
            foreach (var ite in nextYear) {
                Console.WriteLine(ite);
            }
        }
    }
}

