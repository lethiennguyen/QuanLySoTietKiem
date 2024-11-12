using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_KhachHang
{
    public partial class QL_KhachHang : Form
    {
        private TinhHuyen tinhHuyen;
        public QL_KhachHang()
        {
            InitializeComponent();
            tinhHuyen = new TinhHuyen();
            // Thêm tỉnh vào ComboBox
            foreach (var province in tinhHuyen.GetAllProvinces())
            {
                txtThanhPho.Items.Add(province);
            }

            // Bạn có thể thêm sự kiện để thay đổi huyện khi tỉnh được chọn
            txtThanhPho.SelectedIndexChanged += txtThanhPho_SelectedIndexChanged;
        }
        private void txtThanhPho_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear quận/huyện trước khi thêm mới
            txtQuan.Items.Clear();

            // Lấy tên tỉnh được chọn
            string selectedProvince = txtThanhPho.SelectedItem.ToString();

            // Kiểm tra nếu tỉnh có quận/huyện
            var districts = tinhHuyen.GetDistrictsByProvince(selectedProvince);
            foreach (var district in districts)
            {
                txtQuan.Items.Add(district);
            }

            // Nếu không có quận/huyện nào thì thêm thông báo
            if (txtQuan.Items.Count == 0)
            {
                txtQuan.Items.Add("Không có quận/huyện nào");
            }

            // Tự động chọn phần tử đầu tiên trong cmbQuan nếu có
            if (txtQuan.Items.Count > 0)
            {
                txtQuan.SelectedIndex = 0;
            }
            if (txtQuan.Items.Count > 0)
            {
                txtQuan.SelectedIndex = 0;
            }
            if (txtQuan.Items.Count > 0)
            {
                txtQuan.SelectedIndex = 0;
            }
        }
    }
}
