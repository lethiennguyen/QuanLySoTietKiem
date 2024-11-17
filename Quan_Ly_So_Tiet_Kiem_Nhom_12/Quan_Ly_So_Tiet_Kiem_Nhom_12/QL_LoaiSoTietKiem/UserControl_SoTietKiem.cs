using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_LoaiSoTietKiem
{
    public partial class UserControl_SoTietKiem : UserControl
    {
        public int MaSo {  get; set; }
        public UserControl_SoTietKiem(int MaSo)
        {
            InitializeComponent();
            this.MaSo = MaSo;
           
        }
        public void SetData( int maso ,string tenso ,int kihan, int Makh, string TenKH,bool trangThai)
        {
            this.MaSo = maso;
            lb_TenSo.Text = "Tên sổ: " + tenso;
            LB_kihan.Text = "Kì hạn: " + kihan.ToString();
            LB_Makh.Text = "Mã KH: " + Makh.ToString();
            LB_tenKH.Text = "Tên khách hàng: " + TenKH;
            pictureBox_TrangThai.Image = trangThai ? Properties.Resources.tick :Properties.Resources.tick_dong;
        }

        private void guna2Panel1_DoubleClick(object sender, EventArgs e)
        {
            OnUserControlClick();
        }
        private void OnUserControlClick()
        {
            // Mở form mới với mã khách hàng
            var chiTietForm = new InAnSo.XuatXemfilePDF(MaSo);
            chiTietForm.LoadSo();  // Đảm bảo tải dữ liệu PDF ngay khi form được hiển thị
            chiTietForm.ShowDialog(); // Hiển thị form dưới dạng modal
        }
    }
}
