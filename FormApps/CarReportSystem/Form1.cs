using CarReportSyste;
using System.ComponentModel;
using static CarReportSyste.CarReport;

namespace CarReportSystem {
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
            var carReport = new CarReport {
                Date=dtpDate.Value,
                Author = cbAuthor.Text,
                Maker=GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report=tbReport.Text,
                Picture=pbPicture.Image,
            };
            listCarReports.Add(carReport);
        }

        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked) {
                return MakerGroup.トヨタ;
            }else if (rbNissan.Checked) {
                return MakerGroup.日産;
            }else if (rbHonda.Checked) {
                return MakerGroup.本田;
            }else if (rbSubaru.Checked) {
                return MakerGroup.スバル;
            } else if (rbInport.Checked) {
                return MakerGroup.輸入車;
            } else if (rbOther.Checked) {
                return MakerGroup.その他;
            } else {
                return MakerGroup.なし;
            }     
        }
    }
}
