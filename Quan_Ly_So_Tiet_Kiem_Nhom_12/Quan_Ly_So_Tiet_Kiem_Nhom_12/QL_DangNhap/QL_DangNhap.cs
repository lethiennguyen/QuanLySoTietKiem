using Quan_Ly_So_Tiet_Kiem_Nhom_12.ClassThongTin;
using Quan_Ly_So_Tiet_Kiem_Nhom_12.Connect_SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_DangNhap
{
    public partial class QL_DangNhap : Form
    {
        public QL_DangNhap()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = this.txt_tentk.Text;
            string mkDangNhap = this.txt_matkhautk.Text;
            ModifyDangNhap modifyDangNhap = new ModifyDangNhap();
            ClassDangNhap nguoiDung = modifyDangNhap.DangNhap(tenDangNhap, mkDangNhap);

            if (nguoiDung != null)
            {
                if (nguoiDung.LoaiNguoiDung == "QuanLy" && nguoiDung.MatKhau == mkDangNhap && nguoiDung.TenDangNhap== tenDangNhap)
                {
                    QL_TrangChu.QL_TrangChu ql = new QL_TrangChu.QL_TrangChu(nguoiDung.MaNV, nguoiDung.TenNV,nguoiDung.LoaiNguoiDung, nguoiDung.MatKhau);                    
                    ql.Show();
                }
                else if (nguoiDung.LoaiNguoiDung == "NhanVien")
                {
                    QL_TrangChu.QL_TrangChu ql = new QL_TrangChu.QL_TrangChu(nguoiDung.MaNV,nguoiDung.TenNV, nguoiDung.LoaiNguoiDung, nguoiDung.MatKhau);
                    
                    ql.Show();
                }
            }
            else
            {
                MessageBox.Show("đéo đc");
            }
        }
    }
}
