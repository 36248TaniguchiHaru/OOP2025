using System.Text.RegularExpressions;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var books = Books.GetBooks();

            //①本の平均金額を表示
            Console.WriteLine(books.Average(b=>b.Price));

            //②本のページ合計を表示
            Console.WriteLine(books.Sum(b => b.Pages));

            //③金額の安い書籍名と金額を表示
            var book =books.Where(s => s.Price == books.Min(b=>b.Price));
            foreach (var bo in book) {
                Console.WriteLine(bo.Title + ":" + bo.Price);
            }


            //④ページが多い書籍名とページ数を表示
            var index = books.Where(s => s.Pages == books.Max(b => b.Pages));
            foreach (var ind in index) {
                Console.WriteLine(ind.Title + ":" + ind.Pages);
            }



            //⑤タイトルに「物語」が含まれている書籍名をすべて表示
            var ma = books.Where(s => s.Title.Contains("物語"));
            foreach (var e in ma) {
                Console.WriteLine(e.Title);
                }
            }
        }
    }

