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
    public partial class frmLop : Form
    {
        public frmLop()
        {
            InitializeComponent();
        }

        public frmLop(Login acc)
        {
            InitializeComponent();
        }

        private void frmLop_Load_1(object sender, EventArgs e)
        {
            loadData();

            cboKhoa.DisplayMember = "MaKhoa";
            cboKhoa.ValueMember = "MaKhoa";
            cboKhoa.DataSource = ListKhoa.getAllKhoa();
            cboKhoa.SelectedIndex = 0;
        }

        private List<Lop> listLop = ListLop.getAllLop();
        private List<SinhVien> listSinhVien = ListSinhVien.getAllSinhVien();

        private void loadData()
        {
            dgrLop.DataSource = ListLop.getAllLop();
        }

        private void dgrLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cboKhoa.Text = dgrLop.CurrentRow.Cells[0].Value.ToString();
            txtMaLop.Text = dgrLop.CurrentRow.Cells[1].Value.ToString();
            txtTenlop.Text = dgrLop.CurrentRow.Cells[2].Value.ToString();

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
                    foreach (Lop list in listLop)
                    {
                        if (txtMaLop.Text.Equals(list.MaLop))
                        {
                            tontai = true;
                            MessageBox.Show("Mã lớp đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                    if (tontai == false)
                    {
                        int count = LopDAO.InsertLop(cboKhoa.SelectedValue.ToString(), txtMaLop.Text, txtTenlop.Text);
                        if (count > 0)
                        {
                            MessageBox.Show("Thêm lớp học thành công!", "Thông báo!");
                        }
                        else
                        {
                            MessageBox.Show("Thêm lớp học thất bại!", "Thông báo!");
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Thêm lớp học thất bại!", "Thông báo!");
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
                int count = LopDAO.UpdateLop(cboKhoa.SelectedValue.ToString(), txtMaLop.Text, txtTenlop.Text, dgrLop.CurrentRow.Cells[1].Value.ToString());
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
        private Boolean checkdelete = false;
        private void button3_Click_1(object sender, EventArgs e)
        {
            foreach (SinhVien list in listSinhVien)
            {
                if (txtMaLop.Text.Equals(list.MaLop))
                {
                    checkdelete = true;
                    MessageBox.Show("Bạn phải xóa Mã Lớp " + txtMaLop.Text + " từ bảng Sinh Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            if (checkdelete == false)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int count = LopDAO.DeleteLop(txtMaLop.Text);
                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");
                    loadData();
                }
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        private string validate()
        {
            string msgErr = "";

            if (txtMaLop.Text.Trim() == "")
            {
                msgErr = "Mã lớp trống!";
            }
            if (txtTenlop.Text.Trim() == "")
            {
                msgErr = "\n Tên lớp trống!";
            }
            return msgErr;
        }


    }
}
