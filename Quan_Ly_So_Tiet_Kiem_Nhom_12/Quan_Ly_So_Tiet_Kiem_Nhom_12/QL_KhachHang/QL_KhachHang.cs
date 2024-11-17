using Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.ClassThongTin;
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

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_KhachHang
{
    public partial class QL_KhachHang : Form
    {
        private TinhHuyen tinhHuyen;
        private ClassKhachHang khachHang;
        TruyVanThongTin.Connect_SQL.ModifyKhachHang modify;
        public QL_KhachHang()
        {
            InitializeComponent();
            LoadKHachHang();
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
           
            txtQuan.Items.Clear();
            string selectedProvince = txtThanhPho.SelectedItem.ToString();
            var districts = tinhHuyen.GetDistrictsByProvince(selectedProvince);
            foreach (var district in districts)
            {
                txtQuan.Items.Add(district);
            }
            if (txtQuan.Items.Count == 0)
            {
                txtQuan.Items.Add("Không có quận/huyện nào");
            }
            if (txtQuan.Items.Count > 0)
            {
                txtQuan.SelectedIndex = 0;
            }

        }
        public void LoadKHachHang()
        {
            try
            {
                modify = new TruyVanThongTin.Connect_SQL.ModifyKhachHang();
                DGV_KhachHang.DataSource = modify.getKhachHang();
            }
            catch
            {
                MessageBox.Show("error", "loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddCustomer_Click(object sender, EventArgs e)
        {
            //string makh = txtMaKH.Text;
            string tenKH = txtTenKH.Text;
            string cmnd = txtCMND.Text;
            string diaChi = txtDiaChi.Text;
            string quan = txtQuan.Text;
            string thanhPho = txtThanhPho.Text;
            string sdt =txtSDT.Text;
            khachHang = new ClassKhachHang(tenKH,cmnd,diaChi, sdt ,quan,thanhPho);
            modify = new TruyVanThongTin.Connect_SQL.ModifyKhachHang();
            try
            {
                if (modify.AddCustomer(khachHang)) {
                    LoadKHachHang();
                }
                else
                {
                    MessageBox.Show("Error", "Không thêm được", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                int maKH =int.Parse( txtMaKH.Text);  // Lấy mã khách hàng từ TextBox
                bool isSuccess = modify.DeleteKhachHang(maKH);
                if (isSuccess)
                {
                    MessageBox.Show("Xóa khách hàng thành công!");
                    LoadKHachHang();  // Load lại dữ liệu sau khi xóa
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void UpDateCustomer_Click(object sender, EventArgs e)
        {
            int makh =int.Parse(txtMaKH.Text);
            string tenKH = txtTenKH.Text;
            string cmnd = txtCMND.Text;
            string diaChi = txtDiaChi.Text;
            string quan = txtQuan.Text;
            string thanhPho = txtThanhPho.Text;
            string sdt = txtSDT.Text;
            khachHang = new ClassKhachHang(makh,tenKH, cmnd, thanhPho, quan, diaChi, sdt);
            modify = new TruyVanThongTin.Connect_SQL.ModifyKhachHang();
            try
            {
                if (modify.UpdateCustomer(khachHang))
                {
                    LoadKHachHang();
                }
                else
                {
                    MessageBox.Show("Error", "Không thêm được", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGV_KhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGV_KhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells[0].Value.ToString();
                txtTenKH.Text = row.Cells[1].Value.ToString();
                txtCMND.Text = row.Cells[2].Value.ToString();
                txtDiaChi.Text = row.Cells[3].Value.ToString();
                txtSDT.Text = row.Cells[4].Value.ToString();
                string selectedProvince = row.Cells[5].Value.ToString();
                string selectedDistrict = row.Cells[6].Value.ToString();
                txtThanhPho.SelectedIndex = txtThanhPho.Items.IndexOf(selectedProvince);
                txtQuan.SelectedIndex = txtQuan.Items.IndexOf(selectedDistrict);
                if (txtQuan.SelectedIndex == -1)
                {
                    txtQuan.Items.Clear();
                    txtQuan.Items.Add("Không có quận/huyện nào");
                    txtQuan.SelectedIndex = 0;
                }
            }
        }
    }
}
