using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc_QLBanHangCaPhe.Data
{
    public class GiaoDichNode
    {
        //dulieuluunode
        //data la gdichbanhang
        public GiaoDichBanHang Data { get; set; }
        //trodennodetieptheo-  previous
        public GiaoDichNode Next { get; set; }
        //hàm khởi tạo node
        public GiaoDichNode(GiaoDichBanHang data)
        {
            this.Data = data;
            this.Next = null; 
        }
    }
}
