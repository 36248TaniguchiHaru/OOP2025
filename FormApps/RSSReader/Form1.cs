using System.Net;
using System.Xml.Linq;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;




namespace RSSReader {
    public partial class Form1 : Form {

        private List<itemData> items;

        public Form1() {
            InitializeComponent();
        }

        Dictionary<string, string> dc = new Dictionary<string, string>();

        private async void btRssGet_Click(object sender, EventArgs e) {
            var a = true;
            
            //URL�����C�ɓ���o�^����v���O����
            foreach (var item in dc) {
                if (comboBox1.Text == item.Key) {
                    wvRssview.CoreWebView2.Navigate(item.Value);
                    a = false;
                    break;
                }
            }

            /*foreach (var item in dc) {
                if (comboBox1.Text == item.Key) {
                    using (var hc = new HttpClient()) {
                        XDocument xdoc = XDocument.Parse(await hc.GetStringAsync(comboBox1.Text));
                        //RSS����͂��ĕK�v�ȗv�f���擾
                        items = xdoc.Root.Descendants("item")
                            .Select(x =>
                                new itemData {
                                    Title = (string)x.Element("title"),
                                    Link = (string)x.Element("link"),
                                }).ToList();
                        //���X�g�{�b�N�X�փ^�C�g����\��
                        lbTitles.Items.Clear();
                        items.ForEach(item => lbTitles.Items.Add(item.Title));
                    }
                    a = false;
                    break;
                }
            }*/
            if (a == true)
                using (var hc = new HttpClient()) {
                    XDocument xdoc = XDocument.Parse(await hc.GetStringAsync(comboBox1.Text));


                    //var url = hc.OpenRead(tbUrl.Text);
                    //XDocument xdoc = XDocument.Load(url);//RSS�̎擾

                    //RSS����͂��ĕK�v�ȗv�f���擾
                    items = xdoc.Root.Descendants("item")
                        .Select(x =>
                            new itemData {
                                Title = (string)x.Element("title"),
                                Link = (string)x.Element("link"),
                            }).ToList();

                    //���X�g�{�b�N�X�փ^�C�g����\��
                    lbTitles.Items.Clear();
                    items.ForEach(item => lbTitles.Items.Add(item.Title));


                }



        }

        //�^�C�g����I��(�N���b�N)�����Ƃ��ɌĂ΂��C�x���g�n���h��
        private void lbTitles_Click(object sender, EventArgs e) {
            var selectItem = lbTitles.SelectedItem;
            if (items is null) return;
            foreach (var item in items) {
                if (item.Title == selectItem) {
                    wvRssview.Source = new Uri(item.Link);
                }
            }
        }

        //�߂�{�^��
        private void button1_Click(object sender, EventArgs e) {
            if (wvRssview.CanGoBack == true) {
                wvRssview.GoBack();
            }
        }
        
        //�i�ރ{�^��
        private void button2_Click(object sender, EventArgs e) {
            if (wvRssview.CanGoForward == true) {
                wvRssview.GoForward();
            }
        }

        //���C�ɓ���{�^��
        /*private void button3_Click(object sender, EventArgs e) {
            if (!comboBox1.Items.Contains(textBox1.Text)) {
                comboBox1.Items.Add(textBox1.Text);
                //���o�^�Ȃ�o�^�y�o�^�ς݂Ȃ牽�����Ȃ��z
                string strURL = wvRssview.Source.ToString();
                dc.Add(textBox1.Text, strURL);
            }
        }*/
        
        //URL�����C�ɓ���o�^
        private void button3_Click(object sender, EventArgs e) {
            if (!comboBox1.Items.Contains(textBox1.Text)) {
                comboBox1.Items.Add(textBox1.Text);
                //���o�^�Ȃ�o�^�y�o�^�ς݂Ȃ牽�����Ȃ��z
                string strURL = wvRssview.Source.ToString();
                dc.Add(textBox1.Text, strURL);
            }
        }

        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            //GoFowardBt
        }


    }
}
