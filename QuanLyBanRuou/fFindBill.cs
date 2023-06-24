using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanRuou
{
    public partial class fFindBill : Form
    {
        QLBREntities db = new QLBREntities();
        public fFindBill()
        {
            InitializeComponent();
        }

        #region method
        void resetText()
        {
            txtIdBill.Text = "";
            txtIdEmployee.Text = "";
            txtDate.Text = "";
            txtKhvNcc.Text = "";
            txtSumPrice.Text = "";
            txtIdPro.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
            txtDiscount.Text = "";
            txtTotalPrice.Text = "";
        }

        void resetFindText()
        {
            txtFindID.Text = "";
            txtFindNccvKh.Text = "";
            dtpDate.Text = "";
        }

        void showDetail(Boolean show)
        {
            txtIdBill.Enabled = show;
            txtIdEmployee.Enabled = show;
            txtDate.Enabled = show;
            txtKhvNcc.Enabled = show;
            txtSumPrice.Enabled = show;
            txtIdPro.Enabled = show;
            txtQuantity.Enabled = show;
            txtPrice.Enabled = show;
            txtDiscount.Enabled = show;
            txtTotalPrice.Enabled = show;
        }

        void showFindDetail(Boolean show)
        {
            txtFindID.Enabled = show;
            txtFindNccvKh.Enabled = show;
            dtpDate.Enabled = show;
            btnEdit.Enabled = show;
            btnFind.Enabled = show;
        }

        void LoadDataHDBan()
        {
            var res = (from b in db.HoaDonBans
                       join c in db.ChiTietHoaDonBans on b.sohdb equals c.sohdb
                       select new
                       {
                           sohdb = b.sohdb,
                           manhanvien = b.manhanvien,
                           ngayban = b.ngayban,
                           makhach = b.makhach,
                           tongtien = b.tongtien,
                           mahang = c.mahang,
                           soluong = c.soluong,
                           dongia = c.dongia,
                           giamgia = c.giamgia,
                           thanhtien = c.thanhtien
                       }).Select(x => x);
            dgvResult.DataSource = res.ToList();
        }

        void LoadDataHDNhap()
        {
            var res = (from n in db.HoaDonNhaps
                       join c in db.ChiTietHoaDonNhaps on n.sohdn equals c.sohdn
                       select new
                       {
                           sohdn = n.sohdn,
                           manhanvien = n.manhanvien,
                           ngaynhap = n.ngaynhap,
                           mancc = n.mancc,
                           tongtien = n.tongtien,
                           mahang = c.mahang,
                           soluong = c.soluong,
                           dongia = c.dongia,
                           giamgia = c.giamgia,
                           thanhtien = c.thanhtien
                       }).Select(x => x);
            dgvResult.DataSource = res.ToList();
        }

        void setNameDgvHDNhap()
        {
            dgvResult.Columns[0].HeaderText = "Số HĐN";
            dgvResult.Columns[0].DataPropertyName = "sohdn";
            dgvResult.Columns[2].HeaderText = "Ngày nhập";
            dgvResult.Columns[2].DataPropertyName = "ngaynhap";
            dgvResult.Columns[3].HeaderText = "Mã nhà cung cấp";
            dgvResult.Columns[3].DataPropertyName = "mancc";
        }

        void setNameDgvHDBan()
        {
            dgvResult.Columns[0].HeaderText = "Số HĐB";
            dgvResult.Columns[0].DataPropertyName = "sohdb";
            dgvResult.Columns[2].HeaderText = "Ngày bán";
            dgvResult.Columns[2].DataPropertyName = "ngayban";
            dgvResult.Columns[3].HeaderText = "Mã khách";
            dgvResult.Columns[3].DataPropertyName = "makhach";
        }

        #endregion

        private void fFindBill_Load(object sender, EventArgs e)
        {
            btnImportBill.Enabled = true;
            btnSaleBill.Enabled = true;
            showDetail(false);
            showFindDetail(false);
        }

        private void btnTypeBills_Click(object sender, EventArgs e)
        {
            btnImportBill.Enabled = true;
            btnSaleBill.Enabled = true;
            resetFindText();
            resetText();
            lblTitle.Text = "Tìm kiếm hóa đơn";
            lblDate.Text = lblFindDate.Text = "Ngày B/N";
            lblNCCvKH.Text = lblFindNCCvKH.Text = "Mã Ncc/Kh";
            showDetail(false);
            showFindDetail(false);
        }

        private void btnSaleBill_Click(object sender, EventArgs e)
        {
            btnImportBill.Enabled = false;
            showFindDetail(true);
            lblTitle.Text = "Tìm kiếm hóa đơn bán";
            resetText();
            resetFindText();
            setNameDgvHDBan();
            lblDate.Text = lblFindDate.Text = "Ngày bán";
            lblNCCvKH.Text = lblFindNCCvKH.Text = "Mã khách";
            LoadDataHDBan();
        }

        private void btnImportBill_Click(object sender, EventArgs e)
        {
            btnSaleBill.Enabled = false;
            showFindDetail(true);
            lblTitle.Text = "Tìm kiếm hóa đơn nhập";
            grbTypeBill.Text = "Chi tiết hóa đơn nhập";
            resetText();
            resetFindText();
            setNameDgvHDNhap();
            lblDate.Text = lblFindDate.Text = "Ngày nhập";
            lblNCCvKH.Text = lblFindNCCvKH.Text = "Mã NCC";
            LoadDataHDNhap();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtIdBill.Text != "")
            { 
                showDetail(true);
            }
        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvResult.CurrentRow.Selected = true;
                txtIdBill.Text = dgvResult.CurrentRow.Cells[0].Value.ToString();
                txtIdEmployee.Text = dgvResult.CurrentRow.Cells[1].Value.ToString();
                txtDate.Text = dgvResult.CurrentRow.Cells[2].Value.ToString();
                txtKhvNcc.Text = dgvResult.CurrentRow.Cells[3].Value.ToString();
                txtSumPrice.Text = dgvResult.CurrentRow.Cells[4].Value.ToString();
                txtIdPro.Text = dgvResult.CurrentRow.Cells[5].Value.ToString();
                txtQuantity.Text = dgvResult.CurrentRow.Cells[6].Value.ToString();
                txtPrice.Text = dgvResult.CurrentRow.Cells[7].Value.ToString();
                txtDiscount.Text = dgvResult.CurrentRow.Cells[8].Value.ToString();
                txtTotalPrice.Text = dgvResult.CurrentRow.Cells[9].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(btnImportBill.Enabled == true)
            {
                setNameDgvHDNhap();
                if (txtFindID.Text == "" && txtFindNccvKh.Text == "")
                {
                    var res = (from n in db.HoaDonNhaps
                               join c in db.ChiTietHoaDonNhaps on n.sohdn equals c.sohdn
                               select new
                               {
                                   sohdn = n.sohdn,
                                   manhanvien = n.manhanvien,
                                   ngaynhap = n.ngaynhap,
                                   mancc = n.mancc,
                                   tongtien = n.tongtien,
                                   mahang = c.mahang,
                                   soluong = c.soluong,
                                   dongia = c.dongia,
                                   giamgia = c.giamgia,
                                   thanhtien = c.thanhtien
                               }).Where(n => n.ngaynhap == dtpDate.Value.Date);
                    dgvResult.DataSource = res.ToList();
                }
                else if (txtFindID.Text.Trim() != "")
                {
                    var res = (from n in db.HoaDonNhaps
                               join c in db.ChiTietHoaDonNhaps on n.sohdn equals c.sohdn
                               select new
                               {
                                   sohdn = n.sohdn,
                                   manhanvien = n.manhanvien,
                                   ngaynhap = n.ngaynhap,
                                   mancc = n.mancc,
                                   tongtien = n.tongtien,
                                   mahang = c.mahang,
                                   soluong = c.soluong,
                                   dongia = c.dongia,
                                   giamgia = c.giamgia,
                                   thanhtien = c.thanhtien
                               }).Where(n => n.ngaynhap == dtpDate.Value.Date && n.mahang == txtFindID.Text);
                    dgvResult.DataSource = res.ToList();
                }
                else if(txtFindNccvKh.Text.Trim() != "")
                {
                    var res = (from n in db.HoaDonNhaps
                               join c in db.ChiTietHoaDonNhaps on n.sohdn equals c.sohdn
                               select new
                               {
                                   sohdn = n.sohdn,
                                   manhanvien = n.manhanvien,
                                   ngaynhap = n.ngaynhap,
                                   mancc = n.mancc,
                                   tongtien = n.tongtien,
                                   mahang = c.mahang,
                                   soluong = c.soluong,
                                   dongia = c.dongia,
                                   giamgia = c.giamgia,
                                   thanhtien = c.thanhtien
                               }).Where(x => x.ngaynhap == dtpDate.Value.Date && x.mancc == txtFindNccvKh.Text);
                    dgvResult.DataSource = res.ToList();
                }
                else if(txtFindID.Text.Trim() != "" && txtFindNccvKh.Text.Trim() != "")
                {
                    var res = (from n in db.HoaDonNhaps
                               join c in db.ChiTietHoaDonNhaps on n.sohdn equals c.sohdn
                               select new
                               {
                                   sohdn = n.sohdn,
                                   manhanvien = n.manhanvien,
                                   ngaynhap = n.ngaynhap,
                                   mancc = n.mancc,
                                   tongtien = n.tongtien,
                                   mahang = c.mahang,
                                   soluong = c.soluong,
                                   dongia = c.dongia,
                                   giamgia = c.giamgia,
                                   thanhtien = c.thanhtien
                               }).Where(x => x.ngaynhap == dtpDate.Value.Date && x.mahang == txtFindNccvKh.Text && x.mancc == txtFindNccvKh.Text);
                    dgvResult.DataSource = res.ToList();
                }
                else
                {
                    LoadDataHDNhap();
                }

            }
            if(btnSaleBill.Enabled == true)
            {
                setNameDgvHDBan();
                if (txtFindID.Text == "" && txtFindNccvKh.Text == "")
                {
                    var res = (from b in db.HoaDonBans
                               join c in db.ChiTietHoaDonBans on b.sohdb equals c.sohdb
                               select new
                               {
                                   sohdb = b.sohdb,
                                   manhanvien = b.manhanvien,
                                   ngayban = b.ngayban,
                                   makhach = b.makhach,
                                   tongtien = b.tongtien,
                                   mahang = c.mahang,
                                   soluong = c.soluong,
                                   dongia = c.dongia,
                                   giamgia = c.giamgia,
                                   thanhtien = c.thanhtien
                               }).Where(x => x.ngayban == dtpDate.Value.Date);
                    dgvResult.DataSource = res.ToList();
                }
                else if (txtFindID.Text.Trim() != "")
                {
                    var res = (from b in db.HoaDonBans
                               join c in db.ChiTietHoaDonBans on b.sohdb equals c.sohdb
                               select new
                               {
                                   sohdb = b.sohdb,
                                   manhanvien = b.manhanvien,
                                   ngayban = b.ngayban,
                                   makhach = b.makhach,
                                   tongtien = b.tongtien,
                                   mahang = c.mahang,
                                   soluong = c.soluong,
                                   dongia = c.dongia,
                                   giamgia = c.giamgia,
                                   thanhtien = c.thanhtien
                               }).Where(x => x.ngayban == dtpDate.Value.Date && x.mahang == txtFindID.Text.Trim());
                    dgvResult.DataSource = res.ToList();
                }
                else if (txtFindNccvKh.Text.Trim() != "")
                {
                    var res = (from b in db.HoaDonBans
                               join c in db.ChiTietHoaDonBans on b.sohdb equals c.sohdb
                               select new
                               {
                                   sohdb = b.sohdb,
                                   manhanvien = b.manhanvien,
                                   ngayban = b.ngayban,
                                   makhach = b.makhach,
                                   tongtien = b.tongtien,
                                   mahang = c.mahang,
                                   soluong = c.soluong,
                                   dongia = c.dongia,
                                   giamgia = c.giamgia,
                                   thanhtien = c.thanhtien
                               }).Where(x => x.ngayban == dtpDate.Value.Date && x.makhach == txtFindNccvKh.Text.Trim());
                    dgvResult.DataSource = res.ToList();
                }
                else if (txtFindID.Text.Trim() != "" && txtFindNccvKh.Text.Trim() != "")
                {
                    var res = (from b in db.HoaDonBans
                               join c in db.ChiTietHoaDonBans on b.sohdb equals c.sohdb
                               select new
                               {
                                   sohdb = b.sohdb,
                                   manhanvien = b.manhanvien,
                                   ngayban = b.ngayban,
                                   makhach = b.makhach,
                                   tongtien = b.tongtien,
                                   mahang = c.mahang,
                                   soluong = c.soluong,
                                   dongia = c.dongia,
                                   giamgia = c.giamgia,
                                   thanhtien = c.thanhtien
                               }).Where(x => x.makhach == txtFindNccvKh.Text.Trim() && x.makhach == txtFindNccvKh.Text.Trim() && x.ngayban == dtpDate.Value.Date);
                    dgvResult.DataSource = res.ToList();
                }
                else
                {
                    LoadDataHDBan();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }
    }
}
