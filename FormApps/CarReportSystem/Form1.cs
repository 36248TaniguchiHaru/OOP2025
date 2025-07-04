using CarReportSyste;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Text;
using static CarReportSyste.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //ÉJÅ[ÉåÉ|Å[Égä«óùópÉäÉXÉg
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
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);
            InputItemsAllClear();
            setCbAuthor(cbAuthor.Text);
            setCbCarName(cbCarName.Text);
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
                return MakerGroup.ÉgÉàÉ^;
            } else if (rbNissan.Checked) {
                return MakerGroup.ì˙éY;
            } else if (rbHonda.Checked) {
                return MakerGroup.ÉzÉìÉ_;
            } else if (rbSubaru.Checked) {
                return MakerGroup.ÉXÉoÉã;
            } else if (rbInport.Checked) {
                return MakerGroup.óAì¸é‘;
            } else {
                return MakerGroup.ÇªÇÃëº;
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

                case MakerGroup.ÉgÉàÉ^:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.ì˙éY:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.ÉzÉìÉ_:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.ÉXÉoÉã:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.óAì¸é‘:
                    rbInport.Checked = true;
                    break;
                case MakerGroup.ÇªÇÃëº:
                    rbOther.Checked = true;
                    break;
            }
        }

        private void setCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author)) {
                //ñ¢ìoò^Ç»ÇÁìoò^Åyìoò^çœÇ›Ç»ÇÁâΩÇ‡ÇµÇ»Ç¢Åz
                cbAuthor.Items.Add(author);
            }

        }

        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName)) {
                //ñ¢ìoò^Ç»ÇÁìoò^Åyìoò^çœÇ›Ç»ÇÁâΩÇ‡ÇµÇ»Ç¢Åz
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
            if (dgvRecord.CurrentRow is null) return;
           
            int index = dgvRecord.CurrentRow.Index;
            listCarReports.RemoveAt(index);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
