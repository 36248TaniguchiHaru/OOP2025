﻿
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
                "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
                "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);
        }

        private static void Exercise1(List<string> langs) {
            //foreach文
             foreach (var lang in langs) {
                if(lang.Contains('S'))
                 Console.WriteLine(lang);
             }
             //for文
             for(int i = 0; i < langs.Count; i++) {
                if (langs[i].Contains('S'))
                Console.WriteLine(langs[i]);
            }

            int index = 0;
            while (index<langs.Count) {
                if (langs[index].Contains('S'))
                Console.WriteLine(langs[index]);
                index++;

            }

        }

        private static void Exercise2(List<string> langs) {
            var language = langs.Where(s => s.Contains('S'));
            foreach (var name in language) {
                Console.WriteLine(name);
            }
        }

        private static void Exercise3(List<string> langs) {
            var lang = langs.Find(s => s.Length == 10) ?? "unknown";
            Console.WriteLine(lang == "unknown" ? "null":"");
        }

    }
}
