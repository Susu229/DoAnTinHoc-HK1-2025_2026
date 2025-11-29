using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Data;
using System.Threading;
using System.Linq;
using Newtonsoft.Json;
using DoAnTinHoc_QLBanHangCaPhe.Data;

namespace DoAnTinHoc_QLBanHangCaPhe
{

    public partial class Form1 : Form
    {
        //private List<Coffee> DSGiaoDich;
        private DataTable table;
        private DanhSachGiaoDich danhSachGiaoDich;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //DataTable dtDuLieu = XuLyCSV.DocFile();
            //if (dtDuLieu == null)
            //{
            //    MessageBox.Show("Lỗi không tìm thấy file Coffe_sales.csv", "Lỗi file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (dtDuLieu.Rows.Count == 0 && dtDuLieu.Columns.Count == 0)
            //{
            //    MessageBox.Show("File Coffe_sales.csv rỗng.", "Lỗi file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //this.dataGridView1.DataSource = dtDuLieu;
            //MessageBox.Show("Đọc file thành công và hiển thị dữ liệu.", "Thành công!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (danhSachGiaoDich == null || danhSachGiaoDich.Count() == 0)
            {
                MessageBox.Show("Dữ liệu chưa được tải hoặc file CSV rỗng. Kiểm tra lại đường dẫn file.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dtDuLieu = ConvertLinkedListToDataTable(danhSachGiaoDich);
            this.table = dtDuLieu;

            this.dataGridView1.DataSource = this.table;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            MessageBox.Show($"Đã hiển thị giao dịch.", "Thành công!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DataTable ConvertLinkedListToDataTable(DanhSachGiaoDich list)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Giờ", typeof(int));
            dt.Columns.Add("Thanh Toán", typeof(string));
            dt.Columns.Add("Số Tiền", typeof(decimal));
            dt.Columns.Add("Tên Món", typeof(string));
            dt.Columns.Add("Thời Gian", typeof(string));
            dt.Columns.Add("Ngày Trong Tuần", typeof(string));
            dt.Columns.Add("Tên Tháng", typeof(string));
            dt.Columns.Add("SX Ngày T", typeof(int));
            dt.Columns.Add("SX Tháng", typeof(int));
            dt.Columns.Add("Thời Gian GD", typeof(DateTime));

            GiaoDichNode current = list.Head;
            while (current != null)
            {
                dt.Rows.Add(
                    current.Data.GioTrongNgay,
                    current.Data.LoaiThanhToan,
                    current.Data.SoTien,
                    current.Data.TenMon,
                    current.Data.ThoiGianTrongNgay,
                    current.Data.NgayTrongTuan,
                    current.Data.TenThang,
                    current.Data.SapXepNgayTuan,
                    current.Data.SapXepThang,
                    current.Data.ThoiGianGiaoDich
                );
                current = current.Next;
            }
            return dt;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = "Coffe_sales.csv";
            danhSachGiaoDich = XuLyCSV.ReadCsvToLinkedList(filePath);
            if (danhSachGiaoDich != null && danhSachGiaoDich.Count() > 0)
            {
                MessageBox.Show($"Đã tải thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tải được dữ liệu hoặc file CSV rỗng. Kiểm tra file 'Coffee_sales.csv'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //    if (table == null || table.Rows.Count == 0)
            //    {
            //        MessageBox.Show("Chưa có dữ liệu! Vui lòng nhấn nút Tải/Xử Lý CSV trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    DataTable top10Table = table.Clone();
            //    int maxRows = Math.Min(10, table.Rows.Count);
            //    for (int i = 0; i < maxRows; i++)
            //    {
            //        top10Table.ImportRow(table.Rows[i]);
            //    }

            //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //    dataGridView1.DataSource = top10Table;

            //    MessageBox.Show($"Đã hiển thị {top10Table.Rows.Count} dòng dữ liệu đầu tiên.", "Thành công!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            if (dataGridView1.DataSource == null || dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng trong bảng để hiển thị danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable currentDt = dataGridView1.DataSource as DataTable;
            if (currentDt == null)
            {
                MessageBox.Show("Không thể lấy dữ liệu từ bảng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable selectedDt = currentDt.Clone();

            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
            {
                DataRowView drv = selectedRow.DataBoundItem as DataRowView;
                if (drv != null)
                {
                    selectedDt.ImportRow(drv.Row);
                }
            }

            Form displayForm = new Form();
            displayForm.Text = $"Danh Sách {selectedDt.Rows.Count} Giao Dịch Đã Chọn";
            displayForm.Size = new Size(800, 400);

            DataGridView newGrid = new DataGridView();
            newGrid.Dock = DockStyle.Fill;
            newGrid.DataSource = selectedDt;
            newGrid.ReadOnly = true;

            displayForm.Controls.Add(newGrid);
            displayForm.ShowDialog();
        }
        private void RefreshDataGridView()
        {
            DataTable dtDuLieuMoi = ConvertLinkedListToDataTable(danhSachGiaoDich);
            this.table = dtDuLieuMoi;

            this.dataGridView1.DataSource = this.table;
            this.dataGridView1.Refresh();
        }
        private void btnXoaTheoTen_Click(object sender, EventArgs e)
        {
            string tenMonCanXoa = txtTenMonCanXoa.Text.Trim();
            if (string.IsNullOrEmpty(tenMonCanXoa))
            {
                MessageBox.Show("Vui lòng nhập Tên Món cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (danhSachGiaoDich.DeleteByTenMon(tenMonCanXoa))
            {
                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show($"Không tìm thấy món '{tenMonCanXoa}' để xóa.", "Lỗi Xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //
        }
    }
}