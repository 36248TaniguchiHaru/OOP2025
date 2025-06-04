using System.Diagnostics.Metrics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise03 {
        internal class Program {
            static void Main(string[] args) {
                var text = "Jackdaws love my big sphinx of quartz";

                Console.WriteLine("6.3.1");
                Exercise1(text);

                Console.WriteLine("6.3.2");
                Exercise2(text);

                Console.WriteLine("6.3.3");
                Exercise3(text);

                Console.WriteLine("6.3.4");
                Exercise4(text);

                Console.WriteLine("6.3.5");
                Exercise5(text);

                Console.WriteLine("6.3.99");
                Exercise6(text);


            }

        private static void Exercise6(string text) {
            for (var num = 0; (char)('a'+num)<='z'; num++) { 
            var number=(char)('a' + num);
                Console.WriteLine(number+":"+text.Count(c => char.ToLower(c) == number));
          }
        }

        private static void Exercise1(string text) {
                var count = text.Count(s => s == ' ');
                Console.WriteLine(count);
            }

            private static void Exercise2(string text) {
                var newtext = text.Replace("big", "small");
                Console.WriteLine(newtext);
            }

            private static void Exercise3(string text) {
            var word = text.Split(' ');
            var words = new StringBuilder();
            foreach (var item in word) {
                words = words.Append(item+' ');
            }
            var wor = words.Remove(words.Length-1,1);
            Console.WriteLine(wor+".");

            /*var word = text.Split(' ');
            var item = " ";
            var words = String.Join(item, word);
            Console.WriteLine(words+".");

            var array = text.Split(' ');
            var sb = new StringBuilder(array[0]);
            foreach(var word in array.Skip(1){
                sb.Append(" ");
                sb.Append(word);
            }
            Console.WriteLine(sb + ".");
            */
        }


            private static void Exercise4(string text) {
                var words = text.Split(' ');
                var count = 0;
                foreach (var item in words)
                   count++;
                Console.WriteLine(count);
            //----------------------------------------------------------------
            var counta = text.Split(' ').Length;
            Console.WriteLine("単語数:{0}", count);
            }

            private static void Exercise5(string text) {
            var words = text.Split(' ').Where(s=>s.Length<=4);
            foreach (var item in words) {
                Console.WriteLine(item);
            }
            //----------------------------------------------------------------
            var word = text.Split(' ').Where(s => s.Length <= 4);
            foreach (var worrd in word) {
                Console.WriteLine(worrd);
            }
            }
        }
    }

