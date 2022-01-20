using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Quanlydiemsv.DataAccess
{
    class KhoaDAO
    {
        // KHOA
        public static DataTable getAllKhoa()
        {
            string sql = "select * from [dbo].[tblKHOA]";
            return DAO.GetDataBySQL(sql);
        }
        public static int DeleteKhoa(string makhoa)
        {
            //DeleteLop(makhoa);
            string sql = "delete from [dbo].[tblKHOA] WHERE [MaKhoa] = @ma";
            SqlParameter param = new SqlParameter("@ma", SqlDbType.NVarChar);
            param.Value = makhoa;
            return DAO.ExecuteSQL(sql, param);
        }

        public static int InsertKhoa(string makhoa, string tenkhoa)
        {
            string sql = @"INSERT INTO [dbo].[tblKHOA]([MaKhoa],[TenKhoa])
                            VALUES(@makhoa,@tenkhoa)";
            SqlParameter[] param = { new SqlParameter("@makhoa", SqlDbType.NVarChar),
                new SqlParameter("@tenkhoa", SqlDbType.NVarChar)
            };
            param[0].Value = makhoa;
            param[1].Value = tenkhoa;

            return DAO.ExecuteSQL(sql, param);
        }
        public static int UpdateKhoa(string makhoa, string tenkhoa, string makhoamoi)
        {
            string sql = @"UPDATE [dbo].[tblKHOA]
                           SET [MaKhoa] = @makhoa
                              ,[TenKhoa] = @tenkhoa
                         WHERE MaKhoa = @mamoi";
            SqlParameter[] param = { new SqlParameter("@makhoa", SqlDbType.NVarChar),
                new SqlParameter("@tenkhoa", SqlDbType.NVarChar),
                new SqlParameter("@mamoi", SqlDbType.NVarChar)
            };
            param[0].Value = makhoa;
            param[1].Value = tenkhoa;
            param[2].Value = makhoamoi;

            return DAO.ExecuteSQL(sql, param);
        }
    }
}
