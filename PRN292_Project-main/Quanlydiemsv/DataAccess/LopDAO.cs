using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Quanlydiemsv.DataAccess
{
    class LopDAO
    {
        // LOP
        public static DataTable getAllLop()
        {
            string sql = "select * from [dbo].[tblLOP]";
            return DAO.GetDataBySQL(sql);
        }
        public static int DeleteLop(string malop)
        {
            string sql = "delete from [dbo].[tblLOP] WHERE [MaLop] = @ma";
            SqlParameter param = new SqlParameter("@ma", SqlDbType.NVarChar);
            param.Value = malop;
            return DAO.ExecuteSQL(sql, param);
        }

        public static int InsertLop(string makhoa, string malop, string tenlop)
        {
            string sql = @"INSERT INTO [dbo].[tblLOP]([MaKhoa],[MaLop],[TenLop])
                            VALUES(@makhoa,@malop,@tenlop)";
            SqlParameter[] param = { new SqlParameter("@makhoa", SqlDbType.NVarChar),
                new SqlParameter("@malop", SqlDbType.NVarChar),
                new SqlParameter("@tenlop", SqlDbType.NVarChar)
            };
            param[0].Value = makhoa;
            param[1].Value = malop;
            param[2].Value = tenlop;

            return DAO.ExecuteSQL(sql, param);
        }
        public static int UpdateLop(string makhoa, string malopcu, string tenlop, string malopmoi)
        {
            string sql = @"UPDATE [dbo].[tblLOP]
                           SET [MaKhoa] = @makhoa
                              ,[MaLop] = @macu
                              ,[TenLop] = @tenlop
                         WHERE MaLop = @mamoi";
            SqlParameter[] param = { new SqlParameter("@makhoa", SqlDbType.NVarChar),
                new SqlParameter("@macu", SqlDbType.NVarChar),
                new SqlParameter("@tenlop", SqlDbType.NVarChar),
                new SqlParameter("@mamoi", SqlDbType.NVarChar)
            };
            param[0].Value = makhoa;
            param[1].Value = malopcu;
            param[2].Value = tenlop;
            param[3].Value = malopmoi;

            return DAO.ExecuteSQL(sql, param);
        }
    }
}
