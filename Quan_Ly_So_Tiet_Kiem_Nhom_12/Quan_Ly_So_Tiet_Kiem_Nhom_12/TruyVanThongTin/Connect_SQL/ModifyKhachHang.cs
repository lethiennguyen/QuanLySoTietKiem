using Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.ClassThongTin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.Connect_SQL
{
    internal class ModifyKhachHang
    {

        SqlDataAdapter dataAdapter;
        SqlCommand command;
        public ModifyKhachHang()
        {
           
        }
        public DataTable getKhachHang()
        {
            DataTable dataTable = new DataTable();
            string Sql = "select * from dbo.KhachHang";
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
        public DataTable getKhachHangTaoSo()
        {
            DataTable dataTable = new DataTable();
            string Sql = "select *  from dbo.KhachHang";
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
        public bool AddCustomer(ClassKhachHang khachHang)
        {
            try
            {

                using (SqlConnection connection = TruyVanThongTin.Connect_SQL.ConnectSQL.getConnection())
                {
                    string query = "INSERT INTO KhachHang (HoTen,CMND, DiaChi, SoDienThoai, Tinh,Huyen) VALUES (@HoTen , @CMND,@DiaChi, @SoDienThoai ,@Huyen, @Tinh)";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@HoTen", khachHang.HoTen);        
                    command.Parameters.AddWithValue("@CMND", khachHang.CMND);
                    command.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                    command.Parameters.AddWithValue("@SoDienThoai", khachHang.SoDienThoai);
                    command.Parameters.AddWithValue("@Huyen", khachHang.Quan);
                    command.Parameters.AddWithValue("@Tinh", khachHang.ThanhPho);
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding customer: " + ex.Message);
                return false;
            }
           
            
        }
        public bool DeleteKhachHang(int maKH)
        {
            using (SqlConnection connection = TruyVanThongTin.Connect_SQL.ConnectSQL.getConnection())
            {
                string query = "DELETE FROM Khachhang WHERE MaKhachHang = @MaKhachHang";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaKhachHang", maKH);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting customer: " + ex.Message);
                    return false;
                }
            }
        }
        public bool UpdateCustomer(ClassKhachHang khachHang)
        {
            try
            {
                using (SqlConnection connection = TruyVanThongTin.Connect_SQL.ConnectSQL.getConnection())
                {
                    string query = "UPDATE KhachHang SET HoTen = @HoTen, Tinh = @Tinh, Huyen = @Huyen, CMND = @CMND, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai WHERE MaKhachHang = @MaKhachHang";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                       
                        command.Parameters.AddWithValue("@HoTen", khachHang.HoTen);
                        command.Parameters.AddWithValue("@Tinh", khachHang.ThanhPho);
                        command.Parameters.AddWithValue("@Huyen", khachHang.Quan);
                        command.Parameters.AddWithValue("@CMND", khachHang.CMND);
                        command.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                        command.Parameters.AddWithValue("@SoDienThoai", khachHang.SoDienThoai);
                        command.Parameters.AddWithValue("@MaKhachHang", khachHang.MaKhachHang); 
                       
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating customer: " + ex.Message);
                return false;
            }
        }
        public bool Search_CMND(ClassKhachHang classKhachHang)
        {
            bool isFound = false;
            using (SqlConnection sqlConnection = TruyVanThongTin.Connect_SQL.ConnectSQL.getConnection())
            {
                string query = "SELECT TOP 1 MaKhachHang, HoTen, CMND, DiaChi, Huyen,SoDienThoai,Tinh FROM dbo.KhachHang WHERE CMND = @CMND";
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@CMND", classKhachHang.CMND); // Chuyển tham số đúng

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Nếu tìm thấy khách hàng, gán dữ liệu vào đối tượng classKhachHang
                                classKhachHang.MaKhachHang = int.Parse(reader["MaKhachHang"].ToString());
                                classKhachHang.HoTen = reader["HoTen"].ToString();
                                classKhachHang.DiaChi = reader["DiaChi"].ToString();
                                classKhachHang.Quan = reader["Huyen"].ToString();
                                classKhachHang.ThanhPho = reader["Tinh"].ToString();
                                classKhachHang.SoDienThoai = reader["SoDienThoai"].ToString();

                                isFound = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return isFound; // Trả về true nếu tìm thấy khách hàng
        }

    }
}
