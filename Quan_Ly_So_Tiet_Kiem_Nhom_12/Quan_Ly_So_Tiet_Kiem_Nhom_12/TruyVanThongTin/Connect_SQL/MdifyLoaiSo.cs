using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.Connect_SQL
{
    internal class MdifyLoaiSo
    {
        public DataTable getKhachHang()
        {

            SqlDataAdapter dataAdapter;
           
            DataTable dataTable = new DataTable();
            string Sql = "SELECT l.MaLoaiSo, l.TenLoaiSo, ls.LaiSuatTheoThang FROM LoaiSoTietKiem l" +
                "  INNER JOIN LaiSuat ls ON l.MaLaiSuat = ls.MaLaiSuat";

            try
            {
                using (SqlConnection sqlConnection = TruyVanThongTin.Connect_SQL.ConnectSQL.getConnection())
                {
                    sqlConnection.Open();
                    dataAdapter = new SqlDataAdapter(Sql, sqlConnection);
                    dataAdapter.Fill(dataTable);
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dataTable;
        }
        public static List<Tuple<string, int, decimal,int,int >> GetLoaiSoTietKiemData()
        {
            List<Tuple<string, int, decimal,int,int>> loaiSoTietKiemData = new List<Tuple<string, int, decimal,int,int >>();
            using (SqlConnection sqlConnection = TruyVanThongTin.Connect_SQL.ConnectSQL.getConnection())
            {
                string query = @"SELECT l.TenLoaiSo, ls.SoThang, ls.LaiSuatTheoThang ,l.MaLoaiSo , l.MaLaiSuat
                                 FROM LoaiSoTietKiem l
                                 JOIN LaiSuat ls ON l.MaLaiSuat = ls.MaLaiSuat";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string tenLoaiSo = reader["TenLoaiSo"].ToString();
                    int soThang = Convert.ToInt32(reader["SoThang"]);
                    decimal laiSuat = Convert.ToDecimal(reader["LaiSuatTheoThang"]);
                    int MaLoaiSo = Convert.ToInt32(reader["MaLoaiSo"]);
                    int MaLaiXuat = Convert.ToInt32(reader["MaLaiSuat"]);
                    loaiSoTietKiemData.Add(new Tuple<string, int, decimal,int,int>(tenLoaiSo, soThang, laiSuat,MaLoaiSo,MaLaiXuat));
                }
            }

            return loaiSoTietKiemData;
        }
    }
}
