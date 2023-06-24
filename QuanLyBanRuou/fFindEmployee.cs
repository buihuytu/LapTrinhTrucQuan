using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace QuanLyBanRuou
{
    public partial class fFindEmployee : Form
    {
        DataConnection connectData = new DataConnection();
        DataTable dt;
        public fFindEmployee()
        {
            InitializeComponent();
        }

        void ResetValue()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtAddress.Text = "";
            txtMaCV.Text = "";
            txtPhone.Text = "";
            txtSex.Text = "";
            mtbDOB.Text = "";
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dt = connectData.Read("select * from NhanVien");
            SearchNV.DataSource = dt;
            // định dạng datagridView
            SearchNV.Columns[0].HeaderText = "Mã NV";
            SearchNV.Columns[1].HeaderText = "Tên NV";
            SearchNV.Columns[2].HeaderText = "Giới tính";
            SearchNV.Columns[3].HeaderText = "Ngày sinh";
            SearchNV.Columns[4].HeaderText = "Điện thoại";
            SearchNV.Columns[5].HeaderText = "Địa chỉ";
            SearchNV.Columns[6].HeaderText = "Mã CV";

            SearchNV.Columns[0].Width = 100;
            SearchNV.Columns[1].Width = 100;
            SearchNV.Columns[2].Width = 100;
            SearchNV.Columns[3].Width = 100;
            SearchNV.Columns[4].Width = 100;
            SearchNV.Columns[5].Width = 100;
            SearchNV.Columns[6].Width = 100;

            dt.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select * from NhanVien where manhanvien is not null";
            if (txtSearchMaNV.Text.Trim() != "")
            {
                sql = sql + " and manhanvien =N'" + txtSearchMaNV.Text.Trim() + "'";
            }
            dt = connectData.Read(sql);
            SearchNV.DataSource = dt;

            SearchNV.Columns[0].HeaderText = "Mã SP";
            SearchNV.Columns[1].HeaderText = "Tên SP";
            SearchNV.Columns[2].HeaderText = "Ngày SX";
            SearchNV.Columns[3].HeaderText = "Ngày HH";
            SearchNV.Columns[4].HeaderText = "Đơn vị";
            SearchNV.Columns[5].HeaderText = "Đơn giá";
            SearchNV.Columns[6].HeaderText = "Ghi chú";
            SearchNV.Columns[0].DataPropertyName = "masp"; // lam gi 
            SearchNV.Columns[1].DataPropertyName = "tensp";
            SearchNV.Columns[2].DataPropertyName = "ngaysx";
            SearchNV.Columns[3].DataPropertyName = "ngayhh";
            SearchNV.Columns[4].DataPropertyName = "donvi";
            SearchNV.Columns[5].DataPropertyName = "dongia";
            SearchNV.Columns[6].DataPropertyName = "ghichu";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtPhone.Text == "" || txtSex.Text == "" || txtMaCV.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Bạn phải đủ các dữ liệu");
                txtMaNV.Focus();
            }
            else
            {
                DataTable dtChatLieu = connectData.Read("Select * from NhanVien where" + " manhanvien='" + (txtSearchMaNV.Text).Trim() + "'");
                if (dtChatLieu.Rows.Count > 0)
                {
                    MessageBox.Show("Mã SV này đã có, hãy nhập mã khác!");
                    txtMaNV.Focus();
                }
                else
                {
                    connectData.Update("insert into MatHang values(N'" + txtMaNV.Text + "',N'" + txtTenNV.Text + "',N'" + txtSex.Text + "',N'" + mtbDOB.Text + "',N'" + txtPhone.Text + "',N'" + txtAddress.Text + "' ,N'" + txtMaCV.Text + "')");
                    MessageBox.Show("Bạn đã thêm mới thành công");
                    SearchNV.DataSource = connectData.Read("select * from NhanVien");
                    ResetValue();
                }
            }
        }


        private void SearchNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = SearchNV.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = SearchNV.CurrentRow.Cells[1].Value.ToString();
            txtSex.Text = SearchNV.CurrentRow.Cells[2].Value.ToString();
            mtbDOB.Text = SearchNV.CurrentRow.Cells[3].Value.ToString();
            txtPhone.Text = SearchNV.CurrentRow.Cells[4].Value.ToString();
            txtAddress.Text = SearchNV.CurrentRow.Cells[5].Value.ToString();
            txtMaCV.Text = SearchNV.CurrentRow.Cells[6].Value.ToString();
            txtMaNV.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text == "" || txtMaCV.Text == "" || txtMaNV.Text == "" || txtPhone.Text == "" || txtSex.Text == "" || txtTenNV.Text == "" || mtbDOB.Text == "")
            {
                MessageBox.Show("Ban can Nhap du thong tin");
                txtMaNV.Focus();
            }
            else
            {
                connectData.Update("update NhanVien set tennhanvien=N'" + (txtTenNV.Text).Trim() + "',gioitinh=N'" + txtSex.Text + "',ngaysinh='" + 
                    mtbDOB.Text + "',dienthoai='" + txtPhone.Text.Trim() + "' ,diachi=N'" + txtAddress.Text.Trim() + "',macv=N'" + txtMaCV.Text.Trim() + 
                    "' where manhanvien = N'" + (txtMaNV.Text).Trim() + "'");
                SearchNV.DataSource = connectData.Read("select * from NhanVien");
                ResetValue();
            }
        }
    }
}
