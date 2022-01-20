using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quanlydiemsv.Logic;

namespace Quanlydiemsv
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Login acount = null;
        public frmMain(Login acc)
        {
            InitializeComponent();
            acount = acc;

            
            
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
           
        }
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(acount);
            frm.Show();
        }

        private void quảnLíNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyNguoiDung frm = new frmQuanLyNguoiDung(acount);
            frm.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap(acount);
            this.Hide();
            frm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonHoc frm = new frmMonHoc(acount);
            
            frm.Show();
        }

        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhoa frm = new frmKhoa(acount);
            frm.Show();
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLop frm = new frmLop(acount);
            frm.Show();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLSV frm = new frmQLSV(acount);
            frm.Show();
        }
        private void giảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGiangVien frm = new frmGiangVien(acount);
            frm.Show();
        }
        private void điểmMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLDiem frm = new frmQLDiem(acount);
            frm.Show();
        }

        private void thôngTinSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimDiemSV frm = new frmTimDiemSV(acount);
            frm.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
