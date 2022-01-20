using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Quanlydiemsv.DataAccess;

namespace Quanlydiemsv.Logic
{
    public class Khoa
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }

        public Khoa(string MaKhoa, string TenKhoa)
        {
            this.MaKhoa = MaKhoa;
            this.TenKhoa = TenKhoa;
        }
    }
    public class ListKhoa
    {
        public static List<Khoa> getAllKhoa()
        {
            List<Khoa> cats = new List<Khoa>();
            DataTable dt = KhoaDAO.getAllKhoa();
            foreach (DataRow dr in dt.Rows)
            {
                cats.Add(new Khoa(
                    dr["MaKhoa"].ToString(),
                    dr["TenKhoa"].ToString()
                ));
            }
            return cats;
        }

    }
}
