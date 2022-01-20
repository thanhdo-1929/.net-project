using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Quanlydiemsv.DataAccess
{
    public class DAO
    {
        static string strConnection = ConfigurationManager
                 .ConnectionStrings["AuctionConnectionString"]
                 .ConnectionString;
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(strConnection);
        }

        public static DataTable GetDataBySQL(string sql)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            DataSet ds = new DataSet(); 
            SqlDataAdapter adapter = new SqlDataAdapter(command); 
            adapter.Fill(ds);
            return ds.Tables[0];
        }

        public static int ExecuteSQL(string sql, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Parameters.AddRange(parameters);
            command.Connection.Open();
            int count = command.ExecuteNonQuery();
            command.Connection.Close();
            return count;
        }

        public static DataTable getData(string sql, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Parameters.AddRange(parameters);
            command.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            command.Connection.Close();
            return ds.Tables[0];
        }
/*
        // SINH VIEN
        public static DataTable getAllSinhVien()
        {
            string sql = "SELECT * FROM dbo.tblSINH_VIEN";
            return GetDataBySQL(sql);
        }
        public static int DeleteSinhVien(string masinhvien)
        {
            string sql = "delete from dbo.tblSINH_VIEN WHERE MaSv = @ma";
            SqlParameter param = new SqlParameter("@ma", SqlDbType.NVarChar);
            param.Value = masinhvien;
            return ExecuteSQL(sql, param);
        }

        public static int InsertSinhVien(string masv, string hoten, string ngaysinh,string gioitinh,string diachi,string malop)
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

            return ExecuteSQL(sql, param);
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
            return ExecuteSQL(sql, param);
        }

        // GIANG VIEN
        public static DataTable getAllGiangVien()
        {
            string sql = "select * from [dbo].[tblGIANG_VIEN]";
            return GetDataBySQL(sql);
        }
        public static int DeleteGiangVien(string magiangvien)
        {
            string sql = "delete from [dbo].[tblGIANG_VIEN] WHERE MaGV = @ma";
            SqlParameter param = new SqlParameter("@ma", SqlDbType.NVarChar);
            param.Value = magiangvien;
            return ExecuteSQL(sql, param);
        }

        public static int InsertGiangVien(string ma, string ten,string gioitinh, string phone, string email)
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
            return ExecuteSQL(sql, param);
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

            return ExecuteSQL(sql, param);
        }
        // KHOA
        public static DataTable getAllKhoa()
        {
            string sql = "select * from [dbo].[tblKHOA]";
            return GetDataBySQL(sql);
        }
        public static int DeleteKhoa(string makhoa)
        {
            //DeleteLop(makhoa);
            string sql = "delete from [dbo].[tblKHOA] WHERE [MaKhoa] = @ma";
            SqlParameter param = new SqlParameter("@ma", SqlDbType.NVarChar);
            param.Value = makhoa;
            return ExecuteSQL(sql, param);
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

            return ExecuteSQL(sql, param);
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

            return ExecuteSQL(sql, param);
        }

        // LOP
        public static DataTable getAllLop()
        {
            string sql = "select * from [dbo].[tblLOP]";
            return GetDataBySQL(sql);
        }
        public static int DeleteLop(string malop)
        {
            string sql = "delete from [dbo].[tblLOP] WHERE [MaLop] = @ma";
            SqlParameter param = new SqlParameter("@ma", SqlDbType.NVarChar);
            param.Value = malop;
            return ExecuteSQL(sql, param);
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

            return ExecuteSQL(sql, param);
        }
        public static int UpdateLop(string makhoa, string malopcu, string tenlop,string malopmoi)
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

            return ExecuteSQL(sql, param);
        }

        // MON HOC
        public static DataTable getAllMon()
        {
            string sql = "select * from [dbo].[tblMON]";
            return GetDataBySQL(sql);
        }

        public static DataTable getAllMonByMaKhoa(string makhoa)
        {
            string sql = @"Select MaMon from tblMON where MaKhoa=@makhoa";
            SqlParameter[] param = {
                new SqlParameter("@makhoa",SqlDbType.NChar),
            };
            param[0].Value = makhoa;
            return getData(sql, param);
        }
        public static int DeleteMonHoc(string mamonhoc)
        {
            string sql = "delete from [dbo].[tblMON] WHERE [MaMon] = @ma";
            SqlParameter param = new SqlParameter("@ma", SqlDbType.NVarChar);
            param.Value = mamonhoc;
            return ExecuteSQL(sql, param);
        }

        public static int InsertMon(string mamonhoc, string tenmonhoc, string magiaovien,string hocky,string makhoa)
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

            return ExecuteSQL(sql, param);
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
            return ExecuteSQL(sql, param);
        }

        // KET QUA
        public static DataTable getAllKetQua()
        {
            string sql = "select * from [dbo].[tblKET_QUA]";
            return GetDataBySQL(sql);
        }
        public static int DeleteKetQua(string  masv,string mamonhoc)
        {
            string sql = "delete from [dbo].[tblKET_QUA] WHERE [MaSV] = @masv and [MaMon] = @mamh";
            SqlParameter[] param = { new SqlParameter("@masv", SqlDbType.NVarChar),
                new SqlParameter("@mamh", SqlDbType.NVarChar),
            };
            param[0].Value = masv;
            param[1].Value = mamonhoc;
            return ExecuteSQL(sql, param);
        }
        public static int InsertKetQua(string masv, string hoten, string malop, string mamon, double diemtb, double diemthi, double diemtk,string hocky,string ghichu)
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

            return ExecuteSQL(sql, param);
        }
        public static int UpdateKetQua(string masv, string hoten, string malop, string mamon, double diemtb, double diemthi, double diemtk, string hocky, string ghichu, string masvcu,string mamoncu)
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
            return ExecuteSQL(sql, param);
        }

        // LOGIN

        public static DataTable getAllLogin()
        {
            string sql = "select * from [dbo].[tblLOGIN]";
            return GetDataBySQL(sql);
        }
        public static int DeleteLogin(string maso)
        {
            string sql = "delete from [dbo].[tblLOGIN] WHERE [MaSo] = @ma";
            SqlParameter param = new SqlParameter("@ma", SqlDbType.NVarChar);
            param.Value = maso;
            return ExecuteSQL(sql, param);
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

            return ExecuteSQL(sql, param);
        }
        public static int UpdateLogin(string tendangnhap, string matkhau, string hoten, string maso, string quyen,string tendangnhap2)
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
            return ExecuteSQL(sql, param);
        }
*/
        /// <summary>    
        /// Truyền nhiều biến
        /// </summary>

        public static DataTable getAllOrderByEmpAndCus(string customerID, int EmployeeID, string from, string to)
        {
            string sql = @"select o.OrderID, o.CustomerID, e.FirstName, o.OrderDate, o.RequiredDate,o.ShippedDate,o.Freight,o.ShipName,o.ShipAddress from Orders o join Employees e 
                           on o.EmployeeID = e.EmployeeID
                           where CustomerID = @cid and o.EmployeeID = @eid 
                           and OrderDate between @from and @to";
            SqlParameter[] param = {
                new SqlParameter("@cid",SqlDbType.NChar),
                new SqlParameter("@eid", SqlDbType.Int),
                new SqlParameter("@from",SqlDbType.DateTime),
                new SqlParameter("@to", SqlDbType.DateTime)};
            param[0].Value = customerID;
            param[1].Value = EmployeeID;
            param[2].Value = from;
            param[3].Value = to;
            return getData(sql, param);
        }
    }
}
