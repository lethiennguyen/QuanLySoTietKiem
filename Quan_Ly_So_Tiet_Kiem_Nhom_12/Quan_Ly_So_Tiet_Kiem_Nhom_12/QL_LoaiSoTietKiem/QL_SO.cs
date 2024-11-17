using Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.Connect_SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_LoaiSoTietKiem
{
    public partial class QL_SO : Form
    {
        public int MaNv { get; set; }
        public string TenNV { get; set; }
        public QL_SO()
        {
            InitializeComponent();
            LoadSanPhamData();
        }
        public QL_SO(int MaNV, string tenNV)
        {
            InitializeComponent();
            LoadSanPhamData();
            this.MaNv = MaNV;
            this.TenNV = tenNV;
        }
      

        public void LoadSanPhamData()
        {
            ModifyUser_so t = new ModifyUser_so();
            DataTable sanPhamTable = t.LayDuLieu();

            foreach (DataRow row in sanPhamTable.Rows)
            {
                // Kiểm tra giá trị null của từng cột
                int maso = row["MaSoTietKiem"] != DBNull.Value ? Convert.ToInt32(row["MaSoTietKiem"]) : 0;
                string tenLoaiSo = row["TenLoaiSo"] != DBNull.Value ? row["TenLoaiSo"].ToString() : "N/A";
                int soThang = row["SoThang"] != DBNull.Value ? Convert.ToInt32(row["SoThang"]) : 0;
                int maKhachHang = row["MaKhachHang"] != DBNull.Value ? Convert.ToInt32(row["MaKhachHang"]) : 0;
                bool trangthai = row["TrangThai"] != DBNull.Value ? Convert.ToBoolean(row["TrangThai"]) : false;
                string tenKhachHang = row["TenKhachHang"] != DBNull.Value ? row["TenKhachHang"].ToString() : "Chưa rõ";

                // Tạo và thiết lập dữ liệu cho UserControl
                var userControl = new UserControl_SoTietKiem(maso);
                userControl.SetData(maso,tenLoaiSo, soThang, maKhachHang, tenKhachHang,trangthai);

                // Căn chỉnh và thêm vào FlowLayoutPanel
                userControl.Margin = new Padding(2, 2, 2, 2);
                flowLayoutPanel1.Controls.Add(userControl);
            }
           
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadSanPhamData();
        }

        private void QL_SO_Load(object sender, EventArgs e)
        {
        }
    }
}
