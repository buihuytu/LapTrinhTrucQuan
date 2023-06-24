using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyBanRuou
{
    public partial class fStatistic2 : Form
    {
        QLBREntities db = new QLBREntities();
        public fStatistic2()
        {
            InitializeComponent();
        }

        private void fStatistic2_Load(object sender, EventArgs e)
        {

        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
                errorProvider1.SetError(txtID, "Vui lòng nhập mã nhà cung cấp!");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            var result = from c in db.HoaDonNhaps
                         where (
                             c.mancc == txtID.Text
                         )
                         select new
                         {
                             mancc = c.mancc,
                             sohdn = c.sohdn,
                             nhanvien = c.NhanVien.tennhanvien,
                             ngaynhap = c.ngaynhap,
                             tongtien = c.tongtien,
                         };
            dataGridView1.DataSource = result.ToList();
            if(dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không tồn tại nhà cung cấp có mã " + txtID.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            double sum = 0;
            for(int i = 0; i <= dataGridView1.Rows.Count-1; i++)
            {
                sum += double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
            }
            lblSumPrice.Text += sum.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            lblSumPrice.Text = "Tổng tiền: ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook =
            exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range header = (Excel.Range)exSheet.Cells[1, 1];
            /*  --------------------------  Header  --------------------*/
            exSheet.get_Range("A1:D1").Merge(true);
            header.Font.Size = 18;
            header.Font.Bold = true;
            header.Font.Color = Color.Red;
            header.Value = "Danh Sách";
            /*   -------------------------- Data ------------------------*/
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                exApp.Cells[2, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        exApp.Cells[i + 3, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();


                    }
                }
            }

            int sum = 0; double total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);

            }
            Excel.Range Sum = (Excel.Range)exSheet.Cells[dataGridView1.Rows.Count + 2, 1];
            string range = "A" + (dataGridView1.Rows.Count + 2).ToString() + ":C" + (dataGridView1.Rows.Count + 2).ToString();
            exSheet.get_Range(range).Merge(true);
            Sum.Value = "Tổng";

            Excel.Range SumCredit = (Excel.Range)exSheet.Cells[dataGridView1.Rows.Count + 3, 4];
            SumCredit.Value = sum.ToString();
            /*-------------------------------------- code xuat file -----------------------------*/
            saveFileDialog1.Filter = "Excel Document(*.xls)|*.xls |Word Document(*.doc) | *.doc | All files(*.*) | *.* ";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = ".xls";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                exApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                exApp.ActiveWorkbook.Saved = true;
                exApp.Quit();
            }
            else
                MessageBox.Show("there are no list to print");
        }
    }
}
