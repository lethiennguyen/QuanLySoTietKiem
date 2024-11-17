using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.Connect_SQL
{
    public class ModifyUser_so
    {
        public ModifyUser_so() { }
        public DataTable LayDuLieu()
        {
            DataTable dataTable = new DataTable();
            string Sql = "SELECT " +
                "  lstk.TenLoaiSo AS TenLoaiSo,  " +
                "  ls.SoThang AS SoThang," +
                "  kh.MaKhachHang AS MaKhachHang, " +
                "  kh.HoTen AS TenKhachHang, stk.TrangThai , stk.MaSoTietKiem " +
                "FROM SoTietKiem stk " +
                "INNER JOIN LoaiSoTietKiem lstk ON stk.MaLoaiSo = lstk.MaLoaiSo " +
                "INNER JOIN KhachHang kh ON stk.MaKhachHang = kh.MaKhachHang " +
                "INNER JOIN LaiSuat ls ON lstk.MaLaiSuat = ls.MaLaiSuat ";

            try
            {
                using (SqlConnection sqlConnection = TruyVanThongTin.Connect_SQL.ConnectSQL.getConnection())
                {
                    sqlConnection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Sql, sqlConnection))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message);
            }

            Console.WriteLine("Số lượng hàng trả về: " + dataTable.Rows.Count); // Log để kiểm tra
            return dataTable;
        }
    }
}
