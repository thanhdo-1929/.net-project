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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        public frmDoiMatKhau(Login acount)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validate() != "")
            {
                MessageBox.Show(validate());
            }
            else
            {
                List<Login> listLogin = ListLogin.getAllLogin();

                string tendn = txtTaikhoan.Text.ToString();
                string matkhau = txtMKcu.Text.ToString();
                Boolean checkDoiMatKhau = false;

                foreach (Login log in listLogin)
                {
                    if (log.TenDN.Equals(tendn) && log.MatKhau.Equals(matkhau))
                    {

                        int count = LoginDAO.UpdateLogin(tendn, txtMKmoi.Text, log.HoTen, log.MaSo, log.Quyen, log.MaSo);
                        if (count > 0)
                        {
                            MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTaikhoan.ResetText();
                            txtMKcu.ResetText();
                            txtMKmoi.ResetText();
                            txtConfimMk.ResetText();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật dữ liệu thất bại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        checkDoiMatKhau = true;
                    }
                }
                if (checkDoiMatKhau == false)
                {
                    MessageBox.Show("Tên tài khoản không tồn tại hoặc mật khẩu sai! ", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string validate()
        {
            string msgErr = "";

            if (txtTaikhoan.Text.Trim() == "")
            {
                msgErr = "Tên tài khoản trống!";
            }
            if (txtMKcu.Text.Trim() == "")
            {
                msgErr = "\n Mật khẩu cũ trống!";
            }
            if (txtMKmoi.Text.Trim() == "")
            {
                msgErr += "\n Mật khẩu mới trống";
            }

            if (txtConfimMk.Text.Trim() == "")
            {
                msgErr += "\n Đánh lại mật khẩu trống";
            }

            if (txtMKmoi.Text.Trim() != txtConfimMk.Text.Trim())
            {
                msgErr += "\n Bạn nhập lại mật khẩu không trùng khớp!";
            }

            return msgErr;
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
