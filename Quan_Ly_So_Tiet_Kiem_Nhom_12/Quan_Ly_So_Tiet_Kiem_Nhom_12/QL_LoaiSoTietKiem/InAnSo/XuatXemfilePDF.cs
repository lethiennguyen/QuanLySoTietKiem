using Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.ClassThongTin;
using Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.Connect_SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_LoaiSoTietKiem.InAnSo
{
    public partial class XuatXemfilePDF : Form
    {
        public int Maso {  get; set; }
        public XuatXemfilePDF(int maso)
        {
            InitializeComponent();
            Maso = maso;
            txt_maso.Text = maso.ToString();
        }
        public void LoadSo()
        {
            try
            {
               
                using (SqlConnection connection = TruyVanThongTin.Connect_SQL.ConnectSQL.getConnection())
                {
                    string query = "SELECT FileSo FROM SoTietKiem WHERE MaSoTietKiem = @Maso";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Maso", Maso);

                    connection.Open();

                    object fileData = command.ExecuteScalar();

                    if (fileData != null && fileData != DBNull.Value)
                    {
                        byte[] pdfBytes = (byte[])fileData;
                        string tempFilePath = Path.Combine(Path.GetTempPath(), $"FileSo_{Maso}.pdf");
                        File.WriteAllBytes(tempFilePath, pdfBytes);
                        axAcroPDF1.LoadFile(tempFilePath);
                        axAcroPDF1.setView("Fit");
                        axAcroPDF1.setShowToolbar(false);
                    }
                    else
                    {
                        MessageBox.Show("No PDF found for this account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }
    }
}
