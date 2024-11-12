using Guna.UI2.WinForms.Suite;
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
    public partial class QuanLyQuyen : Form
    {
        public QuanLyQuyen()
        {
            InitializeComponent();
        }


        private Form currentChilFoms;
        private void OpenChilForm(Form ChilFoms)
        {
            if (currentChilFoms != null)//kiểm tra khơi tạo rồi đóng
            {
                currentChilFoms.Close();
            }
            currentChilFoms = ChilFoms;
            ChilFoms.TopLevel = false;
            ChilFoms.FormBorderStyle = FormBorderStyle.None;
            ChilFoms.Dock = DockStyle.Fill;
            
            mainPanel.Controls.Add(ChilFoms);
            mainPanel.Tag = ChilFoms;
            ChilFoms.BringToFront();
            ChilFoms.Show();

        }


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_DangNhap_Click_1(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            OpenChilForm(new QL_NhanVien());
        }

        private void chkShowPassword_MouseDown_1(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '\0';
            txtPassword.UseSystemPasswordChar = false;
        }

        private void chkShowPassword_MouseUp_1(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '*';
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
