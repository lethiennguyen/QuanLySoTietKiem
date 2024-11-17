using Quan_Ly_So_Tiet_Kiem_Nhom_12.ClassThongTin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.Connect_SQL
{
    internal class ModifyDangNhap
    {
        public ClassDangNhap DangNhap(string tenDangNhap, string matKhau)
        {
            ClassDangNhap nguoiDung = null;
            using (SqlConnection connection = TruyVanThongTin.Connect_SQL.ConnectSQL.getConnection())
            {
                string query = "SELECT NV.LoaiNguoiDung, NV.HoTen, NV.MaNhanVien FROM Admin A " +
               "JOIN NhanVien NV ON A.MaNhanVien = NV.MaNhanVien " +
               "WHERE A.TenDangNhap = @tenDangNhap AND A.MatKhau = @matKhau";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@matKhau", matKhau);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string loaiNguoiDung = reader["LoaiNguoiDung"].ToString();
                    string TenNV = reader["HoTen"].ToString();
                    int MaNV = int.Parse(reader["MaNhanVien"].ToString());
                    nguoiDung = new ClassDangNhap(MaNV,TenNV,tenDangNhap, matKhau, loaiNguoiDung);
                }
                reader.Close();
            }
            return nguoiDung;
        }
    }
}
