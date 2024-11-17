using Quan_Ly_So_Tiet_Kiem_Nhom_12.Connect_SQL;
using Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_LoaiSoTietKiem.XacThucSo;
using Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.ClassThongTin;
using Quan_Ly_So_Tiet_Kiem_Nhom_12.TruyVanThongTin.Connect_SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors; // For setting font colors
using System.IO;           // For handling file paths and reading/writing files
using System.Data.SqlClient; // For saving the PDF to SQL Server
using iText.IO.Font;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.IO.Image;
using DrawingImage = System.Drawing.Image;
using PdfImage = iText.Layout.Element.Image;


namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_LoaiSoTietKiem
{
    public partial class AddSoTietKiem : Form
    {
        private int MaNV {  get; set; }
        private string TenNV {  get; set; }
        private ModifySoTietKiem ModifySoTietKiem;
        public AddSoTietKiem()
        {
            InitializeComponent();
        }
        public AddSoTietKiem(int maNV, string tenNV)
        {
            InitializeComponent();
            LoadLoaiSoTietKiemData();
            UpdateNgayGuiVaNgayHetHan();
            lb_maNv.Text = maNV.ToString();
            lb_TenNV.Text = tenNV;    
        }
        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            this.Close();      
        }
        // Method to load the data into the ComboBox
        private void LoadLoaiSoTietKiemData()
        {
            var loaiSoTietKiemData = TruyVanThongTin.Connect_SQL.MdifyLoaiSo.GetLoaiSoTietKiemData();
            cbb_kihan.DisplayMember = "Item1"; 
            cbb_kihan.ValueMember = "Item2";   
            cbb_kihan.DataSource = loaiSoTietKiemData;
        }
        private void cbb_kihan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_kihan.SelectedItem != null)
            {
                // Get the selected item
                var selectedItem = (Tuple<string, int, decimal,int,int>)cbb_kihan.SelectedItem;

                // Display the corresponding SoThang (months) and LaiSuat (interest rate)
                lb_sothang.Text = $"Số Tháng: {selectedItem.Item2}";
                lb_laixuat.Text = $"Lãi Suất: {selectedItem.Item3}%";
                UpdateNgayGuiVaNgayHetHan();
            }
        }

        private void DateTime_Now_NgayCap_ValueChanged(object sender, EventArgs e)
        {
            UpdateNgayGuiVaNgayHetHan();
        }
        private void UpdateNgayGuiVaNgayHetHan()
        {
            if (cbb_kihan.SelectedItem != null)
            {
               
                 var selectedItem = (Tuple<string, int, decimal,int,int>)cbb_kihan.SelectedItem;
                int months = selectedItem.Item2;
                DateTime ngayCap = DateTime_Now_NgayCap.Value;
                DateTime ngayHetHan = ngayCap.AddMonths(months);
                lb_ngayphathanh.Text = ngayCap.ToString("dd/MM/yyyy");
                lb_ngayhethan.Text = ngayHetHan.ToString("dd/MM/yyyy");
            }
        }
        public List<Glyph> glyphs { get; set; }
        private void btn_Ky_Click(object sender, EventArgs e)
        {
            XacThucSo.KiemTrDuDieuKien kiemTrDuDieu = new XacThucSo.KiemTrDuDieuKien();
            kiemTrDuDieu.ShowDialog();
            // Lấy chữ ký từ form KiemTrDuDieuKien sau khi đóng
            if (kiemTrDuDieu.SignatureGlyphs != null && kiemTrDuDieu.SignatureGlyphs.Count > 0)
            {
                // Cập nhật chữ ký và vẽ lại
                this.glyphs = kiemTrDuDieu.SignatureGlyphs;
                DrawSignature(); // Vẽ chữ ký lên SignaturePanel
            }
        }
        private void DrawSignature()
        {
            if (glyphs == null || glyphs.Count == 0)
                return;
            // Xác định kích thước chữ ký hiện tại
            var bounds = GetSignatureBounds();
            if (bounds.Width == 0 || bounds.Height == 0)
                return;
            // Tính toán tỷ lệ để co giãn chữ ký vừa với SignaturePanel
            float scaleX = SignaturePanel.Width / bounds.Width;
            float scaleY = SignaturePanel.Height / bounds.Height;
            float scale = Math.Min(scaleX, scaleY); // Chọn tỷ lệ nhỏ hơn để đảm bảo không bị cắt
            // Dịch chữ ký vào giữa panel
            float offsetX = (SignaturePanel.Width - bounds.Width * scale) / 2;
            float offsetY = (SignaturePanel.Height - bounds.Height * scale) / 2;
            // Vẽ chữ ký với tỷ lệ co
            using (Graphics graphic = SignaturePanel.CreateGraphics())
            {
                graphic.Clear(System.Drawing.Color.White); // Xóa vùng vẽ
                foreach (Glyph glyph in glyphs)
                {
                    foreach (Line line in glyph.Lines)
                    {
                        Point scaledStart = ScalePoint(line.StartPoint, bounds.MinX, bounds.MinY, scale, offsetX, offsetY);
                        Point scaledEnd = ScalePoint(line.EndPoint, bounds.MinX, bounds.MinY, scale, offsetX, offsetY);
                        graphic.DrawLine(Pens.Black, scaledStart, scaledEnd);
                    }
                }
            }
        }
        private (float MinX, float MinY, float Width, float Height) GetSignatureBounds()
        {
            if (glyphs == null || glyphs.Count == 0)
                return (0, 0, 0, 0);

            float minX = float.MaxValue, minY = float.MaxValue;
            float maxX = float.MinValue, maxY = float.MinValue;

            foreach (Glyph glyph in glyphs)
            {
                foreach (Line line in glyph.Lines)
                {
                    minX = Math.Min(minX, Math.Min(line.StartPoint.X, line.EndPoint.X));
                    minY = Math.Min(minY, Math.Min(line.StartPoint.Y, line.EndPoint.Y));
                    maxX = Math.Max(maxX, Math.Max(line.StartPoint.X, line.EndPoint.X));
                    maxY = Math.Max(maxY, Math.Max(line.StartPoint.Y, line.EndPoint.Y));
                }
            }

            return (minX, minY, maxX - minX, maxY - minY);
        }

        // Hàm hỗ trợ chuyển đổi tọa độ
        private Point ScalePoint(Point original, float minX, float minY, float scale, float offsetX, float offsetY)
        {
            int newX = (int)((original.X - minX) * scale + offsetX);
            int newY = (int)((original.Y - minY) * scale + offsetY);
            return new Point(newX, newY);
        }
        private byte[] ConvertGlyphsToBinary(List<Glyph> glyphs)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap bitmap = new Bitmap(SignaturePanel.Width, SignaturePanel.Height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(System.Drawing.Color.White); // Xóa nền
                    foreach (Glyph glyph in glyphs)
                    {
                        foreach (Line line in glyph.Lines)
                        {
                            g.DrawLine(Pens.Black, line.StartPoint, line.EndPoint);
                        }
                    }
                }
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        private Bitmap GetSignatureAsImage()
        {
            if (glyphs == null || glyphs.Count == 0)
                return null;

            // Tạo bitmap với kích thước của SignaturePanel
            Bitmap signatureImage = new Bitmap(SignaturePanel.Width, SignaturePanel.Height);
            using (Graphics graphics = Graphics.FromImage(signatureImage))
            {
                graphics.Clear(System.Drawing.Color.White); // Màu nền
                var bounds = GetSignatureBounds();
                if (bounds.Width == 0 || bounds.Height == 0)
                    return null;

                // Tính toán tỷ lệ co
                float scaleX = SignaturePanel.Width / bounds.Width;
                float scaleY = SignaturePanel.Height / bounds.Height;
                float scale = Math.Min(scaleX, scaleY);
                float offsetX = (SignaturePanel.Width - bounds.Width * scale) / 2;
                float offsetY = (SignaturePanel.Height - bounds.Height * scale) / 2;

                // Vẽ chữ ký
                foreach (Glyph glyph in glyphs)
                {
                    foreach (Line line in glyph.Lines)
                    {
                        Point scaledStart = ScalePoint(line.StartPoint, bounds.MinX, bounds.MinY, scale, offsetX, offsetY);
                        Point scaledEnd = ScalePoint(line.EndPoint, bounds.MinX, bounds.MinY, scale, offsetX, offsetY);
                        graphics.DrawLine(Pens.Black, scaledStart, scaledEnd);
                    }
                }
            }

            return signatureImage;
        }

        private void btn_xacnhanky_Click(object sender, EventArgs e)
        {          
        }
        private void SignaturePanel_Paint(object sender, PaintEventArgs e)
        {
        }
        private void add_so_Click(object sender, EventArgs e)
        {
            try
            {   
                int MaSO = 0;              
                string GuiSO = "Gui";
                int maNhanVien = int.Parse(this.lb_maNv.Text); // Từ TextBox
                int maKhachHang = int.Parse(this.txtMaKH.Text); // Từ TextBox
                int maLoaiSo = ((Tuple<string, int, decimal, int, int>)cbb_kihan.SelectedItem).Item4;
                int maLaiSuat = ((Tuple<string, int, decimal, int, int>)cbb_kihan.SelectedItem).Item5;
                DateTime ngayMoSo = DateTime.ParseExact(lb_ngayphathanh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime ngayHetHan = DateTime.ParseExact(lb_ngayhethan.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                decimal soTienGui = Convert.ToDecimal(txtTienGui.Text);
                ClassSoTietKiem soTietKiem = new ClassSoTietKiem(
                    maNhanVien,
                    maKhachHang,
                    maLoaiSo,
                    maLaiSuat,
                    ngayMoSo,
                    ngayHetHan,
                    soTienGui
                );
                try
                {
                    ModifySoTietKiem modify = new ModifySoTietKiem();
                    if (modify.addSoTietKiem(soTietKiem, out MaSO))
                    {
                        MessageBox.Show("Thêm sổ tiết kiệm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClassGiaoDich classGiao = new ClassGiaoDich(MaSO, GuiSO, ngayMoSo, soTienGui);
                        if (modify.addGiaoDich(classGiao))
                        {
                            MessageBox.Show("Giao dich thanh cong!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var selectedItem = (Tuple<string, int, decimal, int, int>)cbb_kihan.SelectedItem;
                            int SoThang = selectedItem.Item2;
                            decimal laixuat = selectedItem.Item3;
                            string TenKH = txtTenKH.Text;
                            string CMND = txtCMND.Text;
                            string SoDienThoai = txt_SDT.Text;
                            string Tinh = txtThanhPho.Text;
                            string Huyen = txtQuan.Text;
                            string DiaChi = txtDiaChi.Text;
                            string kihan = cbb_kihan.Text;
                            GeneratePDF(MaSO, maKhachHang, maNhanVien, TenKH,  CMND,  SoDienThoai,
                                 Tinh, Huyen,  DiaChi,  kihan, SoThang, laixuat, ngayMoSo, ngayHetHan,
                                  GuiSO,  soTienGui);
                            //luu chư ky
                            if (glyphs != null && glyphs.Count > 0)
                            {
                                byte[] signatureData = ConvertGlyphsToBinary(glyphs);
                                modify.SavePDFChuKy(MaSO, signatureData);
                            }
                            else
                            {
                                MessageBox.Show("Không có chữ ký để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Giao dich that bai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            modify.deleteSoTietKiem(MaSO);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thêm sổ tiết kiệm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ChuKy(int Maso)
        {

        }
        public void GeneratePDF(int MaSO, int MaKH, int MaNv, string TenKH, string CMND, string SoDienThoai,
                          string Tinh, string Huyen, string DiaChi, string kihan, int SoThang, decimal laixuat, DateTime ngayMoSo, DateTime ngayhethan,
                          string GuiSO, decimal soTienGui)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Lưu Hoá Đơn";
                saveFileDialog.FileName = $"SoTietKiem_{MaSO}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {

                        using (PdfWriter writer = new PdfWriter(filePath))
                        using (PdfDocument pdf = new PdfDocument(writer))
                        using (Document document = new Document(pdf))
                        {
                            //Load Vietnamese font
                            string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NgonNgu", "vuTimesBold.ttf");
                            PdfFont font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);
                            document.SetFont(font);
                            document.SetFontSize(10);
                            // Set font cho toàn bộ document
                            document.SetFont(font);
                            Div div = new Div()
                           .SetWidth(pdf.GetDefaultPageSize().GetWidth())  // Chiều rộng full trang
                           .SetHeight(50)  // Chiều cao tùy chỉnh (ví dụ: 100)
                           .SetBackgroundColor(new DeviceRgb(187, 75, 92))  // Màu nền xám
                           .SetMargin(0)  // Không có khoảng cách ngoài
                           .SetPadding(0)  // Khoảng cách giữa viền và văn bản
                           .SetTextAlignment(TextAlignment.LEFT);  // Căn giữa văn bản

                            // Thêm văn bản vào Div
                            div.Add(new Paragraph("Ngân Hàng Nhom 12")
                                .SetFontSize(30)
                                .SetBold()
                                .SetPadding(10)
                                .SetFontColor(ColorConstants.WHITE));

                            // Thêm Div vào tài liệu
                            document.Add(div);
                            // Tiêu đề
                            document.Add(new Paragraph("SỔ TIẾT KIỆM")
                                .SetFontSize(20).SetMultipliedLeading(1.5f).SetFontColor(new DeviceRgb(187, 75, 92))
                                .SetBold()
                                .SetTextAlignment(TextAlignment.CENTER));
                            document.Add(new Paragraph("Term Savings Book")
                               .SetFontSize(10).SetMultipliedLeading(0.8f).SetFontColor(new DeviceRgb(187, 75, 92))
                               .SetBold()
                               .SetTextAlignment(TextAlignment.CENTER));
                            // Tạo một chuỗi dấu chấm đủ dài để trải đều trên toàn bộ chiều rộng trang
                            string dots = new string('.', (int)(pdf.GetDefaultPageSize().GetWidth() / 100));  // Mỗi dấu chấm có chiều rộng khoảng 6 điểm
                            // Thông tin khách hàng
                            document.Add(new Paragraph($"- Mã Sổ Tiết Kiệm: {MaSO}").SetTextAlignment(TextAlignment.LEFT).SetMultipliedLeading(3.5f));
                            document.Add(new Paragraph(dots).SetTextAlignment(TextAlignment.LEFT).SetFontSize(4));
                            document.Add(new Paragraph($"- Họ Tên Khách Hàng: {TenKH}").SetTextAlignment(TextAlignment.LEFT).SetMultipliedLeading(1.5f));
                            document.Add(new Paragraph(dots).SetTextAlignment(TextAlignment.LEFT).SetFontSize(4));
                            document.Add(new Paragraph($"- Địa Chỉ: {DiaChi}, {Huyen}, {Tinh}").SetTextAlignment(TextAlignment.LEFT).SetMultipliedLeading(1.5f));
                            document.Add(new Paragraph(dots).SetTextAlignment(TextAlignment.LEFT).SetFontSize(4));
                            document.Add(new Paragraph($"- Số Điện Thoại: {SoDienThoai}").SetTextAlignment(TextAlignment.LEFT).SetMultipliedLeading(1.5f));
                            document.Add(new Paragraph(dots).SetTextAlignment(TextAlignment.LEFT).SetFontSize(4));
                           
                            // Chi tiết tài khoản
                            document.Add(new Paragraph($"- Ngày Mở Sổ: {ngayMoSo:dd/MM/yyyy}").SetTextAlignment(TextAlignment.LEFT).SetMultipliedLeading(3.5f));
                            document.Add(new Paragraph(dots).SetTextAlignment(TextAlignment.LEFT).SetFontSize(4));
                            document.Add(new Paragraph($"- Kỳ Hạn: {kihan}                      Số Tháng  {SoThang} tháng").SetTextAlignment(TextAlignment.LEFT).SetMultipliedLeading(1.5f));
                            document.Add(new Paragraph(dots).SetTextAlignment(TextAlignment.LEFT).SetFontSize(4));
                            document.Add(new Paragraph($"- Lãi Suất: {laixuat}%").SetTextAlignment(TextAlignment.LEFT).SetMultipliedLeading(1.5f));
                            document.Add(new Paragraph(dots).SetTextAlignment(TextAlignment.LEFT).SetFontSize(4));
                            document.Add(new Paragraph($"- Ngày Hết Hạn: {ngayhethan:dd/MM/yyyy}").SetTextAlignment(TextAlignment.LEFT).SetMultipliedLeading(1.5f));
                            document.Add(new Paragraph(dots).SetTextAlignment(TextAlignment.LEFT).SetFontSize(4));
                            document.Add(new Paragraph($"- Số Tiền Gửi: {soTienGui:N0} VND").SetTextAlignment(TextAlignment.LEFT).SetMultipliedLeading(1.5f));
                            document.Add(new Paragraph(dots).SetTextAlignment(TextAlignment.LEFT).SetFontSize(4));
                            document.Add(new Paragraph($"- Loại Giao Dịch: Gui So").SetTextAlignment(TextAlignment.LEFT).SetMultipliedLeading(1.5f));
                            document.Add(new Paragraph(dots).SetTextAlignment(TextAlignment.LEFT).SetFontSize(4));

                            Div taichuky = new Div()
                             .SetWidth(100)  // Chiều rộng của Div
                             .SetHeight(100)  // Chiều cao của Div
                             .SetMarginTop(20)  // Khoảng cách trên
                             .SetTextAlignment(TextAlignment.CENTER);  // Căn giữa văn bản và hình ảnh
                            // Thêm các đoạn văn bản vào Div
                            taichuky.Add(new Paragraph("Khách hàng ký tên").SetFontSize(10));
                            taichuky.Add(new Paragraph("(Ký rõ họ tên)").SetFontSize(8).SetBold());
                            // Lấy ảnh chữ ký
                            Bitmap signatureImage = GetSignatureAsImage();
                            if (signatureImage != null)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    // Chuyển đổi ảnh chữ ký thành byte array
                                    signatureImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    byte[] imageBytes = ms.ToArray();

                                    // Tạo ảnh PDF từ byte array
                                    iText.Layout.Element.Image signaturePdfImage =
                                        new iText.Layout.Element.Image(ImageDataFactory.Create(imageBytes));
                                    // Đặt kích thước ảnh
                                    signaturePdfImage.SetWidth(100);  // Chiều rộng ảnh
                                    signaturePdfImage.SetHeight(50);  // Chiều cao ảnh

                                    // Thêm ảnh vào trong Div
                                    taichuky.Add(signaturePdfImage);
                                }
                            }

                            // Thêm Div chứa chữ ký vào tài liệu PDF
                            document.Add(taichuky);

                            // Lời cảm ơn
                            document.Add(new Paragraph("Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi!")
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetFontSize(14)
                                .SetBold()
                                .SetFontColor(ColorConstants.BLUE));
                            Div div1 = new Div()
                           .SetWidth(pdf.GetDefaultPageSize().GetWidth())  // Chiều rộng full trang
                           .SetHeight(50)  // Chiều cao tùy chỉnh (ví dụ: 100)
                           .SetBackgroundColor(new DeviceRgb(187, 75, 92))  // Màu nền xám
                           .SetMargin(0)  // Không có khoảng cách ngoài
                           .SetPadding(0)  // Khoảng cách giữa viền và văn bản
                           .SetTextAlignment(TextAlignment.LEFT);  // Căn giữa văn bản
                            document.Add(div1);
                        }
                        // Save PDF to database
                        byte[] pdfBytes = File.ReadAllBytes(filePath);
                        ModifySoTietKiem modifySoTietKiem = new ModifySoTietKiem();
                        modifySoTietKiem.SavePDFToDatabase(MaSO, pdfBytes);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tạo PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_addKH_Click(object sender, EventArgs e)
        {
            string cmnd = txtCMND.Text; // Giả sử bạn nhập CMND vào TextBox có tên txtCMND

            ModifyKhachHang modifyKhachHang = new ModifyKhachHang();
            ClassKhachHang khachHang = new ClassKhachHang(cmnd);

            // Kiểm tra nếu tìm thấy khách hàng
            if (modifyKhachHang.Search_CMND(khachHang))
            {
                // Nếu tìm thấy khách hàng, hiển thị thông tin lên các TextBox
                txtMaKH.Text = khachHang.MaKhachHang.ToString();
                txtTenKH.Text = khachHang.HoTen;
                txtDiaChi.Text = khachHang.DiaChi;
                txtQuan.Text = khachHang.Quan;
                txtThanhPho.Text = khachHang.ThanhPho;
                txt_SDT.Text = khachHang.SoDienThoai;
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng với CMND: " + cmnd);
            }
        }
    }
    
}
