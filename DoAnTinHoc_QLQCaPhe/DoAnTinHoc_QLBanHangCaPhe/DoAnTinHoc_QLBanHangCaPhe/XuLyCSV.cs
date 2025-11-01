using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DoAnTinHoc_QLBanHangCaPhe.Data;
using System.Globalization;
using System.Windows.Forms;

namespace DoAnTinHoc_QLBanHangCaPhe
{
    public static class XuLyCSV
    {
        public static DataTable DocFile()
        {
            DataTable dt = new DataTable();
            string filecsv = "Coffe_sales.csv";

            if (!File.Exists(filecsv))
            {
                return null;
            }
            List<string> tatCaCacDong = File.ReadAllLines(filecsv).ToList();
            //tra ve dt rong neu k co dong nao
            string[] lines = tatCaCacDong.ToArray();
            if (lines.Length == 0)
            {
                return dt;
            }
            //lay dong dau tien de cat chuoi ra khi gap dau phay
            string[] headers = lines[0].Split(',');

            //int soCotCanLay = Math.Min(10, headers.Length);
            int soCotCanLay = headers.Length;

            for (int i = 0; i < soCotCanLay; i++)
            {
                dt.Columns.Add(headers[i].Trim());
            }
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                string[] dataValues = values.Take(soCotCanLay).ToArray();
                if (dataValues.Length == dt.Columns.Count)
                {
                    dt.Rows.Add(dataValues);
                }
            }
            return dt;
        }
        public static DanhSachGiaoDich ReadCsvToLinkedList(string filePath)
        {
            DanhSachGiaoDich danhSach = new DanhSachGiaoDich();

            if (!File.Exists(filePath))
            {
                return null; 
            }

            try
            {
                var lines = File.ReadAllLines(filePath, Encoding.UTF8).Skip(1).ToList();

                foreach (var line in lines)
                {
                    var columns = line.Split(',');
                    if (columns.Length >= 10)
                    {
                        GiaoDichBanHang gd = new GiaoDichBanHang
                        {
                            GioTrongNgay = int.Parse(columns[0]),
                            LoaiThanhToan = columns[1],
                            SoTien = decimal.Parse(columns[2], CultureInfo.InvariantCulture),
                            TenMon = columns[3],
                            ThoiGianTrongNgay = columns[4],
                            NgayTrongTuan = columns[5],
                            TenThang = columns[6],
                            SapXepNgayTuan = int.Parse(columns[7]),
                            SapXepThang = int.Parse(columns[8]),
                            ThoiGianGiaoDich = DateTime.Parse(columns[9], CultureInfo.InvariantCulture)
                        };
                        danhSach.Add(gd);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc file CSV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return danhSach;
        }
        public static bool GhiFile(string gf)
        {
            string fileBaocao = "Baocao_Tuan1.txt";
            try
            {
                File.WriteAllText(fileBaocao, "\n Bao cao da duoc ghi thanh cong. Du lieu doc duoc: " + gf);
                return true;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
