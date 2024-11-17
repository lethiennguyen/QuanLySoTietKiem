using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.ClassThongTin
{
    internal class ClassGiaoDich
    {
        public int MaSo {  get; set; }
        public string LoaiGiaoDich { get; set; }
        public DateTime ngaygiaodich { get; set; }
        public decimal SoTienGui {  get; set; }
        public ClassGiaoDich(int maSo, string loaiGiaoDich, DateTime ngaygiaodich, decimal soTienGui)
        {
            MaSo = maSo;
            LoaiGiaoDich = loaiGiaoDich;
            this.ngaygiaodich = ngaygiaodich;
            SoTienGui = soTienGui;
        }
    }
}
