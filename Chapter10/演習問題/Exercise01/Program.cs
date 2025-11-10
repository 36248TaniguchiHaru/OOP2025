using System;
using System.IO;
using static System.Console;
using System.Text.RegularExpressions;

namespace Exercise01 {
    class Program {
        static void Main() {
            string filePath = @"C:\Users\infosys\source\repos\OOP2025\Chapter10\演習問題\Exercise01\Load.cs";

            using (StreamReader reader = new StreamReader(filePath)) {
                int count=0;
                string line;
                while ((line = reader.ReadLine()) != null) {
                    if (Regex.IsMatch(line,@"\sclass\s")) {
                        count++;  
                    }
                }
                Console.WriteLine(count);
            }
        }
    }
}

