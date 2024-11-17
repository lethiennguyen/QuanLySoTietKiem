using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.ClassThongTin
{
    internal class ClassKhachHang
    {
        public int MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string CMND { get; set; }
        public string Quan { get; set; }         
        public string ThanhPho { get; set; }    
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public ClassKhachHang(int maKhachHang, string hoTen, string cmnd, string quan, string thanhPho,string diaChi, string soDienThoai)
        {
            MaKhachHang = maKhachHang;
            HoTen = hoTen;
            CMND = cmnd;
            Quan = quan;
            ThanhPho = thanhPho;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
        }
        public ClassKhachHang(  string hoTen, string cmnd, string diaChi,string soDienThoai,string quan, string thanhPho)
        {
           
            HoTen = hoTen;
            CMND = cmnd;
            Quan = quan;
            ThanhPho = thanhPho;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
        }

        public ClassKhachHang(int maKhachHang, string hoTen,  string quan, string thanhPho, string diaChi, string soDienThoai)
        {
            MaKhachHang = maKhachHang;
            HoTen = hoTen;
            Quan = quan;
            ThanhPho = thanhPho;
            DiaChi = diaChi;
            SoDienThoai= soDienThoai;
        }
        public ClassKhachHang(string cmnd)
        {
            CMND = cmnd;
        }
    }
}
