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
    public partial class fFindProduct : Form
    {
        QLBREntities db = new QLBREntities();
        public fFindProduct()
        {
            InitializeComponent();
        }

        #region methods
        void resetText()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtCategory.Text = "";
            txtCapacity.Text = "";
            txtFunction.Text = "";
            txtMaterial.Text = "";
            txtShape.Text = "";
            txtDegrees.Text = "";
            txtColor.Text = "";
            txtCountry.Text = "";
            txtQuantity.Text = "";
            txtPriceImport.Text = "";
            txtPriceSell.Text = "";
            txtGuarantee.Text = "";
            txtNote.Text = "";
        }

        void resetCombobox()
        {
            cmbCategory.SelectedIndex = -1;
            cmbCountry.SelectedIndex = -1;
            cmbDegrees.SelectedIndex = -1;
        }

        void showDetail(Boolean show)
        {
            txtID.Enabled = show;
            txtName.Enabled = show;
            txtCategory.Enabled = show;
            txtCapacity.Enabled = show;
            txtFunction.Enabled = show;
            txtMaterial.Enabled = show;
            txtShape.Enabled = show;
            txtDegrees.Enabled = show;
            txtColor.Enabled = show;
            txtCountry.Enabled = show;
            txtQuantity.Enabled = show;
            txtPriceImport.Enabled = show;
            txtPriceSell.Enabled = show;
            txtGuarantee.Enabled = show;
            txtNote.Enabled = show;
        }

        void LoadDataProduct()
        {
            var result = from c in db.DMHangHoas 
                         select new
                         {
                             mahang = c.mahang,
                             tenhang = c.tenhang,
                             maloai = c.Loai.tenloai,
                             madungluong = c.DungLuong.tendungluong,
                             macongdung = c.CongDung.tencongdung,
                             machatlieu = c.ChatLieu.tenchatlieu,
                             mahinhdang = c.HinhDang.tenhinhdang,
                             mado = c.DoRuou.tendo,
                             mamau = c.MauSac.tenmau,
                             manuocsx = c.NuocSanXuat.tennuocsx,
                             soluong = c.soluong,
                             dongianhap = c.dongianhap,
                             dongiaban = c.dongiaban,
                             thoigianbaohanh = c.thoigianbaohanh,
                             ghichu = c.ghichu,
                         };

            dgvResult.DataSource = result.ToList();
        }

        void FindProduct()
        {
            var result = from c in db.DMHangHoas
                         where(
                            c.maloai == cmbCategory.SelectedValue.ToString()
                            && c.mado == cmbDegrees.SelectedValue.ToString()
                            && c.manuocsx == cmbCountry.SelectedValue.ToString())
                         select new
                         {
                             mahang = c.mahang,
                             tenhang = c.tenhang,
                             maloai = c.Loai.tenloai,
                             madungluong = c.DungLuong.tendungluong,
                             macongdung = c.CongDung.tencongdung,
                             machatlieu = c.ChatLieu.tenchatlieu,
                             mahinhdang = c.HinhDang.tenhinhdang,
                             mado = c.DoRuou.tendo,
                             mamau = c.MauSac.tenmau,
                             manuocsx = c.NuocSanXuat.tennuocsx,
                             soluong = c.soluong,
                             dongianhap = c.dongianhap,
                             dongiaban = c.dongiaban,
                             thoigianbaohanh = c.thoigianbaohanh,
                             ghichu = c.ghichu,
                         };

            dgvResult.DataSource = result.ToList();
        }

        void LoadCombobox()
        {
            cmbCategory.DataSource = db.Loais.ToList();
            cmbCategory.ValueMember = "maloai";
            cmbCategory.DisplayMember = "tenloai";

            cmbDegrees.DataSource = db.DoRuous.ToList();
            cmbDegrees.ValueMember = "mado";
            cmbDegrees.DisplayMember = "tendo";

            cmbCountry.DataSource = db.NuocSanXuats.ToList();
            cmbCountry.ValueMember = "manuocsx";
            cmbCountry.DisplayMember = "tennuocsx";
        }

        #endregion

        private void fFindProduct_Load(object sender, EventArgs e)
        {
            LoadDataProduct();
            LoadCombobox();
            resetCombobox();
            showDetail(false);
        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvResult.CurrentRow.Selected = true;
            txtID.Text = dgvResult.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgvResult.CurrentRow.Cells[1].Value.ToString();
            txtCategory.Text = dgvResult.CurrentRow.Cells[2].Value.ToString();
            txtCapacity.Text = dgvResult.CurrentRow.Cells[3].Value.ToString();
            txtFunction.Text = dgvResult.CurrentRow.Cells[4].Value.ToString();
            txtMaterial.Text = dgvResult.CurrentRow.Cells[5].Value.ToString();
            txtShape.Text = dgvResult.CurrentRow.Cells[6].Value.ToString();
            txtDegrees.Text = dgvResult.CurrentRow.Cells[7].Value.ToString();
            txtColor.Text = dgvResult.CurrentRow.Cells[8].Value.ToString();
            txtCountry.Text = dgvResult.CurrentRow.Cells[9].Value.ToString();
            txtQuantity.Text = dgvResult.CurrentRow.Cells[10].Value.ToString();
            txtPriceImport.Text = dgvResult.CurrentRow.Cells[11].Value.ToString();
            txtPriceSell.Text = dgvResult.CurrentRow.Cells[12].Value.ToString();
            txtGuarantee.Text = dgvResult.CurrentRow.Cells[13].Value.ToString();
            txtNote.Text = dgvResult.CurrentRow.Cells[14].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            resetText();
            resetCombobox();
            LoadDataProduct();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(cmbCategory.SelectedIndex == -1)
            {
                errDetail.SetError(cmbCategory, "Vui lòng chọn loại của sản phẩm cần tìm");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (cmbDegrees.SelectedIndex == -1)
            {
                errDetail.SetError(cmbDegrees, "Vui lòng chọn độ của sản phẩm cần tìm");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (cmbCountry.SelectedIndex == -1)
            {
                errDetail.SetError(cmbCountry, "Vui lòng chọn nước sản xuất sản phẩm cần tìm");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            FindProduct();
            if (dgvResult.Rows.Count == 0)
            {
                MessageBox.Show("Sản phẩm cần tìm không tồn tại!");
                resetCombobox();
                LoadDataProduct();
            }
        }

    }
}
