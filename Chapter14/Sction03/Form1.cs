using System.Diagnostics;
using System.Threading.Tasks;

namespace Sction03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            ToolStripStatusLabel.Text = "";
            var elapsed = await DoLongTimeWorkAsync(4000);
            ToolStripStatusLabel.Text = $"{elapsed}ƒ~ƒŠ•b";
        }

        private async Task<long> DoLongTimeWorkAsync(int milliseconds) {
            var sw = Stopwatch.StartNew();
            await Task.Run(() => {
                System.Threading.Thread.Sleep(milliseconds);
            });
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
