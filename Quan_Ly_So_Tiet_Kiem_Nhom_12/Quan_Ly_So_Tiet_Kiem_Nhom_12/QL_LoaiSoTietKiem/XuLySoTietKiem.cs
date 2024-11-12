using Guna.UI2.WinForms.Suite;
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
    public partial class XuLySoTietKiem : Form
    {
        public XuLySoTietKiem()
        {
            InitializeComponent();
        }

        private void btn_GuiSo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Gui So Tiet Kiem", "Khach hang Co Muon Them So Tiet Kiem", MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
               AddSoTietKiem addSoTietKiem = new AddSoTietKiem();
               
               addSoTietKiem.Show();
                
            }
        }
        private Form currentChilFoms;
        private void OpenChilForm(Form ChilFoms)
        {
            if (currentChilFoms != null)//kiểm tra khơi tạo rồi đóng
            {
                currentChilFoms.Close();
            }
            currentChilFoms = ChilFoms;
            ChilFoms.TopLevel = false;
            ChilFoms.FormBorderStyle = FormBorderStyle.None;
            ChilFoms.Dock = DockStyle.Fill;
            ShowChinhSo.Controls.Clear();
            ShowChinhSo.Controls.Add(ChilFoms);
            ShowChinhSo.Tag = ChilFoms;
            ChilFoms.BringToFront();
            ChilFoms.Show();

        }
        private void btn_rutso_Click(object sender, EventArgs e)
        {
            OpenChilForm( new QL_SoTietKiem() );
        }
    }
}
