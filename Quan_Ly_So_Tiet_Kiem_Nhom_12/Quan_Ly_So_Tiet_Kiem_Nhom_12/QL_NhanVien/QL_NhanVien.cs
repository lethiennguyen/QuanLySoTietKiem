using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_NhanVien
{
    public partial class QL_NhanVien : Form
    {
        public QL_NhanVien()
        {
            InitializeComponent();
        }
        private Form currentChilFoms;
        private Stack<Form> formHistory = new Stack<Form>(); // Stack để lưu lịch sử form
        private void btn_Thoat_Click(object sender, EventArgs e)
        {

        }
    }
}
