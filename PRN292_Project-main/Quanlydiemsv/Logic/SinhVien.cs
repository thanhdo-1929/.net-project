using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Quanlydiemsv.DataAccess;

namespace Quanlydiemsv.Logic
{
    public class SinhVien
    {
        public string MaSv { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string MaLop { get; set; }

        public SinhVien(string MaSv, string HoTen, string NgaySinh, string GioiTinh, string DiaChi, string MaLop)
        {
            this.MaSv = MaSv;
            this.HoTen = HoTen;
            this.NgaySinh = NgaySinh;
            this.GioiTinh = GioiTinh;
            this.DiaChi = DiaChi;
            this.MaLop = MaLop;

        }
    }

    public class ListSinhVien
    {
        public static List<SinhVien> getAllSinhVien()
        {
            List<SinhVien> cats = new List<SinhVien>();
            DataTable dt = SinhVienDAO.getAllSinhVien();
            foreach (DataRow dr in dt.Rows)
            {
                cats.Add(new SinhVien(
                    dr["MaSv"].ToString(),
                    dr["HoTen"].ToString(),
                    dr["NgaySinh"].ToString(),
                    dr["GioiTinh"].ToString(),
                    dr["DiaChi"].ToString(),
                    dr["MaLop"].ToString()
                ));
            }
            return cats;
        }

    }
}
