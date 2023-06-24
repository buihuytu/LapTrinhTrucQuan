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
    public partial class fAddProduct : Form
    {
        MyClass _class = new MyClass("");
        QLBREntities db = new QLBREntities();
        public fAddProduct()
        {
            InitializeComponent();
        }

        #region methods
        

        void LoadCombobox()
        {
            cmbCategory.DataSource = db.Loais.ToList();
            cmbCategory.ValueMember = "maloai";
            cmbCategory.DisplayMember = "tenloai";

            cmbCapacity.DataSource = db.DungLuongs.ToList();
            cmbCapacity.ValueMember = "madungluong";
            cmbCapacity.DisplayMember = "tendungluong";

            cmbFunction.DataSource = db.CongDungs.ToList();
            cmbFunction.ValueMember = "macongdung";
            cmbFunction.DisplayMember = "tencongdung";

            cmbMateria.DataSource = db.ChatLieux.ToList();
            cmbMateria.ValueMember = "machatlieu";
            cmbMateria.DisplayMember = "tenchatlieu";

            cmbShape.DataSource = db.HinhDangs.ToList();
            cmbShape.ValueMember = "mahinhdang";
            cmbShape.DisplayMember = "tenhinhdang"; 

            cmbDegrees.DataSource = db.DoRuous.ToList();
            cmbDegrees.ValueMember = "mado";
            cmbDegrees.DisplayMember = "tendo";

            cmbColor.DataSource = db.MauSacs.ToList();
            cmbColor.ValueMember = "mamau";
            cmbColor.DisplayMember = "tenmau";

            cmbCountry.DataSource = db.NuocSanXuats.ToList();
            cmbCountry.ValueMember = "manuocsx";
            cmbCountry.DisplayMember = "tennuocsx";
            
        }

        void resetText()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtGuarantee.Text = "";
            txtNote.Text = "";
        }

        void resetCombobox()
        {
            cmbCategory.SelectedIndex = -1;
            cmbCapacity.SelectedIndex = -1;
            cmbFunction.SelectedIndex = -1;
            cmbMateria.SelectedIndex = -1;
            cmbShape.SelectedIndex = -1;
            cmbDegrees.SelectedIndex = -1;
            cmbColor.SelectedIndex = -1;
            cmbCountry.SelectedIndex = -1;
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

        void delete()
        {
            string masp = txtId.Text;
            DMHangHoa hh = db.DMHangHoas.Find(masp);
            db.DMHangHoas.Remove(hh);
            db.SaveChanges();
            LoadDataProduct();
        }

        Boolean Find(string maSP)
        {
            var result = db.DMHangHoas.Where(x => x.mahang == maSP).ToList();
            if(result.Count != 0)
            {
                return true;
            }
            return false;
        }

        void AddProduct()
        {
            db.DMHangHoas.Add(new DMHangHoa
            {
                mahang = txtId.Text,
                tenhang = txtName.Text,
                maloai = cmbCategory.SelectedValue.ToString(),
                madungluong = cmbCapacity.SelectedValue.ToString(),
                macongdung = cmbFunction.SelectedValue.ToString(),
                machatlieu = cmbMateria.SelectedValue.ToString(),
                mahinhdang = cmbShape.SelectedValue.ToString(),
                mado = cmbDegrees.SelectedValue.ToString(),
                mamau = cmbColor.SelectedValue.ToString(),
                manuocsx = cmbCountry.SelectedValue.ToString(),
                soluong = 0,
                dongianhap = 0,
                dongiaban = 0,
                thoigianbaohanh = txtGuarantee.Text,
                ghichu = txtNote.Text,
            });
            db.SaveChanges();
            LoadDataProduct();
        }
        #endregion
        private void fAddProduct_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            resetCombobox();
            LoadDataProduct();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            resetText();
            resetCombobox();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtId.Text == "")
            {
                errDetail.SetError(txtId, "Bạn không được để trống mã sản phẩm!");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if(txtName.Text == "")
            {
                errDetail.SetError(txtName, "Bạn không được để trống tên sản phẩm!");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if(cmbCategory.SelectedIndex == -1)
            {
                errDetail.SetError(cmbCategory, "Vui lòng chọn loại của sản phẩm");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (cmbCapacity.SelectedIndex == -1)
            {
                errDetail.SetError(cmbCapacity, "Vui lòng chọn dung dung lượng của sản phẩm");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (cmbFunction.SelectedIndex == -1)
            {
                errDetail.SetError(cmbFunction, "Vui lòng chọn công dụng của sản phẩm");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (cmbMateria.SelectedIndex == -1)
            {
                errDetail.SetError(cmbMateria, "Vui lòng chọn chất liệu của sản phẩm");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (cmbShape.SelectedIndex == -1)
            {
                errDetail.SetError(cmbShape, "Vui lòng chọn hình dạng của sản phẩm");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (cmbDegrees.SelectedIndex == -1)
            {
                errDetail.SetError(cmbDegrees, "Vui lòng chọn độ của sản phẩm");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (cmbColor.SelectedIndex == -1)
            {
                errDetail.SetError(cmbColor, "Vui lòng chọn màu sắc của sản phẩm");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (cmbCountry.SelectedIndex == -1)
            {
                errDetail.SetError(cmbCountry, "Vui lòng chọn nước sản xuất sản phẩm");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (txtGuarantee.Text == "")
            {
                errDetail.SetError(txtGuarantee, "Bạn không được để trống bảo hành sản phẩm!");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (txtNote.Text == "")
            {
                errDetail.SetError(txtNote, "Bạn không được để trống ghi chú sản phẩm!");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            if (Find(txtId.Text.Trim()) == true)
            {
                errDetail.SetError(txtId, "Mã sản phẩm đã tồn tại, vui lòng nhập mã khác!");
                return;
            }
            else
            {
                errDetail.Clear();
            }
            AddProduct();
            MessageBox.Show("Thêm thành công", "Thông báo");
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            this.Hide();
            fHome home = new fHome();
            home.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa sản phẩm có mã: " + txtId.Text + " không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                delete();
                MessageBox.Show("Xóa thành công");
            }
            resetText();
        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvResult.CurrentRow.Selected = true;
            txtId.Text = dgvResult.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
