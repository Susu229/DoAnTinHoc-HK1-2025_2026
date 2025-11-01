using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc_QLBanHangCaPhe.Data
{
    public class GiaoDichBanHang
    {
        public int GioTrongNgay { get; set; }
        public string LoaiThanhToan { get; set; }
        public decimal SoTien { get; set; }
        public string TenMon { get; set; }
        public string ThoiGianTrongNgay { get; set; }
        public string NgayTrongTuan { get; set; }
        public string TenThang { get; set; }
        public int SapXepNgayTuan { get; set; }
        public int SapXepThang { get; set; }
        public DateTime ThoiGianGiaoDich { get; set; }

    }
}
