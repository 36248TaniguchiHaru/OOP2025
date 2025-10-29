
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
        }

        private static void Exercise1_3() {
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
            var category = Library.Books.Where(s => s.CategoryId
            == Library.Categories.Where(s => s.Name == "Development").Select(s => s.Id).First());
            var years = Library.Books.OrderBy(s => s.PublishedYear).Select(s => s.PublishedYear).Distinct();
            foreach (var year in years) {
                Console.WriteLine($"# {year}");
                foreach (var select in category) {
                    if (select.PublishedYear == year) {
                        Console.WriteLine($"   {select.Title}");
                    }
                }
            }
            
        }

        private static void Exercise1_8() {
            var groups = Library.Categories
                .GroupJoin(Library.Books,
                c => c.Id,
                b => b.CategoryId,
                (c, books) => new {
                    Category = c.Name,
                    Count = books.Count(),
                });
            foreach (var book in groups) {
                if (book.Count >= 4) {
                    Console.WriteLine($"{book.Category}");
                }
            }
        }
    }
}

