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
    public partial class frmMonHoc : Form
    {
        public frmMonHoc()
        {
            InitializeComponent();
        }
        public frmMonHoc(Login acc)
        {
            InitializeComponent();
        }
        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            loadData();

            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
            cboKhoa.DataSource = ListKhoa.getAllKhoa();
            cboKhoa.SelectedIndex = 0;

            cboGV.DisplayMember = "TenGV";
            cboGV.ValueMember = "MaGV";
            cboGV.DataSource = ListGiangVien.getAllGiangVien();
            cboGV.SelectedIndex = 0;
        }
        private void loadData()
        {
            dgrMON.DataSource = ListMon.getAllMon();
        }

        private void dgrMON_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaMon.Text = dgrMON.CurrentRow.Cells[0].Value.ToString();
            txtTenMon.Text = dgrMON.CurrentRow.Cells[1].Value.ToString();
            cboGV.Text = dgrMON.CurrentRow.Cells[2].Value.ToString();
            txtHocKy.Text = dgrMON.CurrentRow.Cells[3].Value.ToString();
            cboKhoa.Text = dgrMON.CurrentRow.Cells[4].Value.ToString();
        }
        private List<Mon> listMon = ListMon.getAllMon();
        private List<KetQua> listKetQua = ListKetQua.getAllKetQua();
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
                    foreach (Mon list in listMon)
                    {
                        if (txtMaMon.Text.Equals(list.MaMon))
                        {
                            tontai = true;
                            MessageBox.Show("Môn học đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }

                    if (tontai == false)
                    {
                        int count = MonDAO.InsertMon(txtMaMon.Text, txtTenMon.Text, cboGV.SelectedValue.ToString(), txtHocKy.Text, cboKhoa.SelectedValue.ToString());
                        if (count > 0)
                        {
                            MessageBox.Show("Thêm môn học thành công!", "Thông báo!");
                        }
                        else
                        {
                            MessageBox.Show("Thêm môn học thất bại!", "Thông báo!");
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString(), "Thông báo!");
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
                int count = MonDAO.UpdateMon(txtMaMon.Text, txtTenMon.Text, cboGV.SelectedValue.ToString(), txtHocKy.Text, cboKhoa.SelectedValue.ToString(), dgrMON.CurrentRow.Cells[0].Value.ToString());
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

            foreach (KetQua list in listKetQua)
            {
                if (txtMaMon.Text.Equals(list.MaMon))
                {
                    checkdelete = true;
                    MessageBox.Show("Bạn phải xóa Mã môn " + txtMaMon.Text + "từ bảng Kết quả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }

            if (checkdelete == false)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int count = MonDAO.DeleteMonHoc(txtMaMon.Text);
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

            if (txtMaMon.Text.Trim() == "")
            {
                msgErr = "Mã môn trống!";
            }
            if (txtTenMon.Text.Trim() == "")
            {
                msgErr = "\n Tên môn trống!";
            }

            if (int.Parse(txtHocKy.Text.Trim()) < 1 || int.Parse(txtHocKy.Text.Trim()) > 9)
            {
                msgErr = "\n Học kì chỉ được nhập từ 1 đến 9";
            }

            if (txtHocKy.Text.Trim() == "")
            {
                msgErr += "\n Học kỳ trống";
            }

            return msgErr;
        }
    }
}
