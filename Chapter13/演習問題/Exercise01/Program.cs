
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var select = Library.Books.MaxBy(b => b.Price);
            Console.WriteLine(select);
            /*var selected = Library.Books
                .GroupBy(b => b.PublishedYear)
                .Select(group => group.MaxBy(b => b.Price))
                .OrderBy(b => b!.PublishedYear);

            foreach (var book in selected) {
                Console.WriteLine($"{book!.PublishedYear}年 {book!.Title} ({book!.Price})");
            }*/
            
        }

        private static void Exercise1_3() {
            for (int count = 2020; count <= 2023; count++) {
                var book = Library.Books.Count(s => s.PublishedYear == count);
                    Console.WriteLine($"{count}: {book}");
            }

        }

        private static void Exercise1_4() {
            var books = Library.Books
                .OrderByDescending(b => b!.Price)
                .OrderByDescending(b => b!.PublishedYear);
            foreach (var book in books) {
                Console.WriteLine($"{book!.PublishedYear}年 {book!.Price}円 {book!.Title}");
            }
        }

        private static void Exercise1_5() {
            var select = Library.Books.Where(b => b.PublishedYear == 2022);

        }

        private static void Exercise1_6() {
            
        }

        private static void Exercise1_7() {
            
        }

        private static void Exercise1_8() {
            
        }
    }
}
