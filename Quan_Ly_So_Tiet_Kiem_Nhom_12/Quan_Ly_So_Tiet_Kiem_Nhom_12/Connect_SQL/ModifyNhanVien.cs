using Quan_Ly_So_Tiet_Kiem_Nhom_12.ClassThongTin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.Connect_SQL
{
    internal class ModifyNhanVien
    {
        public bool AddNhanVien(ClassNhanVien nhanVien)
        {
            try
            {
                using (SqlConnection conn = ConnectSQL.getConnection())
                {
                    conn.Open();

                    // Start a transaction to insert both employee and admin data
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Insert into NhanVien table
                        string queryNhanVien = "INSERT INTO NhanVien (MaNhanVien, HoTen, NgaySinh, SoDienThoai, LoaiNguoiDung) " +
                                               "VALUES (@MaNhanVien, @HoTen, @NgaySinh, @SoDienThoai, @LoaiNguoiDung)";

                        SqlCommand cmdNhanVien = new SqlCommand(queryNhanVien, conn, transaction);
                        cmdNhanVien.Parameters.AddWithValue("@MaNhanVien", nhanVien.MaNhanVien);
                        cmdNhanVien.Parameters.AddWithValue("@HoTen", nhanVien.HoTen);
                        cmdNhanVien.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh.HasValue ? (object)nhanVien.NgaySinh.Value : DBNull.Value);
                        cmdNhanVien.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai);
                        cmdNhanVien.Parameters.AddWithValue("@LoaiNguoiDung", nhanVien.LoaiNguoiDung);

                        int resultNhanVien = cmdNhanVien.ExecuteNonQuery();

                        // After inserting into NhanVien, get the MaNhanVien to insert into Admin
                        string queryAdmin = "INSERT INTO Admin (MaNhanVien, TenDangNhap, MatKhau) " +
                                            "VALUES (@MaNhanVien, @TenDangNhap, @MatKhau)";

                        SqlCommand cmdAdmin = new SqlCommand(queryAdmin, conn, transaction);
                        cmdAdmin.Parameters.AddWithValue("@MaNhanVien", nhanVien.MaNhanVien);
                        cmdAdmin.Parameters.AddWithValue("@TenDangNhap", nhanVien.TenDangNhap);
                        cmdAdmin.Parameters.AddWithValue("@MatKhau", nhanVien.MatKhau);

                        int resultAdmin = cmdAdmin.ExecuteNonQuery();

                        if (resultNhanVien > 0 && resultAdmin > 0)
                        {
                            // Commit the transaction
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            // Rollback the transaction if something fails
                            transaction.Rollback();
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Rollback in case of an error
                        transaction.Rollback();
                         
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }
    }
    
}
