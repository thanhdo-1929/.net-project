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
    public partial class frmQuanLyNguoiDung : Form
    {
        public frmQuanLyNguoiDung()
        {
            InitializeComponent();

        }

        public frmQuanLyNguoiDung(Login acc)
        {
            InitializeComponent();
            loadData();

            cboQuyen.DisplayMember = "Text";
            cboQuyen.ValueMember = "Value";
            cboQuyen.Items.Add(new { Text = "SV", Value = "SV" });
            cboQuyen.Items.Add(new { Text = "GV", Value = "GV" });
            cboQuyen.Items.Add(new { Text = "Admin", Value = "Admin" });
            cboQuyen.SelectedIndex = 0;

        }

        private void loadData()
        {
            dgrLogin.DataSource = ListLogin.getAllLogin();
        }
        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {

        }

        List<Login> listLogin = ListLogin.getAllLogin();
        private Boolean checkthemmoi = false;
        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            if (validate() != "")
            {
                MessageBox.Show(validate());
            }
            else
            {
                try
                {
                    foreach (Login account in listLogin)
                    {

                        if (account.TenDN.Equals(txtTaikhoan.Text))
                        {
                            checkthemmoi = true;
                            MessageBox.Show("Tài khoản " + txtTaikhoan.Text + " đã tồn tại", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        if (account.MaSo.Equals(txtMaSo.Text))
                        {
                            checkthemmoi = true;
                            MessageBox.Show("Mã số " + txtMaSo.Text + " đã tồn tại", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }

                    if (checkthemmoi == false)
                    {
                        int count = LoginDAO.InsertLogin(txtTaikhoan.Text, txtMK.Text, txtHoTen.Text, txtMaSo.Text, cboQuyen.Text);
                        if (count > 0)
                        {
                            MessageBox.Show("Thêm mới tài khoản thành công!", "Thông báo!");
                        }
                        else
                        {
                            MessageBox.Show("Thêm mới tài khoản thất bại!", "Thông báo!");
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Thêm mới tài khoản thất bại!", "Thông báo!");
                }
            }

            loadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (validate() != "")
            {
                MessageBox.Show(validate());
            }
            else
            {
                int count = LoginDAO.UpdateLogin(txtTaikhoan.Text, txtMK.Text, txtHoTen.Text, txtMaSo.Text, cboQuyen.Text, txtMaSo.Text);
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




        private void dgrLogin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTaikhoan.Text = dgrLogin.CurrentRow.Cells[0].Value.ToString();
            txtMK.Text = dgrLogin.CurrentRow.Cells[1].Value.ToString();
            txtHoTen.Text = dgrLogin.CurrentRow.Cells[2].Value.ToString();
            txtMaSo.Text = dgrLogin.CurrentRow.Cells[3].Value.ToString();
            cboQuyen.Text = dgrLogin.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                int count = LoginDAO.DeleteLogin(txtMaSo.Text);
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");
                loadData();
            }
        }

        private string validate()
        {
            string msgErr = "";

            if (txtTaikhoan.Text.Trim() == "")
            {
                msgErr = "Tên tài khoản trống!";
            }
            if (txtMK.Text.Trim() == "")
            {
                msgErr = "\n Mật khẩu trống!";
            }
            if (txtHoTen.Text.Trim() == "")
            {
                msgErr += "\n Họ tên mới trống";
            }

            if (txtMaSo.Text.Trim() == "")
            {
                msgErr += "\n Mã số trống";
            }
            return msgErr;
        }
    }
}
