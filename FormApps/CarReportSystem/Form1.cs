using CarReportSyste;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Text;
using System.Runtime.Serialization.Formatters.Binary;
using static CarReportSyste.CarReport;

namespace CarReportSystem {
    [Serializable]
    public partial class Form1 : Form {
        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvRecord.DataSource = listCarReports;
        }

        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void btRecordAdd_Click(object sender, EventArgs e) {

            if (cbAuthor.Text == String.Empty || cbCarName.Text == String.Empty) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
            } else {
                var carReport = new CarReport {
                    Date = dtpDate.Value,
                    Author = cbAuthor.Text,
                    Maker = GetRadioButtonMaker(),
                    CarName = cbCarName.Text,
                    Report = tbReport.Text,
                    Picture = pbPicture.Image,
                };
                tsslbMessage.Text = "";
                listCarReports.Add(carReport);
                InputItemsAllClear();
                setCbAuthor(cbAuthor.Text);
                setCbCarName(cbCarName.Text);
            }
        }
        private void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }

        private MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked) {
                return MakerGroup.トヨタ;
            } else if (rbNissan.Checked) {
                return MakerGroup.日産;
            } else if (rbHonda.Checked) {
                return MakerGroup.ホンダ;
            } else if (rbSubaru.Checked) {
                return MakerGroup.スバル;
            } else if (rbInport.Checked) {
                return MakerGroup.輸入車;
            } else {
                return MakerGroup.その他;
            }
        }

        private void dgvRecord_Click(object sender, EventArgs e) {
            dtpDate.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Author"].Value;
            setRadioButtonMaker((MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;

        }

        private void setRadioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {

                case MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.輸入車:
                    rbInport.Checked = true;
                    break;
                case MakerGroup.その他:
                    rbOther.Checked = true;
                    break;
            }
        }

        private void setCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author)) {
                //未登録なら登録【登録済みなら何もしない】
                cbAuthor.Items.Add(author);
            }

        }

        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName)) {
                //未登録なら登録【登録済みなら何もしない】
                cbAuthor.Items.Add(carName);
            }
        }

        private void btNewRecord_Click(object sender, EventArgs e) {
            InputItemsAllClear();
        }

        private void btRecordModify_Click(object sender, EventArgs e) {
            listCarReports[dgvRecord.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvRecord.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvRecord.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvRecord.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvRecord.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvRecord.CurrentRow.Index].Picture = pbPicture.Image;
            dgvRecord.Refresh();
        }

        private void btRecordDelete_Click(object sender, EventArgs e) {
            if (dgvRecord is null) return;
            int index = dgvRecord.CurrentRow.Index;
            listCarReports.RemoveAt(index);
        }

        private void Form1_Load(object sender, EventArgs e) {
            InputItemsAllClear();
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;


        }

        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void tsmiAbout_Click(object sender, EventArgs e) {
            fmVersion fmversion = new fmVersion();
            fmversion.Show();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ColorDialog.ShowDialog() == DialogResult.OK) {
                BackColor = ColorDialog.Color;
            }
        }

        //ファイルオープン処理
        private void reportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(
                        ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;

                        //コンボボックス登録
                        foreach (var report in listCarReports) { 
                        setCbAuthor(report.Author);
                        setCbCarName(report.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "ファイル形式が違います";
                }
            }
        }
        


        //ファイルセーブ処理
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011

                    using (FileStream fs = File.Open(
                                    sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル書き出しエラー";
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }
    }
}
