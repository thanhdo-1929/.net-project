using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Quanlydiemsv.DataAccess
{
    class SinhVienDAO
    {
        // SINH VIEN
        public static DataTable getAllSinhVien()
        {
            string sql = "SELECT * FROM dbo.tblSINH_VIEN";
            return DAO.GetDataBySQL(sql);
        }
        public static int DeleteSinhVien(string masinhvien)
        {
            string sql = "delete from dbo.tblSINH_VIEN WHERE MaSv = @ma";
            SqlParameter param = new SqlParameter("@ma", SqlDbType.NVarChar);
            param.Value = masinhvien;
            return DAO.ExecuteSQL(sql, param);
        }

        public static int InsertSinhVien(string masv, string hoten, string ngaysinh, string gioitinh, string diachi, string malop)
        {
            string sql = @"INSERT INTO dbo.tblSINH_VIEN ([MaSv],[HoTen],[NgaySinh],[GioiTinh],[DiaChi],[MaLop])
                         VALUES(@masv,@hoten,@ngaysinh,@gioitinh,@diachi,@malop)";
            SqlParameter[] param = { new SqlParameter("@masv", SqlDbType.NVarChar),
                new SqlParameter("@hoten", SqlDbType.NVarChar),
                new SqlParameter("@ngaysinh", SqlDbType.NVarChar),
                new SqlParameter("@gioitinh", SqlDbType.NVarChar),
                new SqlParameter("@diachi", SqlDbType.NVarChar),
                new SqlParameter("@malop", SqlDbType.NVarChar)
            };
            param[0].Value = masv;
            param[1].Value = hoten;
            param[2].Value = ngaysinh;
            param[3].Value = gioitinh;
            param[4].Value = diachi;
            param[5].Value = malop;

            return DAO.ExecuteSQL(sql, param);
        }

        public static int UpdateSinhVien(string macu, string hoten, string ngaysinh, string gioitinh, string diachi, string malop, string mamoi)
        {
            string sql = @"UPDATE [dbo].[tblSINH_VIEN]
                          SET [MaSv] = @macu
                          ,[HoTen] = @hoten
                          ,[NgaySinh] = @ngaysinh
                          ,[GioiTinh] = @gioitinh
                          ,[DiaChi] = @diachi
                          ,[MaLop] = @malop
                        WHERE MaSv = @mamoi";
            SqlParameter[] param = { new SqlParameter("@macu", SqlDbType.NVarChar),
                new SqlParameter("@hoten", SqlDbType.NVarChar),
                new SqlParameter("@ngaysinh", SqlDbType.NVarChar),
                new SqlParameter("@gioitinh", SqlDbType.NVarChar),
                new SqlParameter("@diachi", SqlDbType.NVarChar),
                new SqlParameter("@malop", SqlDbType.NVarChar),
                new SqlParameter("@mamoi", SqlDbType.NVarChar),
            };
            param[0].Value = macu;
            param[1].Value = hoten;
            param[2].Value = ngaysinh;
            param[3].Value = gioitinh;
            param[4].Value = diachi;
            param[5].Value = malop;
            param[6].Value = mamoi;
            return DAO.ExecuteSQL(sql, param);
        }
    }
}
