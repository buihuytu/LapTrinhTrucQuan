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
    public partial class fHome : Form
    {
        public fHome()
        {
            InitializeComponent();
        }

        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            fAddProduct addProduct = new fAddProduct();
            addProduct.ShowDialog();
            this.Show();
        }

        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            fAddBill addBill = new fAddBill();
            addBill.ShowDialog();
            this.Show();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            fAddEmployee addEmployee = new fAddEmployee();
            addEmployee.ShowDialog();
            this.Show();
        }

        private void nhàCungCấpKháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            fAddKHvNCC addKHvNCC = new fAddKHvNCC();
            addKHvNCC.ShowDialog();
            this.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fFindProduct findProduct = new fFindProduct();
            findProduct.ShowDialog();
            this.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fFindBill findBill = new fFindBill();
            findBill.ShowDialog();
            this.Show();
        }

        private void nhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            fFindEmployee findEmployee = new fFindEmployee();
            findEmployee.ShowDialog();
            this.Show();
        }

        private void nhàCungCấpKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fFindKHvNCC findKHvNCC = new fFindKHvNCC();
            findKHvNCC.ShowDialog();
            this.Show();
        }

        private void thốngKêBaSảnPhẩmMuaNhiềuNhấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fStatistic1 statistic1 = new fStatistic1();
            statistic1.ShowDialog();
            this.Show();
        }

        private void hóaĐơnVàTổngTiềnMộtNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fStatistic2 statistic2 = new fStatistic2();
            statistic2.ShowDialog();
            this.Show();
        }

        private void doanhThuTrongMộtNămToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fStatistic3 statistic3 = new fStatistic3();
            statistic3.ShowDialog();
            this.Show();
        }

        private void hóaĐơnBánCủaMộtMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fStatistic4 statistic4 = new fStatistic4();
            statistic4.ShowDialog();
            this.Show();
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            fLogin login = new fLogin();
            login.ShowDialog();
        }
    }
}
