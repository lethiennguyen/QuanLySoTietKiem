using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_LoaiSoTietKiem.XacThucSo
{
    [Serializable]
    public class Line
    {
        public Line()
        {

        }

        public Line(Point startPoint, Point endPoint)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
        }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}
