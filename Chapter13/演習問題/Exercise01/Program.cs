
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
            /*for (int count = 2020; count <= 2023; count++) {
                var book = Library.Books.Count(s => s.PublishedYear == count);
                    Console.WriteLine($"{count}: {book}");
            }*/
            var select = Library.Books.GroupBy(s => s.PublishedYear);
            foreach (var item in select) {
                Console.WriteLine($"{item.Key}: {item.Count()}");
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
            var select = Library.Books.Where(b => b.PublishedYear == 2022)
                .Select(s => s.CategoryId).Distinct();
            foreach (var item in select) {
                var category = Library.Categories.Where(s => s.Id == item);
                foreach (var items in category) {
                    Console.WriteLine(items.Name);
                }
            }
        }

        private static void Exercise1_6() {
            var categories = Library.Categories.Select(s => s.Id);
            foreach (var category in categories) {
                var selected = Library.Categories.Where(s => s.Id == category).Select(s => s.Name);
                foreach (var select in selected) {
                    Console.WriteLine($"# {select}");
                }
                foreach (var books in Library.Books) {
                    if (category == books.CategoryId) {
                        Console.WriteLine($"   {books.Title}");
                    }
                }
            }
        }

        private static void Exercise1_7() {
            var select = Library.Books.Where(s => s.CategoryId
            == Library.Categories.Where(s => s.Name == "Development").Select(s => s.Id).First());
            var year = Library.Books.OrderBy(s => s.PublishedYear).Select(s => s.PublishedYear).Distinct();
            foreach (var item in year) {
                Console.WriteLine($"# {item}");
                foreach (var category in select) {
                    if (category.PublishedYear == item) {
                        Console.WriteLine($"   {category.Title}");
                    }
                }
            }
        }

        private static void Exercise1_8() {

        }
    }
}
