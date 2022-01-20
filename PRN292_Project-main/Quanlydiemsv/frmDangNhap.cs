using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quanlydiemsv.Logic;

namespace Quanlydiemsv
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public frmDangNhap(Login acc)
        {
            InitializeComponent();
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtTenDN.Text = "admin";
            txtMatKhau.Text = "123";
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            List<Login> listLogin = ListLogin.getAllLogin();
            string tendn = txtTenDN.Text.ToString();
            string matkhau = txtMatKhau.Text.ToString();
            Boolean checkDangnhap = false;

            foreach (Login account in listLogin)
            {
                if (account.TenDN.Equals(tendn) && account.MatKhau.Equals(matkhau))
                {
                    MessageBox.Show("Đăng nhập vào hệ thống !", "Thông báo !");
                    frmMain frm = new frmMain(account);
                    if (account.Quyen.Equals("SV"))
                    {
                        frm.quảnLíNgườiDùngToolStripMenuItem.Enabled = false;
                        frm.menuDanhmuc.Enabled = false;
                        frm.quảnLíToolStripMenuItem.Enabled = false;
                    }
                    if (account.Quyen.Equals("GV"))
                    {
                        frm.quảnLíNgườiDùngToolStripMenuItem.Enabled = false;
                        frm.menuDanhmuc.Enabled = false;
                        frm.sinhViênToolStripMenuItem.Enabled = false;
                        frm.giảngViênToolStripMenuItem.Enabled = false;
                    }
                   
                    frm.Show();
                    this.Hide();
                    checkDangnhap = true;
                }
            }
            if (checkDangnhap == false)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai !");
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
