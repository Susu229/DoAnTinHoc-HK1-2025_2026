using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

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
            string[]lines = File.ReadAllLines(filecsv);
            if(lines.Length == 0)
            {
                return dt;
            }
            string[] headers = lines[0].Split(',');
            foreach (string header in headers)
            {
                dt.Columns.Add(header.Trim());
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');

                if (values.Length == dt.Columns.Count)
                {
                    dt.Rows.Add(values);
                }
            }
            return dt;
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
