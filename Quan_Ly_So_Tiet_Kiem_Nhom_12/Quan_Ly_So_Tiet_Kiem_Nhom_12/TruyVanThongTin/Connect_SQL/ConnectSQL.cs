using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.Connect_SQL
{
    internal class ConnectSQL
    {
        public static string StringConnection = @"Data Source=DESKTOP-1146O4F\SQLEXPRESS;Initial Catalog=QuanLySoTietKiem;Integrated Security=True;";
        public static SqlConnection getConnection()
        {
            return new SqlConnection(StringConnection);
        }
    }
}
