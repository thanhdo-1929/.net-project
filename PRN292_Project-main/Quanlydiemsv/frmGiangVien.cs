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
using System.Text.RegularExpressions;

namespace Quanlydiemsv
{
    public partial class frmGiangVien : Form
    {

        private List<SinhVien> listSinhVien = ListSinhVien.getAllSinhVien();
        private List<KetQua> listKetQua = ListKetQua.getAllKetQua();
        private List<Lop> listLop = ListLop.getAllLop();
        private List<Khoa> listKhoa = ListKhoa.getAllKhoa();
        private List<GiangVien> listGiangVien = ListGiangVien.getAllGiangVien();

        public frmGiangVien()
        {
            InitializeComponent();
        }

        public frmGiangVien(Login acc)
        {
            InitializeComponent();
            loadData();

            cboGioiTinh.DisplayMember = "Text";
            cboGioiTinh.ValueMember = "Value";
            cboGioiTinh.Items.Add(new { Text = "Nam", Value = "Nam" });
            cboGioiTinh.Items.Add(new { Text = "Nu", Value = "Nu" });
            cboGioiTinh.SelectedIndex = 0;

        }

        private void loadData()
        {
            dgrDSGV.DataSource = ListGiangVien.getAllGiangVien();
        }

        private void dgrDSGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaGV.Text = dgrDSGV.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dgrDSGV.CurrentRow.Cells[1].Value.ToString();
            cboGioiTinh.Text = dgrDSGV.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = dgrDSGV.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgrDSGV.CurrentRow.Cells[4].Value.ToString();
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
                    foreach (GiangVien list in listGiangVien)
                    {
                        if (txtMaGV.Text.Equals(list.MaGV))
                        {
                            tontai = true;
                            MessageBox.Show("Bạn đã nhập trùng mã giảng viên", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }

                    if (tontai == false)
                    {
                        int count = GiangVienDAO.InsertGiangVien(txtMaGV.Text, txtHoTen.Text, cboGioiTinh.Text, txtPhone.Text, txtEmail.Text);
                        if (count > 0)
                        {
                            MessageBox.Show("Thêm giảng viên thành công!", "Thông báo!");
                        }
                        else
                        {
                            MessageBox.Show("Thêm giảng viên thất bại!", "Thông báo!");
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Thêm giảng viên thất bại!", "Thông báo!");
                }
            }

            loadData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (validate() != "")
            {
                MessageBox.Show(validate());
            }
            else
            {
                int count = GiangVienDAO.UpdateGiangVien(txtMaGV.Text, txtHoTen.Text, cboGioiTinh.Text, txtPhone.Text, txtEmail.Text, dgrDSGV.CurrentRow.Cells[0].Value.ToString());
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int count = GiangVienDAO.DeleteGiangVien(txtMaGV.Text);
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

            if (txtMaGV.Text.Trim() == "")
            {
                msgErr = "Mã giảng viên trống!";
            }
            if (txtHoTen.Text.Trim() == "")
            {
                msgErr = "\n Họ tên trống!";
            }
            if (txtPhone.Text.Trim() == "")
            {
                msgErr += "\n Phone trống";
            }
            string phone = "[0-9]{9,13}";
            if (!Regex.IsMatch(txtPhone.Text, phone))
            {
                msgErr += "\n Phone không hợp lệ";
            }

            if (txtEmail.Text.Trim() == "")
            {
                msgErr += "\n Email trống";
            }

            string regex = "^\\w+[a-z0-9]*@{1}gmail.com$";
            if (!Regex.IsMatch(txtEmail.Text, regex))
            {
                msgErr += "\n Email không hợp lệ";
            }

            return msgErr;
        }

        private void frmGiangVien_Load(object sender, EventArgs e)
        {

        }
    }
}
