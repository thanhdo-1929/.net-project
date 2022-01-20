using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quanlydiemsv.DataAccess;
using Quanlydiemsv.Logic;
namespace Quanlydiemsv
{
    public partial class frmQLSV : Form
    {

        private List<SinhVien> listSinhVien = ListSinhVien.getAllSinhVien();
        private List<KetQua> listKetQua = ListKetQua.getAllKetQua();
        private List<Lop> listLop = ListLop.getAllLop();
        private List<Khoa> listKhoa = ListKhoa.getAllKhoa();

        public frmQLSV()
        {
            InitializeComponent();
        }

        public frmQLSV(Login acc)
        {
            InitializeComponent();
            loadData();

            cboKhoahoc.DisplayMember = "TenKhoa";
            cboKhoahoc.ValueMember = "MaKhoa";
            cboKhoahoc.DataSource = ListKhoa.getAllKhoa();
            cboKhoahoc.SelectedIndex = 0;

            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            cboLop.DataSource = ListLop.getAllLop();
            cboLop.SelectedIndex = 0;

            cboGioiTinh.DisplayMember = "Text";
            cboGioiTinh.ValueMember = "Value";
            cboGioiTinh.Items.Add(new { Text = "Nam", Value = "Nam" });
            cboGioiTinh.Items.Add(new { Text = "Nu", Value = "Nu" });
            cboGioiTinh.SelectedIndex = 0;

            cboTenLop.DisplayMember = "TenLop";
            cboTenLop.ValueMember = "MaLop";
            cboTenLop.DataSource = ListLop.getAllLop();
            cboTenLop.SelectedIndex = 0;

            cboMalop.DisplayMember = "MaLop";
            cboMalop.ValueMember = "MaLop";
            cboMalop.DataSource = ListLop.getAllLop();
            cboMalop.SelectedIndex = 0;

        }

        private void loadData()
        {
            //dgrDSSV.DataSource = ListSinhVien.getAllSinhVien();
            if (cboLop.SelectedValue != null)
            {
                dgrDSSV.DataSource = DAO.GetDataBySQL("SELECT * FROM dbo.tblSINH_VIEN WHERE MaLop = '" + cboLop.SelectedValue.ToString() + "'");
            }

        }

        private void dgrDSSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = dgrDSSV.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dgrDSSV.CurrentRow.Cells[1].Value.ToString();
            mskNgaySinh.Text = dgrDSSV.CurrentRow.Cells[2].Value.ToString();
            cboGioiTinh.Text = dgrDSSV.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = dgrDSSV.CurrentRow.Cells[4].Value.ToString();
            cboMalop.Text = dgrDSSV.CurrentRow.Cells[5].Value.ToString();


            foreach (Lop lop in listLop)
            {
                if (cboMalop.Text.Equals(lop.MaLop))
                {
                    cboTenLop.Text = lop.TenLop;
                }
            }

        }

        private Boolean tontai = false;
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (validate() != "")
            {
                MessageBox.Show(validate());
            }
            else
            {
                try
                {
                    foreach (SinhVien list in listSinhVien)
                    {
                        if (txtMaSV.Text.Equals(list.MaSv))
                        {
                            tontai = true;
                            MessageBox.Show("Bạn đã nhập trùng mã sinh viên ", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }

                    if (tontai == false)
                    {
                        int count = SinhVienDAO.InsertSinhVien(txtMaSV.Text, txtHoTen.Text, mskNgaySinh.Text, cboGioiTinh.Text, txtDiaChi.Text, cboMalop.SelectedValue.ToString());
                        if (count > 0)
                        {
                            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo!");
                        }
                        else
                        {
                            MessageBox.Show("Thêm sinh viên thất bại!", "Thông báo!");
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Thêm sinh viên thất bại!", "Thông báo!");
                }
            }
            
            

            loadData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (validate() != "")
                {
                    MessageBox.Show(validate());
                }
                else
                {
                    int count = SinhVienDAO.UpdateSinhVien(txtMaSV.Text, txtHoTen.Text, mskNgaySinh.Text, cboGioiTinh.Text, txtDiaChi.Text, cboMalop.SelectedValue.ToString(), dgrDSSV.CurrentRow.Cells[0].Value.ToString());
                    if (count > 0)
                    {
                        MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật dữ liệu thất bại!", "Thông báo!");
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại!", "Thông báo!");
            }
            loadData();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int count = SinhVienDAO.DeleteSinhVien(txtMaSV.Text);
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");
                loadData();
            }
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private string validate()
        {
            string msgErr = "";

            if (txtMaSV.Text.Trim() == "")
            {
                msgErr = "Mã môn trống!";
            }
            if (txtHoTen.Text.Trim() == "")
            {
                msgErr = "\n Họ tên trống!";
            }
            if (mskNgaySinh.Text.Trim() == "")
            {
                msgErr += "\n Ngày sinh trống";
            }

            if (txtDiaChi.Text.Trim() == "")
            {
                msgErr += "\n Địa chỉ trống";
            }

            return msgErr;
        }

        private void frmQLSV_Load(object sender, EventArgs e)
        {

        }

        private void cboKhoahoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoahoc.SelectedValue != null)
            {
                string makhoa = cboKhoahoc.SelectedValue.ToString();
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
                cboLop.DataSource = DAO.GetDataBySQL("SELECT * FROM dbo.tblLOP WHERE MaKhoa = '" + makhoa + "'");

            }
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLop.SelectedValue != null)
            {
                dgrDSSV.DataSource = DAO.GetDataBySQL("SELECT * FROM dbo.tblSINH_VIEN WHERE MaLop = '" + cboLop.SelectedValue.ToString() + "'");
            }
        }

        private void cboTenLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoahoc.SelectedValue != null)
            {
                string malop = cboTenLop.SelectedValue.ToString();
                cboMalop.DisplayMember = "MaLop";
                cboMalop.ValueMember = "MaLop";
                cboMalop.DataSource = DAO.GetDataBySQL("SELECT * FROM dbo.tblLOP WHERE MaLop = '" + malop + "'");

            }
        }
    }
}
