using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Quanlydiemsv.DataAccess
{
    class MonDAO
    {
        // MON HOC
        public static DataTable getAllMon()
        {
            string sql = "select * from [dbo].[tblMON]";
            return DAO.GetDataBySQL(sql);
        }

        public static DataTable getAllMonByMaKhoa(string makhoa)
        {
            string sql = @"Select MaMon from tblMON where MaKhoa=@makhoa";
            SqlParameter[] param = {
                new SqlParameter("@makhoa",SqlDbType.NChar),
            };
            param[0].Value = makhoa;
            return DAO.getData(sql, param);
        }
        public static int DeleteMonHoc(string mamonhoc)
        {
            string sql = "delete from [dbo].[tblMON] WHERE [MaMon] = @ma";
            SqlParameter param = new SqlParameter("@ma", SqlDbType.NVarChar);
            param.Value = mamonhoc;
            return DAO.ExecuteSQL(sql, param);
        }

        public static int InsertMon(string mamonhoc, string tenmonhoc, string magiaovien, string hocky, string makhoa)
        {
            string sql = @"INSERT INTO [dbo].[tblMON]([MaMon],[TenMon],[MaGV],[HocKi],[MaKhoa])
                            VALUES(@mamonhoc,@tenmonhoc,@magiaovien,@hocky,@makhoa)";
            SqlParameter[] param = { new SqlParameter("@mamonhoc", SqlDbType.NVarChar),
                new SqlParameter("@tenmonhoc", SqlDbType.NVarChar),
                new SqlParameter("@magiaovien", SqlDbType.NVarChar),
                new SqlParameter("@hocky", SqlDbType.NVarChar),
                new SqlParameter("@makhoa", SqlDbType.NChar)
            };
            param[0].Value = mamonhoc;
            param[1].Value = tenmonhoc;
            param[2].Value = magiaovien;
            param[3].Value = hocky;
            param[4].Value = makhoa;

            return DAO.ExecuteSQL(sql, param);
        }
        public static int UpdateMon(string macu, string tenmonhoc, string magiaovien, string hocky, string makhoa, string mamoi)
        {
            string sql = @"UPDATE [dbo].[tblMON]
                           SET [MaMon] = @macu
                              ,[TenMon] = @tenmonhoc
                              ,[MaGV] = @magiaovien
                              ,[HocKi] = @hocky
                              ,[MaKhoa] = @makhoa
                         WHERE MaMon = @mamoi";
            SqlParameter[] param = { new SqlParameter("@macu", SqlDbType.NVarChar),
                new SqlParameter("@tenmonhoc", SqlDbType.NVarChar),
                new SqlParameter("@magiaovien", SqlDbType.NVarChar),
                new SqlParameter("@hocky", SqlDbType.NVarChar),
                new SqlParameter("@makhoa", SqlDbType.NChar),
                new SqlParameter("@mamoi", SqlDbType.NVarChar)
            };
            param[0].Value = macu;
            param[1].Value = tenmonhoc;
            param[2].Value = magiaovien;
            param[3].Value = hocky;
            param[4].Value = makhoa;
            param[5].Value = mamoi;
            return DAO.ExecuteSQL(sql, param);
        }
    }
}
