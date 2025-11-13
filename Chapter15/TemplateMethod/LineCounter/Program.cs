using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            string filePath = @"C:\Users\infosys\source\repos\OOP2025\Chapter14\Sction03\Program.cs";
            TextProcessor.Run<LineCounterProcessor>(filePath);
        }
    }
}
