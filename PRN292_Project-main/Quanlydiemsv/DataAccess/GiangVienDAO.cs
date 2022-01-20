using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Quanlydiemsv.DataAccess
{
    class GiangVienDAO
    {
        // GIANG VIEN
        public static DataTable getAllGiangVien()
        {
            string sql = "select * from [dbo].[tblGIANG_VIEN]";
            return DAO.GetDataBySQL(sql);
        }
        public static int DeleteGiangVien(string magiangvien)
        {
            string sql = "delete from [dbo].[tblGIANG_VIEN] WHERE MaGV = @ma";
            SqlParameter param = new SqlParameter("@ma", SqlDbType.NVarChar);
            param.Value = magiangvien;
            return DAO.ExecuteSQL(sql, param);
        }

        public static int InsertGiangVien(string ma, string ten, string gioitinh, string phone, string email)
        {
            string sql = @"INSERT INTO [dbo].[tblGIANG_VIEN]([MaGV],[TenGV],[GioiTinh],[Phone],[Email])
                         VALUES(@magv,@ten,@gioitinh,@phone,@email)";
            SqlParameter[] param = { new SqlParameter("@magv", SqlDbType.NVarChar),
                new SqlParameter("@ten", SqlDbType.NVarChar),
                new SqlParameter("@gioitinh", SqlDbType.NVarChar),
                new SqlParameter("@phone", SqlDbType.NVarChar),
                new SqlParameter("@email", SqlDbType.NVarChar)
            };
            param[0].Value = ma;
            param[1].Value = ten;
            param[2].Value = gioitinh;
            param[3].Value = phone;
            param[4].Value = email;
            return DAO.ExecuteSQL(sql, param);
        }
        public static int UpdateGiangVien(string macu, string ten, string gioitinh, string phone, string email, string mamoi)
        {
            string sql = @"UPDATE [dbo].[tblGIANG_VIEN]
                          SET [MaGV] = @macu
                          ,[TenGV] = @ten
                          ,[GioiTinh] = @gioitinh
                          ,[Phone] = @phone
                          ,[Email] = @email
                        WHERE MaGV = @mamoi";
            SqlParameter[] param = { new SqlParameter("@macu", SqlDbType.NVarChar),
                new SqlParameter("@ten", SqlDbType.NVarChar),
                new SqlParameter("@gioitinh", SqlDbType.NVarChar),
                new SqlParameter("@phone", SqlDbType.NVarChar),
                new SqlParameter("@email", SqlDbType.NVarChar),
                new SqlParameter("@mamoi", SqlDbType.NVarChar),
            };
            param[0].Value = macu;
            param[1].Value = ten;
            param[2].Value = gioitinh;
            param[3].Value = phone;
            param[4].Value = email;
            param[5].Value = mamoi;

            return DAO.ExecuteSQL(sql, param);
        }
    }
}
