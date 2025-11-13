using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {

            Console.Write("読み込むファイルのパスを入力してください: ");
            string filePath = $@"{Console.ReadLine()}";

            if (File.Exists(filePath)) {
                TextProcessor.Run<LineCounterProcessor>(filePath);
                
            } else {
                Console.WriteLine("ファイルが見つかりません");
            }
        }
    }
}
