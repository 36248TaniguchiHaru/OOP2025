using Microsoft.VisualBasic;
using System.Reflection;
using System.Threading.Tasks.Sources;

namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {
            var songs = new List<Song>();
            Console.WriteLine("＊＊＊＊＊曲の登録＊＊＊＊＊");
            // 無限ループ
            while (true) {
                Console.Write("曲名：");
                string title = Console.ReadLine();
                //endが入力されたら登録終了
                if (title.Equals("end")) break;
                Console.Write("アーティスト名：");
                string artistname = Console.ReadLine();
                Console.Write("演奏時間：");
                int length = int.Parse(Console.ReadLine());
                //songインスタンスを作成
                // Song song = new Song(title, artistname, length);
                Song song = new Song() {
                    Title = title,
                    ArtistName = artistname,
                    Length = length
                };
                songs.Add(song);
                Console.WriteLine();

            }

            printSongs(songs.ToArray());

        }


        //2.1.4
        private static void printSongs(Song[] songs) {
            /*      foreach (var song in songs) {
                      var minutes = song.Length / 60;
                      var seconds = song.Length % 60;
                      Console.WriteLine($"{song.Title}, {song.ArtistName}, { minutes}:{ seconds:00}");
                  }*/

            //TimeSpan構造体を使った場合

            foreach (var song in songs) {
                var timespan = TimeSpan.FromSeconds(song.Length);
                Console.WriteLine($"{song.Title}, {song.ArtistName}, {timespan.Minutes}:{timespan.Seconds:00}");
            }
            //または、以下でも可
            foreach (var song in songs) {
                Console.WriteLine(@"{0},{1}{2:m\:ss}",
                    song.Title, song.ArtistName, TimeSpan.FromSeconds(song.Length));
            }

            Console.WriteLine();


        }

    }
}
