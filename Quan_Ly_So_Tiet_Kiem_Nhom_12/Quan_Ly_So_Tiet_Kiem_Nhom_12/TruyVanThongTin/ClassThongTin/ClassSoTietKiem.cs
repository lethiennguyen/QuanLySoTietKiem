using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.ClassThongTin
{
    internal class ClassSoTietKiem
    {
      

        public int MaNV {  get; set; }
        public int MaKH {  get; set; }
        public int MaLoaiSo { get; set; }
        public int MaLaiXuat { get; set; }
        public DateTime NgayMoSo { get; set; }
        public DateTime NgayHetHan { get; set; }
        public decimal SoTienGui {  get; set; }

        public ClassSoTietKiem(int maNV, int maKH, int maLoaiSo, int maLaiXuat, DateTime ngayMoSo, DateTime ngayHetHan, decimal soTienGui)
        {
            MaNV = maNV;
            MaKH = maKH;
            MaLoaiSo = maLoaiSo;
            MaLaiXuat = maLaiXuat;
            NgayMoSo = ngayMoSo;
            NgayHetHan = ngayHetHan;
            SoTienGui = soTienGui;
        }


    }
}
