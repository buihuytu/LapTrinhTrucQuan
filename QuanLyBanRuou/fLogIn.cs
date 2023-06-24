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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {

            if(txtUser.Text == "admin" && txtPass.Text == "123456")
            {
                fHome home = new fHome();
                this.Hide();
                home.ShowDialog();
                this.Close();
            }
            else
            {
                if(MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    txtPass.Text = "";
                    txtUser.Text = "";
                }
            }
            /*
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                /* Cach 1:
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                string sql = "select * from tblAccount where TaiKhoan = @TaiKhoan and MatKhau = @MatKhau";
                cmd.Parameters.AddWithValue("@TaiKhoan", txtUser.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtPass.Text);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                // ExecuteReader: sử dụng khi query là select 
                // ExecuteNonQuery: sử dụng khi query là insert, update, delete
                */
                /* Cach 2:
                sqlCon.Open();
                string userName = txtUser.Text;
                string passWord = txtPass.Text;
                string sql = "select * from tblAccount where TaiKhoan = '" + userName + "' and MatKhau = '" + passWord + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                //
                if(sqlDataReader.Read() == true)
                {
                    fHome home = new fHome();
                    this.Hide();
                    home.ShowDialog();
                    this.Close();
                }
                else
                {
                    lblNotify.Visible = true;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
            finally
            {
                sqlCon.Close();
            }*/


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
