using System.Text;
using System.Threading.Tasks;

namespace Exercise01_WinForm {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            var btnLoad = new Button {
                Text = "ファイルを開く",
                Dock = DockStyle.Top
            };
            btnLoad.Click += BtnLoad_Click;

            var txtContent = new TextBox {
                Name = "txtContent",
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                Dock = DockStyle.Fill
            };

            Controls.Add(txtContent);
            Controls.Add(btnLoad);
        }

        private async void BtnLoad_Click(object sender, EventArgs e) {
            using (var ofd = new OpenFileDialog()) {
                ofd.Filter = "テキストファイル (*.txt)|*.txt|すべてのファイル (*.*)|*.*";
                ofd.Title = "読み込むファイルを選択してください";

                if (ofd.ShowDialog() == DialogResult.OK) {
                    using (var reader = new StreamReader(ofd.FileName)) {
                        string content = await reader.ReadToEndAsync();
                        var txtBox = Controls["txtContent"] as TextBox;
                        if (txtBox != null) {
                            txtBox.Text = content;
                            await Task.Delay(10);
                        }
                    }
                }
            }
        }
    }
}
