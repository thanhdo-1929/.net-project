using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Quanlydiemsv.DataAccess;

namespace Quanlydiemsv.Logic
{

    public class KetQua
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string MaLop { get; set; }
        public string MaMon { get; set; }
        public double DiemTB { get; set; }
        public double DiemThi { get; set; }
        public double DiemTongKet { get; set; }
        public string HocKi { get; set; }
        public string GhiChu { get; set; }

        public KetQua(string MaSV, string HoTen, string MaLop, string MaMon, double DiemTB, double DiemThi, double DiemTongKet, string HocKi, string GhiChu)
        {
            this.MaSV = MaSV;
            this.HoTen = HoTen;
            this.MaLop = MaLop;
            this.MaMon = MaMon;
            this.DiemTB = DiemTB;
            this.DiemThi = DiemThi;
            this.DiemTongKet = DiemTongKet;
            this.HocKi = HocKi;
            this.GhiChu = GhiChu;
        }
    }
    public class ListKetQua
    {
        public static List<KetQua> getAllKetQua()
        {
            List<KetQua> cats = new List<KetQua>();
            DataTable dt = KetQuaDAO.getAllKetQua();
            foreach (DataRow dr in dt.Rows)
            {
                cats.Add(new KetQua(
                    dr["MaSV"].ToString(),
                    dr["HoTen"].ToString(),
                    dr["MaLop"].ToString(),
                    dr["MaMon"].ToString(),
                    Convert.ToDouble(dr["DiemTB"]),
                    Convert.ToDouble(dr["DiemThi"]),
                    Convert.ToDouble(dr["DiemTongKet"]),
                    dr["HocKi"].ToString(),
                    dr["GhiChu"].ToString()
                ));
            }
            return cats;
        }

    }
}
