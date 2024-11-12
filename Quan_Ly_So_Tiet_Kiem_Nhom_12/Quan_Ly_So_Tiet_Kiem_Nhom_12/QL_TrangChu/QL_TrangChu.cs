using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_TrangChu
{
    public partial class QL_TrangChu : Form
    {
        public QL_TrangChu()
        {
            InitializeComponent();
        }
        public string MatKhau { get; set; }
        public QL_TrangChu(string loaiNguoiDung,string password)
        {
            InitializeComponent();
            label1.Text = loaiNguoiDung; // Gán vai trò vào Label trên Trang Chủ
            this.MatKhau = password;
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
            ShowForm.Controls.Clear();
            ShowForm.Controls.Add(ChilFoms);
            ShowForm.Tag = ChilFoms;
            ChilFoms.BringToFront();
            ChilFoms.Show();
            
        }
        public string chucnang ;
        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            chucnang = "Quản lý nhân viên";
            label_Chucnang.Text = chucnang;
            if (label1.Text == "QuanLy")
            {
                OpenChilForm(new QL_NhanVien.QuanLyQuyen(MatKhau));               
            }
            else
            {
                OpenChilForm(new QL_NhanVien.NoQL_NhanVien());
            }
                 
        }

        private void QL_TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void btn_QuanLyGiaoDich_Click(object sender, EventArgs e)
        {
            chucnang = "Quản lý Giao dịch";
            label_Chucnang.Text = chucnang;
            OpenChilForm(new QL_LoaiSoTietKiem.QL_SoTietKiem());
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            chucnang = "Quản lý khach hang";
            label_Chucnang.Text = chucnang;
            OpenChilForm(new QL_KhachHang.QL_KhachHang());
        }

        private void Btn_GuiSoTietKiem_Click(object sender, EventArgs e)
        {
            chucnang = "Quan Ly So";
            label_Chucnang.Text = chucnang;
            OpenChilForm(new QL_LoaiSoTietKiem.XuLySoTietKiem());
        }
    }
}
