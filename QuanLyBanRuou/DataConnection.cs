using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBanRuou
{
    internal class DataConnection
    {
    

        public string strConnection = @"Data Source=LAPTOP-7AIEH3G7\SQLEXPRESS;Initial Catalog=QLBR;Integrated Security=True";
        public SqlConnection conn = null;
        public void Connect()
        {
            conn = new SqlConnection(strConnection);
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }
        //Hàm đóng kết nối CSDL
        public void Close()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
            conn.Dispose();
        }

        //Hàm thực thi câu lệnh dạng Select trả về một DataTable
        public DataTable Read(string sql)
        {
            DataTable dtBang = new DataTable();
            Connect();
            SqlDataAdapter sqldataAdapte = new SqlDataAdapter(sql, conn);
            sqldataAdapte.Fill(dtBang);
            Close();
            return dtBang;
        }

        //Hàm thực lệnh insert hoặc update hoặc delete
        public void Update(string sql)
        {
            Connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = conn;
            sqlcommand.CommandText = sql;
            sqlcommand.ExecuteNonQuery();
            // INSERT INTO TBLsINHVIEN VALUES ();
            Close();
        }
    }
}
