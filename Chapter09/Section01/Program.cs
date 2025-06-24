using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            /*var today = new DateTime(2025, 7, 12);
            var now = DateTime.Now;

            Console.WriteLine($"Today:{today.Month}");
            Console.WriteLine($"Now:{now}");*/

            //自分の生年月日は何曜日かをプログラムを書いて調べる

            Console.Write("西暦：");
            var year = int.Parse(Console.ReadLine());
            Console.Write("月：");
            var month = int.Parse(Console.ReadLine());
            Console.Write("日：");
            var day = int.Parse(Console.ReadLine());
            Console.Write("時間：");
            var hour = int.Parse(Console.ReadLine());
            Console.Write("分：");
            var minute = int.Parse(Console.ReadLine());
            Console.Write("秒：");
            var secibd = int.Parse(Console.ReadLine());
            var birthday = new DateTime(year, month, day,hour,minute,secibd);
            var date = birthday.ToString("yyyy年M月d日");
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var dayOfWeek = culture.DateTimeFormat.GetDayName(birthday.DayOfWeek);
            Console.WriteLine($"{date}は{dayOfWeek}です");

            //産まれてから〇日です

            var now = DateTime.Today.Date;
            Console.WriteLine($"生まれてから{(now - birthday).Days}日目です");

            //あなたは〇歳です



            Console.WriteLine($"あなたは{(now - birthday).Days / 365}歳です");

            //1月１日から何日目か
            var newyearday = new DateTime(now.Year, 1, 1);
            Console.WriteLine($"1月1日から{(now - newyearday).Days}日です");

            //うるう年の判定プログラムを作成する

            Console.WriteLine("西暦を入力してください");

            int years = int.Parse(Console.ReadLine());
            var IsLeapYear = DateTime.IsLeapYear(year);
            if (IsLeapYear) {
                Console.WriteLine($"{year}年はうるう年です");
            } else {
                Console.WriteLine($"{year}年はうるう年ではありません");
            }

            

            //キャリッジリターン
            while (true) {
                var nowtime = DateTime.Now - birthday;
                //産まれてから何秒
                Console.Write($"\r産まれてから{nowtime.TotalSeconds}秒");
            }
        }
    }
}
