using Quan_Ly_So_Tiet_Kiem_Nhom_12.ClassThongTin;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.Connect_SQL
{
    internal class ModifyNhanVien
    {
        SqlDataAdapter dataAdapter;
        SqlCommand Command;
        public ModifyNhanVien()
        {
        }
        public DataTable getNhanVien()
        {
            DataTable dataTable = new DataTable();
            string Sql = "select * from dbo.NhanVien";
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
        public DataTable getTKNhanVien()
        {
            DataTable dataTable = new DataTable();
            string Sql = "select * from dbo.Admin";
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
        public bool AddNhanVien(ClassNhanVien nhanVien)
        {
            using (SqlConnection conn = TruyVanThongTin.Connect_SQL.ConnectSQL.getConnection())
            {
                conn.Open();
                string queryNhanVien = "INSERT INTO NhanVien (HoTen, NgaySinh, SoDienThoai, LoaiNguoiDung) " +
                                       "VALUES (@HoTen, @NgaySinh, @SoDienThoai, @LoaiNguoiDung); " +
                                       "SELECT SCOPE_IDENTITY();";
                SqlCommand cmdNhanVien = new SqlCommand(queryNhanVien, conn);
                cmdNhanVien.Parameters.AddWithValue("@HoTen", nhanVien.HoTen);
                cmdNhanVien.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh.HasValue ? (object)nhanVien.NgaySinh.Value : DBNull.Value);
                cmdNhanVien.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai);
                cmdNhanVien.Parameters.AddWithValue("@LoaiNguoiDung", nhanVien.LoaiNguoiDung);
                int maNhanVien = Convert.ToInt32(cmdNhanVien.ExecuteScalar());
                string queryAdmin = "INSERT INTO Admin (MaNhanVien, TenDangNhap, MatKhau) " +
                                    "VALUES (@MaNhanVien, @TenDangNhap, @MatKhau)";
                SqlCommand cmdAdmin = new SqlCommand(queryAdmin, conn);
                cmdAdmin.Parameters.AddWithValue("@MaNhanVien", maNhanVien); 
                cmdAdmin.Parameters.AddWithValue("@TenDangNhap", nhanVien.TenDangNhap);
                cmdAdmin.Parameters.AddWithValue("@MatKhau", nhanVien.MatKhau);
                int resultAdmin = cmdAdmin.ExecuteNonQuery();
                return resultAdmin > 0;
            }

        }
        public bool UpdateNhanVien(ClassThongTin.ClassNhanVien nhanVien)
        {
            using (SqlConnection connection = TruyVanThongTin.Connect_SQL.ConnectSQL.getConnection())
            {
                string query = "UPDATE NhanVien SET HoTen = @HoTen,NgaySinh = @NgaySinh,SoDienThoai = @SoDienThoai, LoaiNguoiDung= @LoaiNguoiDung WHERE MaNhanVien = @MaNhanVien";
                Command = new SqlCommand(query, connection);
                Command.Parameters.AddWithValue("@MaNhanVien", nhanVien.MaNhanVien);
                Command.Parameters.AddWithValue("@HoTen", nhanVien.HoTen);
                Command.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
                Command.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai);
                Command.Parameters.AddWithValue("@LoaiNguoiDung", nhanVien.LoaiNguoiDung);

                try
                {
                    connection.Open();
                    Command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating employee: " + ex.Message);
                    return false;
                }
            }
        }
        public bool DeleteNhanVien(int maNV)
        {
            using (SqlConnection connection = TruyVanThongTin.Connect_SQL.ConnectSQL.getConnection())
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    string query1 = "DELETE FROM Admin WHERE MaNhanVien = @MaNhanVien";
                    using (SqlCommand command1 = new SqlCommand(query1, connection, transaction))
                    {
                        command1.Parameters.AddWithValue("@MaNhanVien", maNV);
                        command1.ExecuteNonQuery(); 
                    }
                    string query2 = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                    using (SqlCommand command2 = new SqlCommand(query2, connection, transaction))
                    {
                        command2.Parameters.AddWithValue("@MaNhanVien", maNV);
                        command2.ExecuteNonQuery(); 
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting employee: " + ex.Message);
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    return false;
                }
            }
        }

    }

}
