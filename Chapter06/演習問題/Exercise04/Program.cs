
using static System.Net.Mime.MediaTypeNames;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var array = line.Split(';');

            Exercise04(line);

        }

            private static void Exercise04(string line) {
                var newline = line.Split('=', ';');
                for (int count = 0; count < newline.Length; count++) {
                    if (newline[count] == "Novelist" && newline[count + 1] is not null) {
                        Console.WriteLine("作家  :" + newline[count + 1]);
                    } else if (newline[count] == "BestWork" && newline[count + 1] is not null) {
                        Console.WriteLine("代表作:" + newline[count + 1]);
                    } else if (newline[count] == "Born" && newline[count + 1] is not null) {
                        Console.WriteLine("誕生年:" + newline[count + 1]);
                    }
                }

            }






        
    }
}
