
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);

        }

        private static void Exercise1(string text) {
            var countDict = new Dictionary<char, int>();
            foreach (var ch in text.ToUpper()) {
                if ('A' <= ch && ch <= 'Z') {
                    if (countDict.ContainsKey(ch)) {
                        countDict[ch]++;
                    } else {
                        countDict[ch] = 1;
                    }
                }
            }
            foreach (var (key, value) in countDict.OrderBy(s => s.Key)) {
                Console.WriteLine($"{key}:{value}");
            }

        }


        /*for(var ch='A'; 'A' <= ch && ch <= 'Z'; ch++) {
            var count = text.ToUpper().Count(s=>s==ch);
            Console.WriteLine("'" + ch + "':" + count);
        }*/



        private static void Exercise2(string text) {
            var countDict = new SortedDictionary<char, int>();
            foreach (var ch in text.ToUpper()) {
                if ('A' <= ch && ch <= 'Z') {
                    if (countDict.ContainsKey(ch)) {
                        countDict[ch]++;
                    } else {
                        countDict[ch] = 1;
                    }
                }
                

            }
            foreach (var (key, value) in countDict) {
                Console.WriteLine($"{key}:{value}");
            }
        }
        

    }
}
