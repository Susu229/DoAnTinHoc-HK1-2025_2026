using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc_QLBanHangCaPhe.Data
{
    public class GiaoDichNode
    {
        public GiaoDichBanHang Data { get; set; }
        public GiaoDichNode Next { get; set; }
        public GiaoDichNode(GiaoDichBanHang data)
        {
            this.Data = data;
            this.Next = null; 
        }
    }
}
