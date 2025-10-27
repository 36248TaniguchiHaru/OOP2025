namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var groups = Library.Books
                .GroupBy(b => b.PublishedYear)
                .OrderByDescending(g => g.Key);
            foreach (var group in groups) {
                Console.WriteLine($"{group.Key}年");
                foreach(var book in group) {
                    Console.WriteLine($"   {book}");
                }
            }
            /*var price = Library.Books
                .Where(b => b.CategoryId == 1)
                .Max(b => b.Price);
            Console.Write(price);

            Console.WriteLine();

            var book = Library.Books
                .Where(b => b.PublishedYear >= 2021)
                .MinBy(b => b.Price);
            Console.WriteLine(book);

            Console.WriteLine();

            var average = Library.Books.Average(x => x.Price);
            var aboves = Library.Books
                .Where(b => b.Price > average);
            foreach(var book1 in aboves){
                Console.WriteLine(book1);
            }*/

        }
    }
}
