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
    public partial class fFindKHvNCC : Form
    {
        DataConnection con = new DataConnection();
        public fFindKHvNCC()
        {
            InitializeComponent();
        }

        void reset()
        {
            txtDiachi.Text = "";
            txtMa.Text = "";
            txtTen.Text = "";
            txtTimMa.Text = "";
            txtTimTen.Text = "";
            txtSdt.Text = "";
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            reset();
            btnKH.Enabled = false;
            lbMa.Text = "Mã nhà cung cấp";
            lbTen.Text = "Tên nhà cung cấp";
            txtTimMa.Enabled = true;
            txtTimTen.Enabled = true;
            dgvKetqua.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgvKetqua.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgvKetqua.Columns[0].DataPropertyName = "mancc";
            dgvKetqua.Columns[1].DataPropertyName = "tenncc";
            dgvKetqua.Columns[2].DataPropertyName = "diachi";
            dgvKetqua.Columns[3].DataPropertyName = "dienthoai";
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            reset();
            btnNCC.Enabled = false;
            lbMa.Text = "Mã khách hàng";
            lbTen.Text = "Tên khách hàng";
            txtTimMa.Enabled = true;
            txtTimTen.Enabled = true;
            dgvKetqua.Columns[0].HeaderText = "Mã khách hàng";
            dgvKetqua.Columns[1].HeaderText = "Tên khách hàng";
            dgvKetqua.Columns[0].DataPropertyName = "makhach";
            dgvKetqua.Columns[1].DataPropertyName = "tenkhach";
            dgvKetqua.Columns[2].DataPropertyName = "diachi";
            dgvKetqua.Columns[3].DataPropertyName = "dienthoai";
        }


        private void dgvKetqua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvKetqua.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dgvKetqua.CurrentRow.Cells[1].Value.ToString();
            txtDiachi.Text = dgvKetqua.CurrentRow.Cells[2].Value.ToString();
            txtSdt.Text = dgvKetqua.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMa.Enabled = true;
            txtTen.Enabled = true;
            txtMa.Enabled = true;
            txtTen.Enabled = true;
            txtDiachi.Enabled = true;
            txtSdt.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(btnNCC.Enabled == true)
            {
                DataTable dt = con.Read("Select * from NhaCungCap where mancc = '" + txtTimMa.Text + "' and tenncc = '" + txtTimTen.Text + "'");
                dgvKetqua.DataSource = dt;
                dt.Dispose();
            }
            if(btnKH.Enabled == true)
            {
                DataTable dt = con.Read("Select * from Khachhang where makhach = '" + txtTimMa.Text + "' and tenkhach = '" + txtTimTen.Text + "'");
                dgvKetqua.DataSource = dt;
                dt.Dispose();
            }
        }

        private void btnLoai_Click(object sender, EventArgs e)
        {
            btnNCC.Visible = true;
            btnKH.Visible = true;
            btnKH.Enabled = true;
            btnNCC.Enabled = true;
        }

        private void btnNhaplai_Click(object sender, EventArgs e)
        {
            txtTimMa.Text = "";
            txtTimTen.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            con.Connect();
            string sql;
            if (btnNCC.Enabled == true)
            {
                sql = "UPDATE NhaCungCap SET tenncc='" + txtTen.Text + "'," +
                "diachi='" + txtDiachi.Text + "',dienthoai='" + txtSdt.Text + "' WHERE mancc='" + txtMa.Text + "'";
                con.Update(sql);
                DataTable dt = con.Read("Select * from NhaCungCap WHERE mancc='" + txtMa.Text + "'");
                dgvKetqua.DataSource = dt;
            }
            if (btnKH.Enabled == true)
            {
                sql = "UPDATE Khachhang SET tenkhach='" + txtTen.Text + "'," +
                "diachi='" + txtDiachi.Text + "',dienthoai='" + txtSdt.Text + "' WHERE makhach='" + txtMa.Text + "'";
                con.Update(sql);
                DataTable dt = con.Read("Select * from Khachhang WHERE makhach='" + txtMa.Text + "'");
                dgvKetqua.DataSource = dt;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            fHome home = new fHome();
            home.ShowDialog();
        }


    }
}
