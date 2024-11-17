using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.ClassThongTin
{
    internal class ClassDangNhap
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string LoaiNguoiDung { get; set; }
        public string TenNV {  get; set; }
        public int MaNV {  get; set; }

        public ClassDangNhap() { }

        public ClassDangNhap(string tenDangNhap, string matKhau, string loaiNguoiDung)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            LoaiNguoiDung = loaiNguoiDung;
        }

        //public ClassDangNhap(string tenNV, string loaiNguoiDung, string matKhau)
        //{
        //    TenNV = tenNV;
        //    LoaiNguoiDung = loaiNguoiDung;
        //    MatKhau = matKhau;
        //}

        // New constructor that takes four parameters
        public ClassDangNhap(int maNV ,string tenNV, string tenDangNhap, string matKhau, string loaiNguoiDung)
        {
            MaNV = maNV; 
            TenNV = tenNV;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            LoaiNguoiDung = loaiNguoiDung;
        }
    }
}
