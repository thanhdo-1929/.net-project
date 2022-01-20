using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quanlydiemsv.Logic
{
    class CompareNameSV : IComparer<SinhVien>
    {
        public int Compare(SinhVien x, SinhVien y)
        {
            return x.MaSv.CompareTo(y.MaSv);
        }
    }

    class CompareNameGV : IComparer<GiangVien>
    {
        public int Compare(GiangVien x, GiangVien y)
        {
            return x.MaGV.CompareTo(y.MaGV);
        }
    }
}
