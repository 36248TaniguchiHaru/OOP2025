using System.Net;
using System.Xml.Linq;
using System.Linq;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using System.Collections.Generic;




namespace RSSReader {
    public partial class Form1 : Form {

        private List<itemData> items;

        public Form1() {
            InitializeComponent();
            foreach (var item in dc) {
                if (!comboBox1.Items.Contains(item.Key))
                    comboBox1.Items.Add(item.Key);
            }
        }

        Dictionary<string, string> dc = new Dictionary<string, string>() {
            {"主要", "https://news.yahoo.co.jp/rss/topics/top-picks.xml"},
            {"国内", "https://news.yahoo.co.jp/rss/topics/domestic.xml"},
            {"国際", "https://news.yahoo.co.jp/rss/topics/world.xml"},
            {"経済", "https://news.yahoo.co.jp/rss/topics/business.xml"},
            {"エンタメ", "https://news.yahoo.co.jp/rss/topics/entertainment.xml"},
            {"スポーツ", "https://news.yahoo.co.jp/rss/topics/sports.xml"},
            {"IT", "https://news.yahoo.co.jp/rss/topics/it.xml"},
            {"科学", "https://news.yahoo.co.jp/rss/topics/science.xml"},
            {"地域", "https://news.yahoo.co.jp/rss/topics/local.xml"}
        };

        private async void btRssGet_Click(object sender, EventArgs e) {


            //URLをお気に入り登録するプログラム
            /*foreach (var item in dc) {
                if (comboBox1.Text == item.Key) {
                    wvRssview.CoreWebView2.Navigate(item.Value);
                    a = false;
                    break;
                }
            }*/

            foreach (var item in dc) {
                if (comboBox1.Text == item.Key) {
                    using (var hc = new HttpClient()) {
                        XDocument xdoc = XDocument.Parse(await hc.GetStringAsync(item.Value));


                        //var url = hc.OpenRead(tbUrl.Text);
                        //XDocument xdoc = XDocument.Load(url);//RSSの取得

                        //RSSを解析して必要な要素を取得
                        items = xdoc.Root.Descendants("item")
                            .Select(x =>
                                new itemData {
                                    Title = (string)x.Element("title"),
                                    Link = (string)x.Element("link"),
                                }).ToList();

                        //リストボックスへタイトルを表示
                        lbTitles.Items.Clear();
                        items.ForEach(item => lbTitles.Items.Add(item.Title));
                    }
                }
            }

            if (IsValidUrl(comboBox1.Text)) {
                using (var hc = new HttpClient()) {
                    XDocument xdoc = XDocument.Parse(await hc.GetStringAsync(comboBox1.Text));


                    //var url = hc.OpenRead(tbUrl.Text);
                    //XDocument xdoc = XDocument.Load(url);//RSSの取得

                    //RSSを解析して必要な要素を取得
                    items = xdoc.Root.Descendants("item")
                        .Select(x =>
                            new itemData {
                                Title = (string)x.Element("title"),
                                Link = (string)x.Element("link"),
                            }).ToList();

                    //リストボックスへタイトルを表示
                    lbTitles.Items.Clear();
                    items.ForEach(item => lbTitles.Items.Add(item.Title));


                }

            }

        }

        public static bool IsValidUrl(string url) {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }

        //タイトルを選択(クリック)したときに呼ばれるイベントハンドラ
        private void lbTitles_Click(object sender, EventArgs e) {
            var selectItem = lbTitles.SelectedItem;
            if (items is null) return;
            foreach (var item in items) {
                if (item.Title == selectItem) {
                    wvRssview.Source = new Uri(item.Link);
                }
            }
        }

        //戻るボタン
        private void button1_Click(object sender, EventArgs e) {
            if (wvRssview.CanGoBack == true) {
                wvRssview.GoBack();
            }
        }

        //進むボタン
        private void button2_Click(object sender, EventArgs e) {
            if (wvRssview.CanGoForward == true) {
                wvRssview.GoForward();
            }
        }

        //お気に入りボタン
        private void button3_Click(object sender, EventArgs e) {
            if (!comboBox1.Items.Contains(textBox1.Text)) {
                string selectedKey = comboBox1.Text;
                if (dc.TryGetValue(selectedKey, out string url)) {
                    comboBox1.Items.Add(textBox1.Text);
                    if (!dc.ContainsKey(textBox1.Text)) {
                        dc.Add(textBox1.Text, url);
                    }
                }
            }
        }

        //URLをお気に入り登録
        /*private void button3_Click(object sender, EventArgs e) {
            if (!comboBox1.Items.Contains(textBox1.Text)) {
                comboBox1.Items.Add(textBox1.Text);
                //未登録なら登録【登録済みなら何もしない】
                string strURL = wvRssview.Source.ToString();
                dc.Add(textBox1.Text, strURL);
            }
        }*/

        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            //GoFowardBt
        }

        private void button4_Click(object sender, EventArgs e) {
            if (comboBox1.Text != string.Empty)
                foreach (var item in dc) {
                    if (comboBox1.Text == item.Key) {
                        comboBox1.Items.Remove(item.Key);
                        dc.Remove(item.Key);
                    }
                }
        }

        private void lbTitles_DrawItem_1(object sender, DrawItemEventArgs e) {
            var idx = e.Index;                                                      //描画対象の行
            if (idx == -1) return;                                                  //範囲外なら何もしない
            var sts = e.State;                                                      //セルの状態
            var fnt = e.Font;                                                       //フォント
            var _bnd = e.Bounds;                                                    //描画範囲(オリジナル)
            var bnd = new RectangleF(_bnd.X, _bnd.Y, _bnd.Width, _bnd.Height);     //描画範囲(描画用)
            var txt = (string)lbTitles.Items[idx];                                  //リストボックス内の文字
            var bsh = new SolidBrush(lbTitles.ForeColor);                           //文字色
            var sel = (DrawItemState.Selected == (sts & DrawItemState.Selected));   //選択行か
            var odd = (idx % 2 == 1);                                               //奇数行か
            var fore = Brushes.WhiteSmoke;                                         //偶数行の背景色
            var bak = Brushes.AliceBlue;                                           //奇数行の背景色

            e.DrawBackground();                                                     //背景描画

            //奇数項目の背景色を変える（選択行は除く）
            if (odd && !sel) {
                e.Graphics.FillRectangle(bak, bnd);
            } else if (!odd && !sel) {
                e.Graphics.FillRectangle(fore, bnd);
            }

            //文字を描画
            e.Graphics.DrawString(txt, fnt, bsh, bnd);
        }
    }
}
