﻿using System.Runtime.InteropServices.Marshalling;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            // 3.1.1
            Exercise1(numbers);
            Console.WriteLine("-----");

            // 3.1.2
            Exercise2(numbers);
            Console.WriteLine("-----");

            // 3.1.3
            Exercise3(numbers);
            Console.WriteLine("-----");

            // 3.1.4
            Exercise4(numbers);
        }

        private static void Exercise1(List<int> numbers) {
          
                var exist = numbers.Exists(s => s % 8 == 0 || s % 9 == 0);
            if (exist) {
                Console.WriteLine("存在しています");
            } else {
                Console.WriteLine("存在していません");
            }
                
           
           
           
        }

        private static void Exercise2(List<int> numbers) {

        }

        private static void Exercise3(List<int> numbers) {

        }

        private static void Exercise4(List<int> numbers) {

        }
    }
}
