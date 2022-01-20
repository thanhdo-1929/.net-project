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
    public partial class frmTimDiemSV : Form
    {
        private List<SinhVien> listSinhVien = ListSinhVien.getAllSinhVien();
        private List<KetQua> listKetQua = ListKetQua.getAllKetQua();
        private List<Lop> listLop = ListLop.getAllLop();
        private List<Khoa> listKhoa = ListKhoa.getAllKhoa();

        public frmTimDiemSV()
        {
            InitializeComponent();
        }
        public frmTimDiemSV(Login acc)
        {
            InitializeComponent();

            cboKhoa.DisplayMember = "MaKhoa";
            cboKhoa.ValueMember = "MaKhoa";
            cboKhoa.DataSource = ListKhoa.getAllKhoa();
            cboKhoa.SelectedIndex = 0;


            cboMonHoc.DisplayMember = "MaMon";
            cboMonHoc.ValueMember = "MaMon";
            cboMonHoc.DataSource = ListMon.getAllMon();
            cboMonHoc.SelectedIndex = 0;
            loadData();
        }
        private void frmTimDiemSV_Load(object sender, EventArgs e)
        {

        }

        private void loadData()
        {
            dgrDIEMSV.DataSource = ListKetQua.getAllKetQua();
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoa.SelectedValue != null)
            {
                cboMonHoc.DisplayMember = "MaMon";
                cboMonHoc.ValueMember = "MaMon";
                cboMonHoc.DataSource = DAO.GetDataBySQL("SELECT * FROM dbo.tblMon WHERE MaKhoa = '" + cboKhoa.SelectedValue.ToString() + "'");
            }

        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            dgrDIEMSV.DataSource = DAO.GetDataBySQL("SELECT * FROM [dbo].[tblKET_QUA] WHERE MaSV LIKE '%" + txtMaSV.Text + "%' and MaMon='" + cboMonHoc.SelectedValue.ToString() + "'");
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonHoc.SelectedValue != null)
            {
                dgrDIEMSV.DataSource = DAO.GetDataBySQL("SELECT * FROM [dbo].[tblKET_QUA] WHERE  MaMon='"+cboMonHoc.SelectedValue+"'");
            }
            
        }
    }
}
