using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_LoaiSoTietKiem
{
    public partial class AddSoTietKiem : Form
    {
        public AddSoTietKiem()
        {
            InitializeComponent();
            UpdateNgayGuiVaNgayHetHan();

        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            this.Close();      
        }

        private void cbb_kihan_SelectedIndexChanged(object sender, EventArgs e)
        {
            int months = 0;
            double interestRate = 0.0;

            switch (cbb_kihan.SelectedItem.ToString())
            {
                case "3 Tháng":
                    months = 3;
                    interestRate = 3.5; // example interest rate
                    break;
                case "6 Tháng":
                    months = 6;
                    interestRate = 4.0;
                    break;
                case "12 Tháng":
                    months = 12;
                    interestRate = 4.5;
                    break;
                case "24 Tháng":
                    months = 24;
                    interestRate = 5.0;
                    break;
            }

            // Update the labels with the selected term and interest rate
            lb_sothang.Text = $"{months} Tháng";
            lb_laixuat.Text = $"{interestRate}%";
        }

        private void DateTime_Now_NgayCap_ValueChanged(object sender, EventArgs e)
        {
            UpdateNgayGuiVaNgayHetHan();
        }
        private void UpdateNgayGuiVaNgayHetHan()
        {
            if (cbb_kihan.SelectedItem != null)
            {
                int months = 0;

                switch (cbb_kihan.SelectedItem.ToString())
                {
                    case "3 Tháng":
                        months = 3;
                        break;
                    case "6 Tháng":
                        months = 6;
                        break;
                    case "12 Tháng":
                        months = 12;
                        break;
                    case "24 Tháng":
                        months = 24;
                        break;
                }

                DateTime ngayCap = DateTime_Now_NgayCap.Value;
                DateTime ngayHetHan = ngayCap.AddMonths(months);
                lb_ngayphathanh.Text = ngayCap.ToString("dd/MM/yyyy");
                lb_ngayhethan.Text = ngayHetHan.ToString("dd/MM/yyyy");
            }
        }
    }
}
