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
    public partial class fStatistic4 : Form
    {
        QLBREntities db = new QLBREntities();
        public fStatistic4()
        {
            InitializeComponent();
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                errorProvider1.SetError(txtID, "Vui lòng nhập mã sản phẩm!");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            var result = db.Cau9(txtID.Text);
            dataGridView1.DataSource = result.ToList();
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không tồn tại sản phẩm có mã " + txtID.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtID.Text = "";
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
            header.Value = "Danh Sách hóa đơn";
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
