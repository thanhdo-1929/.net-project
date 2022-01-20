using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Quanlydiemsv.DataAccess;

namespace Quanlydiemsv.Logic
{
    public class Mon
    {
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public string MaGV { get; set; }
        public string HocKi { get; set; }
        public string MaKhoa { get; set; }

        public Mon(string MaMon, string TenMon, string MaGV, string HocKi, string MaKhoa)
        {
            this.MaMon = MaMon;
            this.TenMon = TenMon;
            this.MaGV = MaGV;
            this.HocKi = HocKi;
            this.MaKhoa = MaKhoa;
        }
    }

    public class ListMon
    {
        public static List<Mon> getAllMon()
        {
            List<Mon> cats = new List<Mon>();
            DataTable dt = MonDAO.getAllMon();
            foreach (DataRow dr in dt.Rows)
            {
                cats.Add(new Mon(
                    dr["MaMon"].ToString(),
                    dr["TenMon"].ToString(),
                    dr["MaGV"].ToString(),
                    dr["HocKi"].ToString(),
                    dr["MaKhoa"].ToString()
                ));
            }
            return cats;
        }

        public static List<Mon> getAllMonByMaKhoa(string makhoa)
        {
            List<Mon> cats = new List<Mon>();
            DataTable dt = MonDAO.getAllMonByMaKhoa(makhoa);
            foreach (DataRow dr in dt.Rows)
            {
                cats.Add(new Mon(
                    dr["MaMon"].ToString(),
                    dr["TenMon"].ToString(),
                    dr["MaGV"].ToString(),
                    dr["HocKi"].ToString(),
                    dr["MaKhoa"].ToString()
                ));
            }
            return cats;
        }

    }
}
