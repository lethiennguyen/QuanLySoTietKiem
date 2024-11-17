using Microsoft.ReportingServices.Diagnostics.Internal;
using Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.ClassThongTin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.Connect_SQL
{
    internal class ModifySoTietKiem
    {
        SqlDataAdapter dataAdapter;
        SqlCommand command;
        public ModifySoTietKiem()
        {

        }
        public bool addSoTietKiem(ClassSoTietKiem soTietKiem, out int MaSo)
        {
            MaSo = 0;
            using (SqlConnection connection = ConnectSQL.getConnection())
            {
                connection.Open();
                string query = "INSERT INTO SoTietKiem (MaNhanVien, MaKhachHang, MaLoaiSo, MaLaiSuat, NgayMoSo, NgayDenHan, SoTienGui) " +
                               "VALUES (@MaNhanVien, @MaKhachHang, @MaLoaiSo, @MaLaiSuat, @NgayMoSo, @NgayDenHan, @SoTienGui); SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNhanVien", soTietKiem.MaNV);
                command.Parameters.AddWithValue("@MaKhachHang", soTietKiem.MaKH);
                command.Parameters.AddWithValue("@MaLoaiSo", soTietKiem.MaLoaiSo);
                command.Parameters.AddWithValue("@MaLaiSuat", soTietKiem.MaLaiXuat);
                command.Parameters.AddWithValue("@NgayMoSo", soTietKiem.NgayMoSo);
                command.Parameters.AddWithValue("@NgayDenHan", soTietKiem.NgayHetHan);
                command.Parameters.AddWithValue("@SoTienGui", soTietKiem.SoTienGui);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    MaSo = Convert.ToInt32(result);
                    return true;
                }
            }
            return false;
        }
        public bool addGiaoDich(ClassGiaoDich classGiaoDich)
        {
            using (SqlConnection connection = ConnectSQL.getConnection())
            {
                connection.Open();
                string queryGiaoDich = "INSERT INTO GiaoDich (MaSoTietKiem, LoaiGiaoDich,NgayGiaoDich, SoTien) VALUES (@MaSoTietKiem, @LoaiGiaoDich,@NgayGiaoDich, @SoTien)";
                SqlCommand commandGiaoDich = new SqlCommand(queryGiaoDich, connection);
                commandGiaoDich.Parameters.AddWithValue("@MaSoTietKiem", classGiaoDich.MaSo);
                commandGiaoDich.Parameters.AddWithValue("@LoaiGiaoDich", classGiaoDich.LoaiGiaoDich);
                commandGiaoDich.Parameters.AddWithValue("@NgayGiaoDich", classGiaoDich.ngaygiaodich);
                commandGiaoDich.Parameters.AddWithValue("@SoTien", classGiaoDich.SoTienGui);
                commandGiaoDich.ExecuteNonQuery();
                return true;
            }
        }
        public bool deleteSoTietKiem(int MaSo)
        {
            using (SqlConnection connection = ConnectSQL.getConnection())
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM SoTietKiem WHERE MaSo = @MaSo";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaSo", MaSo);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // True nếu có bản ghi bị xóa, False nếu không
                }
                catch (Exception ex)
                {
                    // Log lỗi (nếu cần)
                    Console.WriteLine($"Error: {ex.Message}");
                    return false; // Xóa không thành công
                }
            }
        }
        public int GetMaSoTietKiem()
        {
            using (SqlConnection connection = ConnectSQL.getConnection())
            {
                string query = "SELECT SCOPE_IDENTITY()"; // Lấy ID mới nhất
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        public void SavePDFToDatabase(int MaSO, byte[] pdfData)
        {
            try
            {
                string query = "UPDATE SoTietKiem SET FileSo = @FileSo WHERE MaSoTietKiem = @MaSoTietKiem";
                using (SqlConnection connection = ConnectSQL.getConnection())
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FileSo", pdfData);
                    command.Parameters.AddWithValue("@MaSoTietKiem", MaSO);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("PDF đã được lưu vào cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể lưu PDF vào cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu PDF vào cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SavePDFChuKy(int MaSO, byte[] chuky)
        {
            try
            {
                string query = "UPDATE SoTietKiem SET ChuKy = @ChuKy WHERE MaSoTietKiem = @MaSoTietKiem";
                using (SqlConnection connection = ConnectSQL.getConnection())
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ChuKy", chuky);
                    command.Parameters.AddWithValue("@MaSoTietKiem", MaSO);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("PDF đã được lưu vào cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể lưu PDF vào cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu PDF vào cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public byte[] SlecthPDFToDatabase(int MaSO)
        {
            try
            {
                string query = "SELECT FileSo FROM SoTietKiem WHERE MaSoTietKiem = @MaSoTietKiem";

                using (SqlConnection connection = ConnectSQL.getConnection())
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaSoTietKiem", MaSO);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] pdfBytes = reader["FileSo"] as byte[];

                            if (pdfBytes != null)
                            {
                                return pdfBytes;
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy PDF trong cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu với Mã Sổ Tiết Kiệm này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải PDF từ cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


    }
}
