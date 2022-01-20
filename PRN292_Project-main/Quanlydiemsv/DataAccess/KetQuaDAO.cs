using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Quanlydiemsv.DataAccess
{
    class KetQuaDAO
    {
        // KET QUA
        public static DataTable getAllKetQua()
        {
            string sql = "select * from [dbo].[tblKET_QUA]";
            return DAO.GetDataBySQL(sql);
        }
        public static int DeleteKetQua(string masv, string mamonhoc)
        {
            string sql = "delete from [dbo].[tblKET_QUA] WHERE [MaSV] = @masv and [MaMon] = @mamh";
            SqlParameter[] param = { new SqlParameter("@masv", SqlDbType.NVarChar),
                new SqlParameter("@mamh", SqlDbType.NVarChar),
            };
            param[0].Value = masv;
            param[1].Value = mamonhoc;
            return DAO.ExecuteSQL(sql, param);
        }
        public static int InsertKetQua(string masv, string hoten, string malop, string mamon, double diemtb, double diemthi, double diemtk, string hocky, string ghichu)
        {
            string sql = @"INSERT INTO [dbo].[tblKET_QUA]([MaSV],[HoTen],[MaLop],[MaMon],[DiemTB],[DiemThi],[DiemTongKet],[HocKi],[GhiChu])
            VALUES(@masv,@hoten,@malop,@mamon,@diemtb,@diemthi,@diemtk,@hocky,@ghichu)";
            SqlParameter[] param = { new SqlParameter("@masv", SqlDbType.NVarChar),
                new SqlParameter("@hoten", SqlDbType.NVarChar),
                new SqlParameter("@malop", SqlDbType.NVarChar),
                new SqlParameter("@mamon", SqlDbType.NVarChar),
                new SqlParameter("@diemtb", SqlDbType.Money),
                new SqlParameter("@diemthi", SqlDbType.Money),
                new SqlParameter("@diemtk", SqlDbType.Money),
                new SqlParameter("@hocky", SqlDbType.NVarChar),
                new SqlParameter("@ghichu", SqlDbType.NVarChar)
            };
            param[0].Value = masv;
            param[1].Value = hoten;
            param[2].Value = malop;
            param[3].Value = mamon;
            param[4].Value = diemtb;
            param[5].Value = diemthi;
            param[6].Value = diemtk;
            param[7].Value = hocky;
            param[8].Value = ghichu;

            return DAO.ExecuteSQL(sql, param);
        }
        public static int UpdateKetQua(string masv, string hoten, string malop, string mamon, double diemtb, double diemthi, double diemtk, string hocky, string ghichu, string masvcu, string mamoncu)
        {
            string sql = @"UPDATE [dbo].[tblKET_QUA]
                          SET [MaSV] = @masv
                          ,[HoTen] = @hoten
                          ,[MaLop] = @malop
                          ,[MaMon] = @mamon
                          ,[DiemTB] = @diemtb
                          ,[DiemThi] = @diemthi
                          ,[DiemTongKet] = @diemtk
                          ,[HocKi] = @hocky
                          ,[GhiChu] = @ghichu
                        WHERE MaSV = @masvcu and MaMon = @mamoncu";
            SqlParameter[] param = { new SqlParameter("@masv", SqlDbType.NVarChar),
                new SqlParameter("@hoten", SqlDbType.NVarChar),
                new SqlParameter("@malop", SqlDbType.NVarChar),
                new SqlParameter("@mamon", SqlDbType.NVarChar),
                new SqlParameter("@diemtb", SqlDbType.Money),
                new SqlParameter("@diemthi", SqlDbType.Money),
                new SqlParameter("@diemtk", SqlDbType.Money),
                new SqlParameter("@hocky", SqlDbType.NVarChar),
                new SqlParameter("@ghichu", SqlDbType.NVarChar),
                new SqlParameter("@masvcu", SqlDbType.NVarChar),
                new SqlParameter("@mamoncu", SqlDbType.NVarChar)
            };
            param[0].Value = masv;
            param[1].Value = hoten;
            param[2].Value = malop;
            param[3].Value = mamon;
            param[4].Value = diemtb;
            param[5].Value = diemthi;
            param[6].Value = diemtk;
            param[7].Value = hocky;
            param[8].Value = ghichu;
            param[9].Value = masvcu;
            param[10].Value = mamoncu;
            return DAO.ExecuteSQL(sql, param);
        }
    }
}
