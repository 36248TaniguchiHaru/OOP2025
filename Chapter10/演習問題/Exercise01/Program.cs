using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

namespace Exercise01 {
    class Program {
        static void Main() {
            string filePath = @"C:\Users\infosys\source\repos\OOP2025\Chapter14\Sction03\Program.cs";

            //①
            /*using (StreamReader reader = new StreamReader(filePath)) {
                int count=0;
                string line;
                while ((line = reader.ReadLine()) != null) {
                    if (Regex.IsMatch(line,@"\sclass\s")) {
                        count++;  
                    }
                }
                Console.WriteLine($"{count}行");
            }*/

            //②
            /*string[] lines=File.ReadAllLines(filePath);
            int count = 0;
            foreach (var line in lines) {
                if(Regex.IsMatch(line, @"\sclass\s")){
                    count++;
                }
            }
            Console.WriteLine($"{count}行");*/

            //③
            IEnumerable<string> lines = File.ReadLines(filePath);
            int count = 0;
            foreach (string line in lines) {
                if (Regex.IsMatch(line, @"\sclass\s")) {
                    count++;
                }
            }
            Console.WriteLine($"{count}行");
        }
    }
}

