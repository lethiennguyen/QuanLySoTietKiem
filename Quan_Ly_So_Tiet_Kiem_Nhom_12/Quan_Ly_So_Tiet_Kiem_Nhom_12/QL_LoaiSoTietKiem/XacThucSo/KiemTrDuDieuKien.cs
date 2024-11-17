using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_LoaiSoTietKiem.XacThucSo
{
    public partial class KiemTrDuDieuKien : Form
    {
        Boolean IsCapturing = false;
        private Point startPoint;
        private Point endPoint;
        Pen pen = new Pen(Color.Black);
        Glyph glyph = null;
        Signature signature = new Signature();

        public KiemTrDuDieuKien()
        {
            InitializeComponent();
        }

        public List<Glyph> SignatureGlyphs
        {
            get { return signature.Glyphs; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SignaturePanel.MouseMove += SignaturePanel_MouseMove;
            SignaturePanel.MouseUp += SignaturePanel_MouseUp;
            SignaturePanel.MouseDown += SignaturePanel_MouseDown;
            SignaturePanel.Cursor = Cursors.Cross;
        }

        private void SignaturePanel_MouseDown(object sender, MouseEventArgs e)
        {
            IsCapturing = true;
            glyph = new Glyph();
            startPoint = new Point();
            endPoint = new Point();
        }

        private void SignaturePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsCapturing)
            {
                if (startPoint.IsEmpty && endPoint.IsEmpty)
                {
                    endPoint = e.Location;
                }
                else
                {
                    startPoint = endPoint;
                    endPoint = e.Location;
                    Line line = new Line(startPoint, endPoint);
                    glyph.Lines.Add(line);
                    DrawLine(line);
                }
            }
        }

        private void DrawLine(Line line)
        {
            using (Graphics graphic = this.SignaturePanel.CreateGraphics())
            {
                graphic.DrawLine(pen, line.StartPoint, line.EndPoint);
            }
        }

        private void SignaturePanel_MouseUp(object sender, MouseEventArgs e)
        {
            IsCapturing = false; // Kết thúc chế độ vẽ
            if (glyph != null && glyph.Lines.Count > 0)
            {
                signature.Glyphs.Add(glyph); // Lưu nét vẽ
            }
        }

        private void SignaturePanel_Paint(object sender, PaintEventArgs e)
        {
            if (signature.Glyphs != null && signature.Glyphs.Count > 0)
            {
                using (Graphics graphic = e.Graphics)
                {
                    foreach (Glyph glyph in signature.Glyphs)
                    {
                        if (glyph.Lines != null && glyph.Lines.Count > 0)
                        {
                            foreach (Line line in glyph.Lines)
                            {
                                // Kiểm tra nếu điểm vẽ hợp lệ
                                if (line.StartPoint != null && line.EndPoint != null)
                                {
                                    graphic.DrawLine(Pens.Black, line.StartPoint, line.EndPoint);
                                }
                            }
                        }
                    }
                }
            }
        }
        // Sự kiện để chuyển chữ ký sang trang khác
        public List<Glyph> glyphs = new List<Glyph>();

        private void btn_import_Click(object sender, EventArgs e)
        {
            glyphs = signature.Glyphs;  // Cập nhật chữ ký khi nhấn "Import"
        }

        // Clear chữ ký khi nhấn nút "Clear"
        private void btn_clear_Click(object sender, EventArgs e)
        {
            signature = new Signature();
            ClearSignaturePanel();
        }

        private void ClearSignaturePanel()
        {
            using (Graphics graphic = this.SignaturePanel.CreateGraphics())
            {
                SolidBrush solidBrush = new SolidBrush(Color.LightBlue);
                graphic.FillRectangle(solidBrush, 0, 0, SignaturePanel.Width, SignaturePanel.Height);
            }
        }
    }
}
