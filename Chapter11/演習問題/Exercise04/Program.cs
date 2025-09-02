using System.Text.RegularExpressions;

namespace Exercise04 {
    internal class Program {

        static void Main(string[] args) {

            var lines = File.ReadAllLines("sample.txt");

            //var pattern = @"\b[v|V]ersion\s*=\s*"v4.0"";
           
            
            var newlines = lines.Select(s=>Regex.Replace(s, @"\b([v|V]ersion)\s*=\s*""v4\.0""", "version=\"v5.0\""));
            


            File.WriteAllLines("sampleChange.txt", newlines);

            var text = File.ReadAllText("sampleChange.txt");
            Console.WriteLine(text);
            
        }
    }
}
