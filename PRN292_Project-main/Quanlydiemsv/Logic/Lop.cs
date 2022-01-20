using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Quanlydiemsv.DataAccess;

namespace Quanlydiemsv.Logic
{
    public class Lop
    {
        public string MaKhoa { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }

        public Lop(string MaKhoa, string MaLop, string TenLop)
        {
            this.MaKhoa = MaKhoa;
            this.MaLop = MaLop;
            this.TenLop = TenLop;
        }
    }

    public class ListLop
    {
        public static List<Lop> getAllLop()
        {
            List<Lop> cats = new List<Lop>();
            DataTable dt = LopDAO.getAllLop();
            foreach (DataRow dr in dt.Rows)
            {
                cats.Add(new Lop(
                    dr["MaKhoa"].ToString(),
                    dr["MaLop"].ToString(),
                    dr["TenLop"].ToString()
                ));
            }
            return cats;
        }


    }
}
