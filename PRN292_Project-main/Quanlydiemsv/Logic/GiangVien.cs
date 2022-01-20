using System;
using System.Collections.Generic;
using System.Data;
using  Quanlydiemsv.DataAccess;

namespace Quanlydiemsv.Logic
{
    public class GiangVien
    {
        public string MaGV { get; set; }
        public string TenGV { get; set; }
        public string GioiTinh { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public GiangVien(string MaGV, string TenGV, string GioiTinh, string Phone, string Email)
        {
            this.MaGV = MaGV;
            this.TenGV = TenGV;
            this.GioiTinh = GioiTinh;
            this.Phone = Phone;
            this.Email = Email;
        }
    }
    public class ListGiangVien
    {
        public static List<GiangVien> getAllGiangVien()
        {
            List<GiangVien> cats = new List<GiangVien>();
            DataTable dt = GiangVienDAO.getAllGiangVien();
            foreach (DataRow dr in dt.Rows)
            {
                cats.Add(new GiangVien(
                    dr["MaGV"].ToString(),
                    dr["TenGV"].ToString(),
                    dr["GioiTinh"].ToString(),
                    dr["Phone"].ToString(),
                    dr["Email"].ToString()
                ));
            }
            return cats;
        }

    }
}
