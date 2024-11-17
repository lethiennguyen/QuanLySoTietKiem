using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_LoaiSoTietKiem.XacThucSo
{
    [Serializable]
    public class Signature
    {
        public Signature()
        {
            this.Glyphs = new List<Glyph>();
        }

        public List<Glyph> Glyphs { get; set; }
    }
}
