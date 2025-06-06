namespace Exercise01 {
    internal class Program {
        static void Main() {
            YearMonth ym = new YearMonth(2025, 6); 
            Console.WriteLine(ym.ToString());

            YearMonth nextMonth = ym.AddOneMonth();

            Console.WriteLine(nextMonth.ToString());

            Console.WriteLine(nextMonth.Is21Century);
        }
    }
}


    

