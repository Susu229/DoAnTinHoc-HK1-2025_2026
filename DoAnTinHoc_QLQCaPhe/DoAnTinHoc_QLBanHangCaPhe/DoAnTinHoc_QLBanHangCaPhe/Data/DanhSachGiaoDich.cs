using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc_QLBanHangCaPhe.Data
{
    public class DanhSachGiaoDich
    {
        public GiaoDichNode Head { get; set; }
        public DanhSachGiaoDich()
        {
            Head = null;
        }
        //chèn node mới đầu ds
        public void Insert(GiaoDichBanHang giaoDich)
        {
            GiaoDichNode newNode = new GiaoDichNode(giaoDich);
            newNode.Next = Head;
            Head = newNode;
        }
        public void Add(GiaoDichBanHang giaoDich)
        {
            GiaoDichNode newNode = new GiaoDichNode(giaoDich);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                GiaoDichNode current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;

            }
        }
        public bool DeleteHead()
        {
            if (Head == null)
            {
                return false;
            }
            Head = Head.Next;
            return true;
        }

        public bool DeleteByTenMon(string tenMonCanXoa)
        {
            GiaoDichNode pCurrent = Head;
            GiaoDichNode pPrev = null; 

            while (pCurrent != null && !pCurrent.Data.TenMon.Equals(tenMonCanXoa, StringComparison.OrdinalIgnoreCase))
            {
                pPrev = pCurrent;
                pCurrent = pCurrent.Next;
            }
            if (pCurrent == null) return false;
            if (pPrev == null)
            {
                Head = pCurrent.Next;
            }
            else
            {
                pPrev.Next = pCurrent.Next;
            }

            return true;
        }

        public List<GiaoDichBanHang> ToList()
        {
            List<GiaoDichBanHang> list = new List<GiaoDichBanHang>();
            GiaoDichNode current = Head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
            return list;
        }
        public List<GiaoDichBanHang> SearchByTitle(string keyword)
        {
            List<GiaoDichBanHang> results = new List<GiaoDichBanHang>();
            GiaoDichNode current = Head;
            while (current != null)
            {
                if (!string.IsNullOrEmpty(current.Data.TenMon) && current.Data.TenMon.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    results.Add(current.Data);
                }
                current = current.Next;
            }
            return results;
        }
        public int Count()
        {
            int count = 0;
            GiaoDichNode current = Head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
        public void Clear()
        {
            Head = null;
        }
        

    }
}
