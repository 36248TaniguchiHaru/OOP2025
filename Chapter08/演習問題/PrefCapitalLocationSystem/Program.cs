﻿namespace PrefCapitalLocationSystem {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();

        static void Main(string[] args) {
            String? pref, prefCaptalLocation;

            //入力処理
            Console.WriteLine("県庁所在地の登録【入力終了：Ctrl + 'Z'】");

            while (true) {
                //①都道府県の入力
                Console.Write("都道府県:");
                pref = Console.ReadLine();
                

                if (pref == null) break;    //無限ループを抜ける(Ctrl + 'Z')

                //県庁所在地の入力
                Console.Write("県庁所在地:");
                prefCaptalLocation = Console.ReadLine();
                

                
                //既に都道府県が登録されているか？
                //ヒント：ContainsKeyを使用して調べる


                //登録済みなら確認して上書き処理、上書きしない場合はもう一度都道府県の入力…①へ
                //ヒント：Console.WriteLine("上書きしますか？(Y/N)");

                //*　ここに入力　*******************//
                if (prefOfficeDict.ContainsKey(pref)) {
                    Console.WriteLine("上書きしますか？(Y/N)");
                    var anser = Console.ReadLine();
                    if (anser == "Y") {
                        //上書き
                        prefCaptalLocation = Console.ReadLine();
                    } else {
                        //戻すやつ
                        
                    }
                }



                //県庁所在地登録処理

                //*　ここに入力　*******************//
                if (prefCaptalLocation is not null)
                    prefOfficeDict[pref] = prefCaptalLocation;
                else
                    break;

                Console.WriteLine();//改行
            }

            Boolean endFlag = false;    //終了フラグ（無限ループを抜け出す用）
            while (!endFlag) {
                switch (menuDisp()) {
                    case "1":                        //一覧出力処理
                        allDisp();
                        break;


                    case "2"://検索処理
                        searchPrefCaptalLocation();
                        break;


                    case "9"://無限ループを抜ける

                        endFlag = true;
                        break;
                        
                }
                
            }
        }

        //メニュー表示
        private static string? menuDisp() {
            Console.WriteLine("\n**** メニュー ****");
            Console.WriteLine("1：一覧表示");
            Console.WriteLine("2：検索");
            Console.WriteLine("9：終了");
            Console.Write(">");
            var menuSelect = Console.ReadLine();
            return menuSelect;
                
        }


        //一覧表示処理
        private static void allDisp() {
            foreach (var item in prefOfficeDict) {
                Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です。");
            }
            //*　ここに入力　*******************//
        }

        //検索処理
        private static void searchPrefCaptalLocation() {
            Console.Write("都道府県:");
            String? searchPref = Console.ReadLine();
            foreach (var item in prefOfficeDict) {
                if (searchPref == item.Key) 
                Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です。");
            }
            
        }
    }
}
