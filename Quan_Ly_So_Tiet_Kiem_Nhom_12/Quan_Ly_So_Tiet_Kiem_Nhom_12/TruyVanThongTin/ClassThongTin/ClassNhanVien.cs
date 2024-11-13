using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.ClassThongTin
{
    internal class ClassNhanVien
    {
        public int MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string LoaiNguoiDung { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; } // Add password here

        // Constructor to initialize employee and login information
        public ClassNhanVien(string hoTen, DateTime? ngaySinh, string soDienThoai, string loaiNguoiDung, string tenDangNhap, string matKhau)
        {
            
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            SoDienThoai = soDienThoai;
            LoaiNguoiDung = loaiNguoiDung;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
        }
        public ClassNhanVien(int MaNV ,string hoTen, DateTime? ngaySinh, string soDienThoai, string loaiNguoiDung)
        {
            MaNhanVien = MaNV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            SoDienThoai = soDienThoai;
            LoaiNguoiDung = loaiNguoiDung;
        }
    }
}
