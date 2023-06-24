using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyBanRuou
{
    public partial class fAddKHvNCC : Form
    {
        DataConnection conn=new DataConnection();
        public fAddKHvNCC()
        {
            InitializeComponent();
        }

        public void resetText()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }
        private void btnChonDuLieu_Click(object sender, EventArgs e)
        {
            HienChiTiet(false);
            btnThemNhaCC.Enabled = true;
            btnThemKhachHang.Enabled = true;
            title.Text = "Thêm Khách Hàng/Nhà Cung Cấp";
            resetText();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienChiTiet(false);
        }

        private void btnThemKhachHang_Click_1(object sender, EventArgs e)
        {
            HienChiTiet(true);
            btnThemNhaCC.Enabled = false;
            title.Text = "Thêm Khách Hàng";
            lblMa.Text = "Mã khách hàng";
            lblTen.Text = "Tên khách hàng";
            dgvKetQua.Columns[0].HeaderText = "Mã khách hàng";
            dgvKetQua.Columns[1].HeaderText = "Tên khách hàng";
            dgvKetQua.Columns[0].DataPropertyName = "makhach";
            dgvKetQua.Columns[1].DataPropertyName = "tenkhach";

            DataTable dt = conn.Read("select* from Khachhang");
            dgvKetQua.DataSource = dt;
            dt.Dispose();
        }

        private void btnThemNhaCC_Click_1(object sender, EventArgs e)
        {
            HienChiTiet(true);
            btnThemKhachHang.Enabled = false;
            title.Text = "Thêm Nhà Cung Cấp";
            lblMa.Text = "Mã Ncc";
            lblTen.Text = "Tên Ncc";
            dgvKetQua.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgvKetQua.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgvKetQua.Columns[0].DataPropertyName = "mancc";
            dgvKetQua.Columns[1].DataPropertyName = "tenncc";
            DataTable dt = conn.Read("select * from NhaCungCap");
            dgvKetQua.DataSource = dt;
            dt.Dispose();
        }

 

        private void btnXacNhan_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (btnThemKhachHang.Enabled == true)
                {

                    string sql = "insert into Khachhang values (";
                    sql += "N'" + txtMa.Text + "',N'" + txtTen.Text +
                        "',N'" + txtDiaChi.Text + "',N'" + txtDienThoai.Text + "')";
                    conn.Update(sql);
                    DataTable dt2 = conn.Read("select * from Khachhang");
                    dgvKetQua.DataSource = dt2;
                    conn.Close();
                }
                if (btnThemNhaCC.Enabled == true)
                {

                    string sql = "insert into NhaCungCap values (";
                    sql += "N'" + txtMa.Text + "',N'" + txtTen.Text +
                        "',N'" + txtDiaChi.Text + "',N'" + txtDienThoai.Text + "')";
                    conn.Update(sql);
                    DataTable dt2 = conn.Read("select * from NhaCungCap");
                    dgvKetQua.DataSource = dt2;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mã đã tồn tại");
            }
          
            resetText();
        }
        private void HienChiTiet(Boolean hien)
        {
            txtMa.Enabled = hien;
            txtTen.Enabled = hien;
            txtDiaChi.Enabled = hien;
            txtDienThoai.Enabled = hien;
           
            btnXacNhan.Enabled = hien;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (MessageBox.Show("Ban muon xoa khong?", " notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if(btnThemKhachHang.Enabled == true)
                {
                    sql = "delete Khachhang where  makhach=" + "'" + txtMa.Text + "'";
                    conn.Update(sql);
                    DataTable dt2 = conn.Read("select* from Khachhang");
                    dgvKetQua.DataSource = dt2;
                }
                if (btnThemNhaCC.Enabled == true)
                {
                    sql = "delete NhaCungCap where  mancc=" + "'" + txtMa.Text + "'";
                    conn.Update(sql);
                    DataTable dt2 = conn.Read("select* from NhaCungCap");
                    dgvKetQua.DataSource = dt2;
                }

            }
        }

        private void dgvKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvKetQua.CurrentRow.Selected = true;
            txtMa.Text = dgvKetQua.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dgvKetQua.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dgvKetQua.CurrentRow.Cells[2].Value.ToString();
            txtDienThoai.Text = dgvKetQua.CurrentRow.Cells[3].Value.ToString();

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            fHome home = new fHome();
            home.ShowDialog();
        }
    }
}
