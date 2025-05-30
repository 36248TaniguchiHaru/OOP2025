using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var str1 = "JSON";
            var str2 = "ＪＳＯＮ";

            var cultureinfo = new CultureInfo("ja-jp");
            if (String.Compare(str1, str2, cultureinfo, CompareOptions.IgnoreWidth | CompareOptions.IgnoreKanaType) == 0) {
                Console.WriteLine("一致しています");
            }


        }
    }
}
