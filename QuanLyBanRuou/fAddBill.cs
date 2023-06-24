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
    public partial class fAddBill : Form
    {
        MyClass _class = new MyClass("");
        QLBREntities db = new QLBREntities();
        public fAddBill()
        {
            InitializeComponent();
        }

        #region methods

        void resetText()
        {
            txtIDBill.Text = "";
            txtIDEmployee.Text = "";
            dtpDate.Value = DateTime.Now;
            txtIDNccvKh.Text = "";
            txtSumPrice.Text = "";
            txtIDPro.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
            txtDiscount.Text = "";
            txtTotalPrice.Text = "";
        }

        void showDetail(bool show)
        {
            txtIDBill.Enabled = show;
            txtIDEmployee.Enabled = show;
            dtpDate.Enabled = show;
            txtIDNccvKh.Enabled = show;
            txtSumPrice.Enabled = show;
            txtIDPro.Enabled = show;
            txtQuantity.Enabled = show;
            txtPrice.Enabled = show;
            txtDiscount.Enabled = show;
            txtTotalPrice.Enabled = show;
            btnSubmit.Enabled = show;
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
            dgvCheck.DataSource = res.ToList();
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
            dgvCheck.DataSource = res.ToList();
        }

        void AddHDNhap()
        {
            db.HoaDonNhaps.Add(new HoaDonNhap()
            {
                sohdn = txtIDBill.Text,
                manhanvien = txtIDEmployee.Text,
                ngaynhap = dtpDate.Value,
                mancc = txtIDNccvKh.Text,
                tongtien = double.Parse(txtSumPrice.Text)
            });
            db.SaveChanges();
            db.ChiTietHoaDonNhaps.Add(new ChiTietHoaDonNhap()
            {
                sohdn = txtIDBill.Text,
                mahang = txtIDPro.Text,
                soluong = Int32.Parse(txtQuantity.Text),
                dongia = double.Parse(txtPrice.Text),
                giamgia = double.Parse(txtDiscount.Text),
                thanhtien = double.Parse(txtTotalPrice.Text),
            });
            db.SaveChanges();
            LoadDataHDNhap();
        }

        void AddHDBan()
        {
            db.HoaDonBans.Add(new HoaDonBan()
            {
                sohdb = txtIDBill.Text,
                manhanvien = txtIDEmployee.Text,
                ngayban = dtpDate.Value,
                makhach = txtIDNccvKh.Text,
                tongtien = double.Parse(txtSumPrice.Text)
            });
            db.SaveChanges();
            db.ChiTietHoaDonBans.Add(new ChiTietHoaDonBan()
            {
                sohdb = txtIDBill.Text,
                mahang = txtIDPro.Text,
                soluong = Int32.Parse(txtQuantity.Text),
                dongia = double.Parse(txtPrice.Text),
                giamgia = double.Parse(txtDiscount.Text),
                thanhtien = double.Parse(txtTotalPrice.Text),
            });
            db.SaveChanges();
            LoadDataHDBan();
        }

        void deleteImportBill()
        {
            HoaDonNhap hdn = db.HoaDonNhaps.Find(txtIDBill.Text);
            db.HoaDonNhaps.Remove(hdn);
            db.SaveChanges();
            ChiTietHoaDonNhap cthdn = db.ChiTietHoaDonNhaps.Find(txtIDBill.Text);
            db.ChiTietHoaDonNhaps.Remove(cthdn);
            db.SaveChanges();
            LoadDataHDNhap();
        }

        void deleteSellBill()
        {
            HoaDonBan hdb = db.HoaDonBans.Find(txtIDBill.Text);
            db.HoaDonBans.Remove(hdb);
            db.SaveChanges();
            ChiTietHoaDonBan cthdb = db.ChiTietHoaDonBans.Find(txtIDBill.Text);
            db.ChiTietHoaDonBans.Remove(cthdb);
            db.SaveChanges();
            LoadDataHDBan();
        }

        #endregion
        private void fAddBill_Load(object sender, EventArgs e)
        {
            showDetail(false);
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            btnSellBill.Enabled = true;
            btnImportBill.Enabled = true;
            lblTitle.Text = "Thêm hóa đơn";
            showDetail(false);
            resetText();
        }

        private void btnImportBill_Click(object sender, EventArgs e)
        {
            showDetail(true);
            btnSellBill.Enabled = false;
            lblTitle.Text = "Thêm hóa đơn nhập";
            grbBillTitle.Text = "Chi tiết hóa đơn nhập";
            resetText();
            dgvCheck.Columns[0].HeaderText = "Số HĐN";
            dgvCheck.Columns[0].DataPropertyName = "sohdn";
            dgvCheck.Columns[2].HeaderText = "Ngày nhập";
            dgvCheck.Columns[2].DataPropertyName = "ngaynhap";
            dgvCheck.Columns[3].HeaderText = "Mã nhà cung cấp";
            dgvCheck.Columns[3].DataPropertyName = "mancc";
            lblDate.Text = "Ngày nhập";
            lblNCCvKH.Text = "Mã NCC";
            LoadDataHDNhap();
            txtSumPrice.Enabled = false;
            txtTotalPrice.Enabled = false;
        }

        private void btnSellBill_Click(object sender, EventArgs e)
        {
            showDetail(true);
            btnImportBill.Enabled = false;
            lblTitle.Text = "Thêm hóa đơn bán";
            grbBillTitle.Text = "Chi tiết hóa đơn bán";
            resetText();
            dgvCheck.Columns[0].HeaderText = "Số HĐB";
            dgvCheck.Columns[0].DataPropertyName = "sohdb";
            dgvCheck.Columns[2].HeaderText = "Ngày bán";
            dgvCheck.Columns[2].DataPropertyName = "ngayban";
            dgvCheck.Columns[3].HeaderText = "Mã khách";
            dgvCheck.Columns[3].DataPropertyName = "makhach";
            lblDate.Text = "Ngày bán";
            lblNCCvKH.Text = "Mã khách";
            LoadDataHDBan();
            txtPrice.Enabled = false;
            txtSumPrice.Enabled = false;
            txtTotalPrice.Enabled = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtIDBill.Text.Trim() == "")
            {
                errDetail.SetError(txtIDBill, "Bạn không được để trống mã hóa đơn");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (txtIDEmployee.Text.Trim() == "")
            {
                errDetail.SetError(txtIDEmployee, "Bạn không được để trống mã nhân viên");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (txtQuantity.Text.Trim() == "")
            {
                errDetail.SetError(txtQuantity, "Bạn phải nhập số lượng sản phẩm");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (txtDiscount.Text.Trim() == "")
            {
                errDetail.SetError(txtDiscount, "Bạn phải nhập số tiền giảm giá");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (btnImportBill.Enabled == true)
            {
                if(txtIDNccvKh.Text.Trim() == "")
                {
                    errDetail.SetError(txtIDNccvKh, "Bạn không được để trống mã nhà cung cấp");
                    return;
                }
                else
                {
                    errDetail.Clear();
                }
                if (txtPrice.Text.Trim() == "")
                {
                    errDetail.SetError(txtPrice, "Bạn phải nhập đơn giá");
                    return;
                }
                else
                {
                    errDetail.Clear();
                }
                DMHangHoa hh = db.DMHangHoas.Find(txtIDPro.Text);
                if(hh != null)
                {
                    txtTotalPrice.Text = (Int32.Parse(txtQuantity.Text) * Int32.Parse(txtPrice.Text) - Int32.Parse(txtDiscount.Text)).ToString();
                    txtSumPrice.Text = (Int32.Parse(txtQuantity.Text) * Int32.Parse(txtPrice.Text)).ToString();
                    hh.dongianhap = Int32.Parse(txtPrice.Text);
                    hh.dongiaban = Int32.Parse(txtPrice.Text)*1.1;
                    hh.soluong += Int32.Parse(txtQuantity.Text);
                    AddHDNhap();
                    db.SaveChanges();
                    resetText();
                }
                if(hh == null)
                {
                    errDetail.SetError(txtIDPro, "Mã sản phẩm không tồn tại");
                    return;
                }
                else
                {
                    errDetail.Clear();
                }
            }
            if(btnSellBill.Enabled == true)
            {
                DMHangHoa hh = db.DMHangHoas.Find(txtIDPro.Text); 
                if(hh != null)
                {
                    txtPrice.Text = hh.dongiaban.ToString();
                    txtTotalPrice.Text = (Int32.Parse(txtQuantity.Text)*Int32.Parse(txtPrice.Text) - Int32.Parse(txtDiscount.Text)).ToString();
                    txtSumPrice.Text = (Int32.Parse(txtQuantity.Text) * Int32.Parse(txtPrice.Text)).ToString();
                    if (hh.soluong >= Int32.Parse(txtQuantity.Text))
                    {
                        hh.soluong -= Int32.Parse(txtQuantity.Text);
                        AddHDBan();
                        db.SaveChanges();
                        resetText();
                    }
                    else if(hh.soluong < Int32.Parse(txtQuantity.Text))
                    {
                        errDetail.SetError(txtQuantity, "Số lượng sản phẩm còn lại trong kho không đủ");
                        return;
                    }
                    else
                    {
                        errDetail.Clear();
                    }
                }
                else if(hh == null)
                {
                    errDetail.SetError(txtIDPro, "Mã sản phẩm không tồn tại");
                    return;
                }
                else
                {
                    errDetail.Clear();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnImportBill.Enabled == true)
            {
                deleteImportBill();
            }
            if(btnSellBill.Enabled == true)
            {
                deleteSellBill();
            }
            resetText();
        }

        private void dgvCheck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSubmit.Enabled = false;
            try
            {
                dgvCheck.CurrentRow.Selected = true;
                txtIDBill.Text = dgvCheck.CurrentRow.Cells[0].Value.ToString();
                txtIDEmployee.Text = dgvCheck.CurrentRow.Cells[1].Value.ToString();
                dtpDate.Text = dgvCheck.CurrentRow.Cells[2].Value.ToString();
                txtIDNccvKh.Text = dgvCheck.CurrentRow.Cells[3].Value.ToString();
                txtSumPrice.Text = dgvCheck.CurrentRow.Cells[4].Value.ToString();
                txtIDPro.Text = dgvCheck.CurrentRow.Cells[5].Value.ToString();
                txtQuantity.Text = dgvCheck.CurrentRow.Cells[6].Value.ToString();
                txtPrice.Text = dgvCheck.CurrentRow.Cells[7].Value.ToString();
                txtDiscount.Text = dgvCheck.CurrentRow.Cells[8].Value.ToString();
                txtTotalPrice.Text = dgvCheck.CurrentRow.Cells[9].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            resetText();
        }


    }


}
