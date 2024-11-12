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

        public ClassDangNhap() { }

        public ClassDangNhap(string tenDangNhap, string matKhau, string loaiNguoiDung)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            LoaiNguoiDung = loaiNguoiDung;
        }
        public ClassDangNhap(  string loaiNguoiDung, string matKhau)
        {
            LoaiNguoiDung = loaiNguoiDung;
            MatKhau = matKhau;
            
        }
    }
}
