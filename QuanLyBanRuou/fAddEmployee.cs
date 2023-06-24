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
    public partial class fAddEmployee : Form
    {
        DataConnection db = new DataConnection();
        DataTable dtNhanVien;
        public fAddEmployee()
        {
            InitializeComponent();
        }

        void ResetValue()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            cbbGioiTinh.SelectedValue = "";
            txtDOB.Text = "";
            txtSDT.Text = "";
            txtDC.Text = "";
            cbbMaCV.SelectedValue = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtNhanVien = db.Read("select * from NhanVien");
            dgvNhanVien.DataSource = dtNhanVien;
            //Định dạng dataGrid
            dgvNhanVien.Columns[0].HeaderText = "Mã NV";
            dgvNhanVien.Columns[1].HeaderText = "Tên NV";
            dgvNhanVien.Columns[2].HeaderText = "Giới tính";
            dgvNhanVien.Columns[3].HeaderText = "Ngày tháng năm sinh";
            dgvNhanVien.Columns[4].HeaderText = "Điện thoại";
            dgvNhanVien.Columns[5].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[6].HeaderText = "Mã CV";
            dgvNhanVien.Columns[0].Width = 100;
            dgvNhanVien.Columns[1].Width = 150;
            dgvNhanVien.Columns[2].Width = 100;
            dgvNhanVien.Columns[3].Width = 130;
            dgvNhanVien.Columns[4].Width = 130;
            dgvNhanVien.Columns[5].Width = 130;
            dgvNhanVien.Columns[6].Width = 100;
            dgvNhanVien.BackgroundColor = Color.LightBlue;
            dtNhanVien.Dispose();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtTenNV.Text == "" || cbbGioiTinh.SelectedItem.ToString() == "" || txtDOB.Text == "" || txtSDT.Text == "" || txtDC.Text == "" || cbbMaCV.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Bạn phải đủ các dữ liệu");
                txtMaNV.Focus();
            }
            else
            {
                dtNhanVien = db.Read("Select * from NhanVien where" + " manhanvien='" + (txtMaNV.Text).Trim() + "'");
                if (dtNhanVien.Rows.Count > 0)
                {
                    MessageBox.Show("Mã SV này đã có, hãy nhập mã khác!");
                    txtMaNV.Focus();
                }
                else
                {
                    db.Update("insert into NhanVien values(N'" + txtMaNV.Text + "',N'" + txtTenNV.Text + "',N'" + cbbGioiTinh.SelectedItem.ToString() + "',N'" + txtDOB.Text + "',N'" + txtSDT.Text + "',N'" + txtDC.Text + "' ,N'" + cbbMaCV.SelectedValue.ToString() + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");
                    dgvNhanVien.DataSource = db.Read("select * from NhanVien");
                    ResetValue();
                }
            }
        }

        private void cbbMaCV_Click(object sender, EventArgs e)
        {
            cbbMaCV.DataSource = db.Read("Select * from CongViec");
            cbbMaCV.ValueMember = "macv"; //Giá trị của phần tử
            cbbMaCV.DisplayMember = "tencv";//Chuỗi hiển thị của phần tử
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
            cbbGioiTinh.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
            txtDOB.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
            txtSDT.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
            txtDC.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
            cbbMaCV.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();

            btnXoa.Visible = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhan vien có mã là:" +
                txtMaNV.Text + " không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                System.Windows.Forms.DialogResult.Yes)
            {
                db.Update("delete from NhanVien where manhanvien='" + txtMaNV.Text + "'");
                dgvNhanVien.DataSource = db.Read("Select * from NhanVien");
                ResetValue();
            }
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            this.Hide();
            fHome home = new fHome();
            home.ShowDialog();
        }
    }
}
