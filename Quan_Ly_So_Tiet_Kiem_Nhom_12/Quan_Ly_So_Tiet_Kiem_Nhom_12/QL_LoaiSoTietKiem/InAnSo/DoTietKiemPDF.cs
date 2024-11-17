using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_LoaiSoTietKiem.InAnSo
{
    public partial class DoTietKiemPDF : Form
    {
        public DoTietKiemPDF()
        {
            InitializeComponent();
        }

        private void DoTietKiemPDF_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
