using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_LoaiSoTietKiem.XacThucSo
{

    [System.Serializable]
    public class Glyph
    {
        public Glyph()
        {
            this.Lines = new List<Line>();
        }
        public List<Line> Lines { get; set; }
    }
}
