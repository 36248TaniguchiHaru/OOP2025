using System.Net;
using System.Xml.Linq;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RSSReader {
    public partial class Form1 : Form {

        private List<itemData> items;

        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {
            using (var hc = new HttpClient()) {
                XDocument xdoc = XDocument.Parse(await hc.GetStringAsync(tbUrl.Text));


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

        //タイトルを選択(クリック)したときに呼ばれるイベントハンドラ
        private void lbTitles_Click(object sender, EventArgs e) {
            //webView21.Source = new Uri("https://yahoo.co.jp/");
            var selectItem = lbTitles.SelectedItem;
            foreach (var item in items) {
                if (item.Title == selectItem) {
                    webView21.Source = new Uri(item.Link);
                }
            }
        }
    }
}
