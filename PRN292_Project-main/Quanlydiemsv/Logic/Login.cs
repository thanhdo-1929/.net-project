using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Quanlydiemsv.DataAccess;

namespace Quanlydiemsv.Logic
{
    public class Login
    {
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string MaSo { get; set; }
        public string Quyen { get; set; }

        public Login(string TenDN, string MatKhau, string HoTen, string MaSo, string Quyen)
        {
            this.TenDN = TenDN;
            this.MatKhau = MatKhau;
            this.HoTen = HoTen;
            this.MaSo = MaSo;
            this.Quyen = Quyen;

        }
    }

    public class ListLogin
    {
        public static List<Login> getAllLogin()
        {
            List<Login> cats = new List<Login>();
            DataTable dt = LoginDAO.getAllLogin();
            foreach (DataRow dr in dt.Rows)
            {
                cats.Add(new Login(
                    dr["TenDN"].ToString(),
                    dr["MatKhau"].ToString(),
                    dr["HoTen"].ToString(),
                    dr["MaSo"].ToString(),
                    dr["Quyen"].ToString()
                ));
            }
            return cats;
        }

    }
}
