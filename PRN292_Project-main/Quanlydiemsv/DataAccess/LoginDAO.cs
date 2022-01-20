using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Quanlydiemsv.DataAccess
{
    class LoginDAO
    {
        // LOGIN
        public static DataTable getAllLogin()
        {
            string sql = "select * from [dbo].[tblLOGIN]";
            return DAO.GetDataBySQL(sql);
        }
        public static int DeleteLogin(string maso)
        {
            string sql = "delete from [dbo].[tblLOGIN] WHERE [MaSo] = @ma";
            SqlParameter param = new SqlParameter("@ma", SqlDbType.NVarChar);
            param.Value = maso;
            return DAO.ExecuteSQL(sql, param);
        }
        public static int InsertLogin(string tendangnhap, string matkhau, string hoten, string maso, string quyen)
        {
            string sql = @"INSERT INTO [dbo].[tblLOGIN]([TenDN],[MatKhau],[HoTen],[MaSo],[Quyen])
                         VALUES(@tendangnhap,@matkhau,@hoten,@maso,@quyen)";
            SqlParameter[] param = { new SqlParameter("@tendangnhap", SqlDbType.NVarChar),
                new SqlParameter("@matkhau", SqlDbType.NVarChar),
                new SqlParameter("@hoten", SqlDbType.NVarChar),
                new SqlParameter("@maso", SqlDbType.NVarChar),
                new SqlParameter("@quyen", SqlDbType.NVarChar)
            };
            param[0].Value = tendangnhap;
            param[1].Value = matkhau;
            param[2].Value = hoten;
            param[3].Value = maso;
            param[4].Value = quyen;

            return DAO.ExecuteSQL(sql, param);
        }
        public static int UpdateLogin(string tendangnhap, string matkhau, string hoten, string maso, string quyen, string tendangnhap2)
        {
            string sql = @"UPDATE [dbo].[tblLOGIN]
                          SET [TenDN] = @tendangnhap
                          ,[MatKhau] = @matkhau
                          ,[HoTen] = @hoten
                          ,[MaSo] = @maso
                          ,[Quyen] = @quyen
                        WHERE MaSo = @tendn2";
            SqlParameter[] param = { new SqlParameter("@tendangnhap", SqlDbType.NVarChar),
                new SqlParameter("@matkhau", SqlDbType.NVarChar),
                new SqlParameter("@hoten", SqlDbType.NVarChar),
                new SqlParameter("@maso", SqlDbType.NVarChar),
                new SqlParameter("@quyen", SqlDbType.NVarChar),
                new SqlParameter("@tendn2", SqlDbType.NVarChar)
            };
            param[0].Value = tendangnhap;
            param[1].Value = matkhau;
            param[2].Value = hoten;
            param[3].Value = maso;
            param[4].Value = quyen;
            param[5].Value = tendangnhap2;
            return DAO.ExecuteSQL(sql, param);
        }
    }
}
