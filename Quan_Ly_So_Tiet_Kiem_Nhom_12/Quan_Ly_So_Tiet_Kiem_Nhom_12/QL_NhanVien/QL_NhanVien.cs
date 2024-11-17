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

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_NhanVien
{
    public partial class QL_NhanVien : Form
    {
        ModifyNhanVien modifyNhanVien;
        public QL_NhanVien()
        {
            InitializeComponent();
            LoadData(modifyNhanVien);
        }
        private void LoadData(ModifyNhanVien modifyNhanVien)
        {
            try
            {
                modifyNhanVien = new ModifyNhanVien();
               DGV_NhanVien.DataSource = modifyNhanVien.getNhanVien();
                DGV_DN.DataSource = modifyNhanVien.getTKNhanVien();
            }
            catch
            {
                MessageBox.Show("error", "loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
           
            string TenNV = this.txt_tenNv.Text;
            DateTime NgaySinh = this.dt_ngaysinh.Value;
            string SDT = this.txt_sdt.Text;
            string LoaiNguoiDung = this.txt_loainguoidung.Text;
            string TenDN = this.txt_tendn.Text;
            string MatKhau = this.txt_pass.Text;
            ClassNhanVien classNhanVien = new ClassNhanVien(TenNV,NgaySinh,SDT,LoaiNguoiDung,TenDN,MatKhau);
            try
            {
                modifyNhanVien = new ModifyNhanVien();
                if (modifyNhanVien.AddNhanVien(classNhanVien))
                {
                   LoadData(modifyNhanVien);

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

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            int MaNV = int.Parse(this.txt_maNv.Text);
            string TenNV = this.txt_tenNv.Text;
            DateTime NgaySinh = this.dt_ngaysinh.Value;
            string SDT = this.txt_sdt.Text;
            string LoaiNguoiDung = this.txt_loainguoidung.Text;
            string TenDN = this.txt_tendn.Text;
            string MatKhau = this.txt_pass.Text;
            ClassNhanVien classNhanVien = new ClassNhanVien(MaNV,TenNV, NgaySinh, SDT, LoaiNguoiDung);
            try
            {
                modifyNhanVien = new ModifyNhanVien();
                if (modifyNhanVien.UpdateNhanVien(classNhanVien))
                {
                    LoadData(modifyNhanVien);

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

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            int maNv = int.Parse(this.txt_maNv.Text);
            try
            {
                modifyNhanVien = new ModifyNhanVien();
                if (modifyNhanVien.DeleteNhanVien(maNv))
                {
                    LoadData(modifyNhanVien);

                }
                else
                {
                    MessageBox.Show("Error", "Không Xóa được", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGV_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow selectedRow = DGV_NhanVien.Rows[e.RowIndex];
                string maNhanVien = selectedRow.Cells[0].Value.ToString(); // Get MaNhanVien value
                string hoTen = selectedRow.Cells[1].Value.ToString();           // Get HoTen value
                string ngaySinh = selectedRow.Cells[2].Value.ToString();     // Get NgaySinh value
                string soDienThoai = selectedRow.Cells[3].Value.ToString(); // Get SoDienThoai value
                string loaiNguoiDung = selectedRow.Cells[4].Value.ToString(); // Get LoaiNguoiDung value
                txt_maNv.Text = maNhanVien;
                txt_tenNv.Text = hoTen;
                dt_ngaysinh.Value = DateTime.Parse(ngaySinh);  // Convert to DateTime if needed
                txt_sdt.Text = soDienThoai;
                txt_loainguoidung.Text = loaiNguoiDung;
                btn_Sua.Enabled = true;
                btn_Xoa.Enabled = true;
            }
        }
    }
}
