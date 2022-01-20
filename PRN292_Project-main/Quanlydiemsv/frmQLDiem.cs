using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quanlydiemsv.Logic;
using Quanlydiemsv.DataAccess;

namespace Quanlydiemsv
{
    public partial class frmQLDiem : Form
    {

        private List<SinhVien> listSinhVien = ListSinhVien.getAllSinhVien();
        private List<KetQua> listKetQua = ListKetQua.getAllKetQua();
        private List<Lop> listLop = ListLop.getAllLop();
        private List<Khoa> listKhoa = ListKhoa.getAllKhoa();
        private double diemtb, diemthi, diemtk;

        public frmQLDiem()
        {
            InitializeComponent();
        }
        public frmQLDiem(Login acc)
        {
            InitializeComponent();
            cboLop.DisplayMember = "MaLop";
            cboLop.ValueMember = "MaLop";
            cboLop.DataSource = ListLop.getAllLop();
            cboLop.SelectedIndex = 0;

            cboKhoaHoc.DisplayMember = "TenKhoa";
            cboKhoaHoc.ValueMember = "MaKhoa";
            cboKhoaHoc.DataSource = ListKhoa.getAllKhoa();
            cboKhoaHoc.SelectedIndex = 0;

            cboMonHoc.DisplayMember = "MaMon";
            cboMonHoc.ValueMember = "MaMon";
            cboMonHoc.DataSource = ListMon.getAllMon();
            cboMonHoc.SelectedIndex = 0;
            loadData();
        }
        private void frmQLDiem_Load(object sender, EventArgs e)
        {
            txtHoTen.Enabled = false;
            txtGhiChu.Enabled = false;
        }


        private void loadData()
        {
            dgrDiem.DataSource = ListKetQua.getAllKetQua();
            // diemtk = (diemtb + diemthi) / 2;
            // txtDiemTK.Text = diemtk.ToString();
            txtDiemTK.Enabled = false;
            // txtDiemTK.Text = diemtk.ToString();
        }

        private void dgrDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = dgrDiem.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dgrDiem.CurrentRow.Cells[1].Value.ToString();
            cboLop.Text = dgrDiem.CurrentRow.Cells[2].Value.ToString();
            cboMonHoc.Text = dgrDiem.CurrentRow.Cells[3].Value.ToString();
            txtDiemTB.Text = dgrDiem.CurrentRow.Cells[4].Value.ToString();
            txtDiemThi.Text = dgrDiem.CurrentRow.Cells[5].Value.ToString();
            txtDiemTK.Text = dgrDiem.CurrentRow.Cells[6].Value.ToString();
            cboHocKi.Text = dgrDiem.CurrentRow.Cells[7].Value.ToString();
            txtGhiChu.Text = dgrDiem.CurrentRow.Cells[8].Value.ToString();


        }

        private void txtDiemTK_TextChanged(object sender, EventArgs e)
        {

        }

        private Boolean tontai = false;
        private void button1_Click(object sender, EventArgs e)
        {

            if (validate() != "")
            {
                MessageBox.Show(validate());
            }
            else
            {
                diemtb = Convert.ToDouble(txtDiemTB.Text);
                diemthi = Convert.ToDouble(txtDiemThi.Text);
                diemtk = diemtk = (diemtb + diemthi) / 2;
                txtDiemTK.Text = diemtk.ToString();
                if (diemtk < 5)
                {
                    txtGhiChu.Text = "Thi lai";
                }
                else
                {
                    txtGhiChu.Text = "Qua mon";
                }

                foreach (SinhVien sv in listSinhVien)
                {
                    if (txtMaSV.Text.Equals(sv.MaSv))
                    {
                        txtHoTen.Text = sv.HoTen;
                    }
                }
                try
                {
                    foreach (KetQua list in listKetQua)
                    {
                        if (txtMaSV.Text.Equals(list.MaSV) && cboMonHoc.Text.Equals(list.MaMon))
                        {
                            tontai = true;
                            MessageBox.Show("Sinh viên này đã được nhập điểm môn: " + cboMonHoc.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }

                    if (tontai == false)
                    {
                        int count = KetQuaDAO.InsertKetQua(txtMaSV.Text, txtHoTen.Text, cboLop.SelectedValue.ToString(), cboMonHoc.SelectedValue.ToString(), Convert.ToDouble(txtDiemTB.Text), Convert.ToDouble(txtDiemThi.Text), diemtk, cboHocKi.Text, txtGhiChu.Text);
                        if (count > 0)
                        {
                            MessageBox.Show("Thêm kết quả thành công!", "Thông báo!");
                        }
                        else
                        {
                            MessageBox.Show("Thêm kết quả thất bại!", "Thông báo!");
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Thêm kết quả thất bại!", "Thông báo!");
                }

            }

            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validate() != "")
            {
                MessageBox.Show(validate());
            }
            else
            {
                diemtb = Convert.ToDouble(txtDiemTB.Text);
                diemthi = Convert.ToDouble(txtDiemThi.Text);
                diemtk = diemtk = (diemtb + diemthi) / 2;
                txtDiemTK.Text = diemtk.ToString();
                if (diemtk < 5)
                {
                    txtGhiChu.Text = "Thi lai";
                }
                else
                {
                    txtGhiChu.Text = "Qua mon";
                }
                int count = KetQuaDAO.UpdateKetQua(txtMaSV.Text, txtHoTen.Text, cboLop.Text, cboMonHoc.Text, diemtb, diemthi, (diemtb + diemthi) / 2, cboHocKi.Text, txtGhiChu.Text, dgrDiem.CurrentRow.Cells[0].Value.ToString(), dgrDiem.CurrentRow.Cells[3].Value.ToString());
                if (count > 0)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo!");
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thất bại!", "Thông báo!");
                }
            }
            loadData();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int count = KetQuaDAO.DeleteKetQua(txtMaSV.Text, cboMonHoc.SelectedValue.ToString());
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");
                loadData();
            }
        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoaHoc.SelectedValue != null)
            {
                cboMonHoc.DisplayMember = "MaMon";
                cboMonHoc.ValueMember = "MaMon";
                cboMonHoc.DataSource = DAO.GetDataBySQL("SELECT * FROM dbo.tblMon WHERE MaKhoa = '" + cboKhoaHoc.SelectedValue.ToString() + "'");

                cboLop.DisplayMember = "MaLop";
                cboLop.ValueMember = "MaLop";
                cboLop.DataSource = DAO.GetDataBySQL("SELECT * FROM dbo.tblLOP WHERE MaKhoa = '" + cboKhoaHoc.SelectedValue.ToString() + "'");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string validate()
        {
            string msgErr = "";

            if (txtMaSV.Text.Trim() == "")
            {
                msgErr = "Mã sinh viên trống!";
            }
            if (txtHoTen.Text.Trim() == "")
            {
                msgErr = "\n Tên sinh viên trống!";
            }
            // if (txtGhiChu.Text.Trim() == "")
            // {
            //     msgErr += "\n Ghi chú trống";
            // }

            if (txtDiemTB.Text.Trim() == "")
            {
                msgErr += "\n Điểm trung bình trống";
            }

            if (txtDiemThi.Text.Trim() == "")
            {
                msgErr += "\n Điểm thi trống";
            }

            if (int.Parse(txtDiemTB.Text.Trim()) < 1 || int.Parse(txtDiemTB.Text.Trim()) > 10 || int.Parse(txtDiemThi.Text.Trim()) < 1 || int.Parse(txtDiemThi.Text.Trim()) > 10)
            {
                msgErr = "\n Điểm chỉ được nhập từ 1 đến 10";
            }

            return msgErr;
        }
    }
}
