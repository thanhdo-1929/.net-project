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
    public partial class frmKhoa : Form
    {
        public frmKhoa()
        {
            InitializeComponent();
        }

        public frmKhoa(Login acc)
        {
            InitializeComponent();
        }

        private void frmKhoa_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            dgrKhoa.DataSource = ListKhoa.getAllKhoa();
        }

        private void dgrMON_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKhoa.Text = dgrKhoa.CurrentRow.Cells[0].Value.ToString();
            txtTenKhoa.Text = dgrKhoa.CurrentRow.Cells[1].Value.ToString();
        }

        private List<Khoa> listKhoa = ListKhoa.getAllKhoa();
        private List<Lop> listLop = ListLop.getAllLop();

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
                    foreach (Khoa list in listKhoa)
                    {
                        if (txtMaKhoa.Text.Equals(list.MaKhoa))
                        {
                            tontai = true;
                            MessageBox.Show("Mã khoa đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }

                    if (tontai == false)
                    {
                        int count = KhoaDAO.InsertKhoa(txtMaKhoa.Text, txtTenKhoa.Text);
                        if (count > 0)
                        {
                            MessageBox.Show("Thêm khoa thành công!", "Thông báo!");

                        }
                        else
                        {
                            MessageBox.Show("Thêm khoa thất bại!", "Thông báo!");
                        }

                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Thêm khoa thất bại!", "Thông báo!");
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
                int count = KhoaDAO.UpdateKhoa(txtMaKhoa.Text, txtTenKhoa.Text, dgrKhoa.CurrentRow.Cells[0].Value.ToString());
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
            foreach (Lop Lop in listLop)
            {
                if (Lop.MaKhoa.Equals(txtMaKhoa.Text))
                {
                    checkdelete = true;
                    MessageBox.Show("Bạn phải xóa Mã Khoa " + txtMaKhoa.Text + " từ bảng Lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }

            if (checkdelete == false)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int count = KhoaDAO.DeleteKhoa(txtMaKhoa.Text);
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

            if (txtMaKhoa.Text.Trim() == "")
            {
                msgErr = "Mã khoa trống!";
            }
            if (txtTenKhoa.Text.Trim() == "")
            {
                msgErr = "\n Tên khoa trống!";
            }

            return msgErr;
        }

    }
}
