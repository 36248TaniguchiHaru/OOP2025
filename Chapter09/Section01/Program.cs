using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            /*var today = new DateTime(2025, 7, 12);
            var now = DateTime.Now;

            Console.WriteLine($"Today:{today.Month}");
            Console.WriteLine($"Now:{now}");*/

            //自分の生年月日は何曜日かをプログラムを書いて調べる

            var birthday = new DateTime(2006, 3, 26);
            var date = birthday.ToString("yyyy年M月d日");
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var dayOfWeek = culture.DateTimeFormat.GetDayName(birthday.DayOfWeek);
            Console.WriteLine($"{date}は{dayOfWeek}です");

            //生まれてから〇日です

            var now = DateTime.Today.Date;
            Console.WriteLine($"生まれてから{(now-birthday).Days}日目です");

            //うるう年の判定プログラムを作成する

            Console.WriteLine("西暦を入力してください");
            var year = Console.ReadLine();
            var IsLeapYear = DateTime.IsLeapYear(int.Parse(year));
            if(IsLeapYear) {
                Console.WriteLine($"{year}年はうるう年です");
            } else {
                Console.WriteLine($"{year}年はうるう年ではありません");
            }
        }
    }
}
