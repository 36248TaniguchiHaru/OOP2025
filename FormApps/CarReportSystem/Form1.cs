using CarReportSyste;
using System.ComponentModel;
using static CarReportSyste.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //�J�[���|�[�g�Ǘ��p���X�g
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
                return MakerGroup.�g���^;
            }else if (rbNissan.Checked) {
                return MakerGroup.���Y;
            }else if (rbHonda.Checked) {
                return MakerGroup.�{�c;
            }else if (rbSubaru.Checked) {
                return MakerGroup.�X�o��;
            } else if (rbInport.Checked) {
                return MakerGroup.�A����;
            } else if (rbOther.Checked) {
                return MakerGroup.���̑�;
            } else {
                return MakerGroup.�Ȃ�;
            }     
        }
    }
}
