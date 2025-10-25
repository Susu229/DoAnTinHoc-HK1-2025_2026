using System.Text;
using System.Data;


namespace DoAnTinHoc_QLBanHangCaPhe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtDuLieu = XuLyCSV.DocFile();
            if (dtDuLieu == null)
            {
                MessageBox.Show("Lỗi không tìm thấy file Coffe_sales.csv", "Lỗi file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtDuLieu.Rows.Count == 0 && dtDuLieu.Columns.Count == 0)
            {
                MessageBox.Show("File Coffe_sales.csv rỗng.", "Lỗi file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.dataGridView1.DataSource = dtDuLieu;
            MessageBox.Show("Đọc file thành công và hiển thị dữ liệu.", "Thành công!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}