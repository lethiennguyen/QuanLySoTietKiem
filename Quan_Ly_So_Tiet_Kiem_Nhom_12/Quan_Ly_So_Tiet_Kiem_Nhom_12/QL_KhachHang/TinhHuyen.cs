using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_KhachHang
{
    internal class TinhHuyen
    {
        private Dictionary<string, List<string>> tinhHuyenData;
        public TinhHuyen()
        {
            tinhHuyenData = new Dictionary<string, List<string>>
            {
                       { "Hà Nội", new List<string>
            { "Quận Ba Đình", "Quận Hoàn Kiếm", "Quận Tây Hồ", "Quận Long Biên", "Quận Cầu Giấy", "Quận Đống Đa", "Quận Hai Bà Trưng", "Quận Hoàng Mai", "Quận Thanh Xuân", "Huyện Sóc Sơn", "Huyện Đông Anh", "Huyện Gia Lâm", "Quận Nam Từ Liêm", "Huyện Thanh Trì", "Quận Bắc Từ Liêm", "Huyện Mê Linh", "Quận Hà Đông", "Thị xã Sơn Tây", "Huyện Ba Vì", "Huyện Phúc Thọ", "Huyện Đan Phượng", "Huyện Hoài Đức", "Huyện Quốc Oai", "Huyện Thạch Thất", "Huyện Chương Mỹ", "Huyện Thanh Oai", "Huyện Thường Tín", "Huyện Phú Xuyên", "Huyện Ứng Hòa", "Huyện Mỹ Đức" }
        },
        { "Thành phố Hồ Chí Minh", new List<string>
            { "Quận 1", "Quận 12", "Quận Gò Vấp", "Quận Bình Thạnh", "Quận Tân Bình", "Quận Tân Phú", "Quận Phú Nhuận", "Thành phố Thủ Đức", "Quận 3", "Quận 10", "Quận 11", "Quận 4", "Quận 5", "Quận 6", "Quận 8", "Quận Bình Tân", "Quận 7", "Huyện Củ Chi", "Huyện Hóc Môn", "Huyện Bình Chánh", "Huyện Nhà Bè", "Huyện Cần Giờ" }
        },
        { "Hải Phòng", new List<string>
            { "Quận Hồng Bàng", "Quận Ngô Quyền", "Quận Lê Chân", "Quận Hải An", "Quận Kiến An", "Quận Đồ Sơn", "Quận Dương Kinh", "Huyện Thuỷ Nguyên", "Huyện An Dương", "Huyện An Lão", "Huyện Kiến Thuỵ", "Huyện Tiên Lãng", "Huyện Vĩnh Bảo", "Huyện Cát Hải", "Huyện Bạch Long Vĩ" }
        },
        { "Đà Nẵng", new List<string>
            { "Quận Liên Chiểu", "Quận Thanh Khê", "Quận Hải Châu", "Quận Sơn Trà", "Quận Ngũ Hành Sơn", "Quận Cẩm Lệ", "Huyện Hòa Vang", "Huyện Hoàng Sa" }
        },
        { "Cần Thơ", new List<string>
            { "Quận Ninh Kiều", "Quận Ô Môn", "Quận Bình Thuỷ", "Quận Cái Răng", "Quận Thốt Nốt", "Huyện Cờ Đỏ", "Huyện Thới Lai" }
        },
        { "An Giang", new List<string>
            { "Thành phố Long Xuyên", "Thành phố Châu Đốc", "Huyện An Phú", "Thị xã Tân Châu", "Huyện Phú Tân", "Huyện Châu Phú", "Huyện Tịnh Biên", "Huyện Tri Tôn", "Huyện Thoại Sơn" }
        },
        { "Bà Rịa – Vũng Tàu", new List<string>
            { "Thành phố Vũng Tàu", "Thành phố Bà Rịa", "Huyện Châu Đức", "Huyện Xuyên Mộc", "Huyện Long Điền", "Huyện Đất Đỏ", "Thị xã Phú Mỹ", "Huyện Côn Đảo" }
        },
        { "Bạc Liêu", new List<string>
            { "Thành phố Bạc Liêu", "Huyện Hồng Dân", "Huyện Phước Long", "Huyện Vĩnh Lợi", "Thị xã Giá Rai", "Huyện Đông Hải", "Huyện Hoà Bình" }
        },
        { "Bắc Giang", new List<string>
            { "Thành phố Bắc Giang", "Huyện Yên Thế", "Huyện Tân Yên", "Huyện Lạng Giang", "Huyện Lục Nam", "Huyện Lục Ngạn", "Huyện Sơn Động", "Huyện Yên Dũng", "Huyện Việt Yên", "Huyện Hiệp Hòa" }
        },
        { "Bắc Kạn", new List<string>
            { "Thành phố Bắc Kạn", "Huyện Pác Nặm", "Huyện Ba Bể", "Huyện Ngân Sơn", "Huyện Bạch Thông", "Huyện Chợ Đồn", "Huyện Chợ Mới", "Huyện Na Rì" }
        },
        { "Bắc Ninh", new List<string>
            { "Thành phố Bắc Ninh", "Huyện Yên Phong", "Huyện Quế Võ", "Huyện Tiên Du", "Thành phố Từ Sơn", "Huyện Thuận Thành", "Huyện Gia Bình", "Huyện Lương Tài" }
        },
        { "Bến Tre", new List<string>
            { "Thành phố Bến Tre", "Huyện Chợ Lách", "Huyện Mỏ Cày Nam", "Huyện Giồng Trôm", "Huyện Bình Đại", "Huyện Ba Tri", "Huyện Thạnh Phú", "Huyện Mỏ Cày Bắc" }
        },
        { "Bình Dương", new List<string>
            { "Thành phố Thủ Dầu Một", "Huyện Bàu Bàng", "Huyện Dầu Tiếng", "Thị xã Bến Cát", "Huyện Phú Giáo", "Thị xã Tân Uyên", "Thành phố Dĩ An", "Thành phố Thuận An", "Huyện Bắc Tân Uyên" }
        },
        { "Bình Định", new List<string>
            { "Thành phố Quy Nhơn", "Thị xã Hoài Nhơn", "Huyện Hoài Ân", "Huyện Phù Mỹ", "Huyện Vĩnh Thạnh", "Huyện Tây Sơn", "Huyện Phù Cát", "Thị xã An Nhơn", "Huyện Tuy Phước", "Huyện Vân Canh" }
        },
        { "Bình Phước", new List<string>
            { "Thị xã Phước Long", "Thành phố Đồng Xoài", "Thị xã Bình Long", "Huyện Bù Gia Mập", "Huyện Lộc Ninh", "Huyện Bù Đốp", "Huyện Hớn Quản", "Huyện Đồng Phú", "Huyện Bù Đăng", "Thị xã Chơn Thành", "Huyện Phú Riềng" }
        },
        { "Bình Thuận", new List<string>
            { "Thành phố Phan Thiết", "Thị xã La Gi", "Huyện Tuy Phong", "Huyện Bắc Bình", "Huyện Hàm Thuận Bắc", "Huyện Hàm Thuận Nam", "Huyện Tánh Linh", "Huyện Đức Linh", "Huyện Hàm Tân", "Huyện Phú Quí" }
        },
        { "Cà Mau", new List<string>
            { "Thành phố Cà Mau", "Huyện U Minh", "Huyện Thới Bình", "Huyện Trần Văn Thời", "Huyện Cái Nước", "Huyện Đầm Dơi", "Huyện Năm Căn", "Huyện Ngọc Hiển" }
        },
        { "Cao Bằng", new List<string>
            { "Thành phố Cao Bằng", "Huyện Bảo Lâm", "Huyện Bảo Lạc", "Huyện Hà Quảng", "Huyện Trùng Khánh", "Huyện Hạ Lang", "Huyện Quảng Hòa", "Huyện Hoà An", "Huyện Nguyên Bình", "Huyện Thạch An" }
        },
        { "Đắk Lắk", new List<string>
            { "Thành phố Buôn Ma Thuột", "Thị Xã Buôn Hồ", "Huyện Ea H'leo", "Huyện Ea Súp", "Huyện Buôn Đôn", "Huyện Cư M'gar", "Huyện Krông Búk", "Huyện Krông Năng", "Huyện Ea Kar", "Huyện M'Đrắk", "Huyện Krông Bông", "Huyện Krông Pắc", "Huyện Krông A Na", "Huyện Lắk", "Huyện Đắk Mil" }
        },
        { "Đắk Nông", new List<string>
            { "Thị xã Gia Nghĩa", "Huyện Đắk Glong", "Huyện Cư Jút", "Huyện Đắk Mil", "Huyện Đắk Song", "Huyện Krông Nô", "Huyện Tuy Đức" }
        },
        { "Điện Biên", new List<string>
            { "Thành phố Điện Biên Phủ", "Huyện Điện Biên", "Huyện Mường Chà", "Huyện Mường Nhé", "Huyện Tủa Chùa", "Huyện Nậm Pồ", "Huyện Mường Ảng", "Huyện Điện Biên Đông" }
        },
        { "Hà Giang", new List<string>
            { "Thành phố Hà Giang", "Huyện Đồng Văn", "Huyện Mèo Vạc", "Huyện Yên Minh", "Huyện Quản Bạ", "Huyện Vị Xuyên", "Huyện Bắc Mê", "Huyện Hoàng Su Phì", "Huyện Xín Mần", "Huyện Bắc Quang" }
        },
        { "Hà Nam", new List<string>
            { "Thành phố Phủ Lý", "Huyện Bình Lục", "Huyện Duy Tiên", "Huyện Kim Bảng", "Huyện Lý Nhân", "Huyện Thanh Liêm" }
        },
        { "Hà Tĩnh", new List<string>
            { "Thành phố Hà Tĩnh", "Huyện Hương Khê", "Huyện Hương Sơn", "Huyện Vũ Quang", "Huyện Can Lộc", "Huyện Thạch Hà", "Huyện Cẩm Xuyên", "Huyện Kỳ Anh", "Huyện Lộc Hà", "Thị xã Kỳ Anh" }
        },
        { "Hải Dương", new List<string>
            { "Thành phố Hải Dương", "Huyện Bình Giang", "Huyện Cẩm Giàng", "Huyện Gia Lộc", "Huyện Kim Thành", "Huyện Kinh Môn", "Huyện Nam Sách", "Huyện Ninh Giang", "Huyện Thanh Hà", "Huyện Tứ Kỳ" }
        },
        { "Hưng Yên", new List<string>
            { "Thành phố Hưng Yên", "Huyện Ân Thi", "Huyện Bình Gia", "Huyện Kim Động", "Huyện Khoái Châu", "Huyện Mỹ Hào", "Huyện Văn Lâm", "Huyện Văn Giang" }
        },
        { "Khánh Hoà", new List<string>
            { "Thành phố Nha Trang", "Thành phố Cam Ranh", "Huyện Cam Lâm", "Huyện Diên Khánh", "Huyện Khánh Vĩnh", "Huyện Vạn Ninh", "Huyện Ninh Hoà", "Huyện Trường Sa" }
        },
        { "Kiên Giang", new List<string>
            { "Thành phố Rạch Giá", "Thành phố Phú Quốc", "Huyện An Biên", "Huyện An Minh", "Huyện Châu Thành", "Huyện Giang Thành", "Huyện Hòn Đất", "Huyện Kiên Hải", "Huyện Tân Hiệp", "Huyện Vĩnh Thuận" }
        },
        { "Kon Tum", new List<string>
            { "Thành phố Kon Tum", "Huyện Đăk Glei", "Huyện Đăk Hà", "Huyện Kon Plong", "Huyện Ngọc Hồi", "Huyện Sa Thầy", "Huyện Tu Mơ Rông", "Huyện Đăk Tô" }
        },
        { "Lai Châu", new List<string>
            { "Thành phố Lai Châu", "Huyện Mường Tè", "Huyện Sìn Hồ", "Huyện Tam Đường", "Huyện Phong Thổ", "Huyện Nậm Nhùn", "Huyện Tân Uyên" }
        },
        { "Lạng Sơn", new List<string>
            { "Thành phố Lạng Sơn", "Huyện Bình Gia", "Huyện Chi Lăng", "Huyện Đình Lập", "Huyện Hữu Lũng", "Huyện Lộc Bình", "Huyện Cao Lộc", "Huyện Văn Quan", "Huyện Chi Lăng", "Huyện Văn Lãng" }
        },
        { "Lào Cai", new List<string>
            { "Thành phố Lào Cai", "Huyện Bát Xát", "Huyện Mường Khương", "Huyện Si Ma Cai", "Huyện Bắc Hà", "Huyện Văn Bàn", "Huyện Sa Pa", "Huyện Bảo Thắng" }
        },
        { "Long An", new List<string>
            { "Thành phố Tân An", "Huyện Bến Lức", "Huyện Châu Thành", "Huyện Đức Hòa", "Huyện Đức Huệ", "Huyện Mộc Hóa", "Huyện Thủ Thừa", "Huyện Tân Hưng", "Huyện Vĩnh Hưng", "Huyện Kiến Tường" }
        },
        { "Nam Định", new List<string>
            { "Thành phố Nam Định", "Huyện Giao Thủy", "Huyện Hải Hậu", "Huyện Mỹ Lộc", "Huyện Nam Trực", "Huyện Trực Ninh", "Huyện Xuân Trường", "Huyện Vụ Bản", "Huyện Ý Yên" }
        },
        { "Nghệ An", new List<string>
            { "Thành phố Vinh", "Thị xã Cửa Lò", "Huyện Anh Sơn", "Huyện Diễn Châu", "Huyện Đô Lương", "Huyện Hưng Nguyên", "Huyện Nghi Lộc", "Huyện Quế Phong", "Huyện Quỳ Châu", "Huyện Tân Kỳ", "Huyện Thái Hoà", "Huyện Thanh Chương", "Huyện Yên Thành", "Huyện Nam Đàn", "Huyện Con Cuông", "Huyện Kỳ Sơn", "Huyện Tương Dương" }
        },
        { "Ninh Bình", new List<string>
            { "Thành phố Ninh Bình", "Huyện Gia Viễn", "Huyện Hoa Lư", "Huyện Kim Sơn", "Huyện Yên Khánh", "Huyện Yên Mô", "Huyện Văn Lâm", "Huyện Nho Quan" }
        },
        { "Ninh Thuận", new List<string>
            { "Thành phố Phan Rang-Tháp Chàm", "Huyện Bác Ái", "Huyện Ninh Sơn", "Huyện Ninh Phước", "Huyện Thuận Bắc", "Huyện Thuận Nam" }
        },
        { "Phú Thọ", new List<string>
            { "Thành phố Việt Trì", "Huyện Cẩm Khê", "Huyện Đoan Hùng", "Huyện Hạ Hoà", "Huyện Lâm Thao", "Huyện Phù Ninh", "Huyện Tam Nông", "Huyện Thanh Ba", "Huyện Tân Sơn", "Huyện Thanh Sơn" }
        },
        { "Phú Yên", new List<string>
            { "Thành phố Tuy Hòa", "Huyện Đông Hòa", "Huyện Tây Hòa", "Huyện Phú Hòa", "Huyện Sông Hinh", "Huyện Đồng Xuân", "Huyện Tuy An", "Huyện Sơn Hòa" }
        },
        { "Quảng Bình", new List<string>
            { "Thành phố Đồng Hới", "Huyện Bố Trạch", "Huyện Quảng Trạch", "Huyện Tuyên Hóa", "Huyện Minh Hóa", "Huyện Lệ Thủy", "Huyện Quảng Ninh", "Huyện Hải Thủy" }
        },
        { "Quảng Nam", new List<string>
            { "Thành phố Tam Kỳ", "Thành phố Hội An", "Huyện Phú Ninh", "Huyện Thăng Bình", "Huyện Duy Xuyên", "Huyện Điện Bàn", "Huyện Nam Giang", "Huyện Đông Giang", "Huyện Đại Lộc", "Huyện Quế Sơn", "Huyện Hiệp Đức", "Huyện Núi Thành", "Huyện Phước Sơn", "Huyện Nam Trà My", "Huyện Bắc Trà My" }
        },
        { "Quảng Ngãi", new List<string>
            { "Thành phố Quảng Ngãi", "Huyện Bình Sơn", "Huyện Trà Bồng", "Huyện Tư Nghĩa", "Huyện Sơn Tịnh", "Huyện Nghĩa Hành", "Huyện Mộ Đức", "Huyện Đức Phổ", "Huyện Lý Sơn" }
        },
        { "Quảng Ninh", new List<string>
            { "Thành phố Hạ Long", "Thành phố Cẩm Phả", "Thành phố Uông Bí", "Thành phố Móng Cái", "Huyện Hải Hà", "Huyện Tiên Yên", "Huyện Đầm Hà", "Huyện Vân Đồn", "Huyện Hoành Bồ", "Huyện Bình Liêu", "Huyện Đạo Đức", "Huyện Yên Hưng" }
        },
        { "Sóc Trăng", new List<string>
            { "Thành phố Sóc Trăng", "Huyện Châu Thành", "Huyện Kế Sách", "Huyện Long Phú", "Huyện Mỹ Tú", "Huyện Ngã Năm", "Huyện Thạnh Trị", "Huyện Trần Đề", "Huyện Vĩnh Châu", "Huyện Sông Trăng" }
        },
        { "Sơn La", new List<string>
            { "Thành phố Sơn La", "Huyện Bắc Yên", "Huyện Mường La", "Huyện Quỳnh Nhai", "Huyện Sốp Cộp", "Huyện Mai Sơn", "Huyện Phù Yên", "Huyện Yên Châu", "Huyện Mộc Châu", "Huyện Thường Xuân", "Huyện Sông Mã" }
        },
        { "Tây Ninh", new List<string>
            { "Thành phố Tây Ninh", "Huyện Bến Cầu", "Huyện Châu Thành", "Huyện Dương Minh Châu", "Huyện Hòa Thành", "Huyện Tân Biên", "Huyện Trảng Bàng" }
        },
        { "Thái Bình", new List<string>
            { "Thành phố Thái Bình", "Huyện Hưng Hà", "Huyện Đông Hưng", "Huyện Thái Thụy", "Huyện Quỳnh Phụ", "Huyện Tiền Hải", "Huyện Vũ Thư" }
        },
        { "Thái Nguyên", new List<string>
            { "Thành phố Thái Nguyên", "Huyện Định Hóa", "Huyện Đồng Hỷ", "Huyện Phú Bình", "Huyện Phú Lương", "Huyện Võ Nhai", "Huyện Đại Từ", "Huyện Thành phố Sông Công" }
        },
        { "Thanh Hóa", new List<string>
            { "Thành phố Thanh Hóa", "Huyện Bá Thước", "Huyện Cẩm Thủy", "Huyện Đồng Sơn", "Huyện Hà Trung", "Huyện Hậu Lộc", "Huyện Lang Chánh", "Huyện Mường Lát", "Huyện Ngọc Lặc", "Huyện Như Thanh", "Huyện Như Xuân", "Huyện Tĩnh Gia", "Huyện Thường Xuân", "Huyện Vĩnh Lộc", "Huyện Yên Định", "Huyện Thạch Thành", "Huyện Đông Sơn", "Huyện Thanh Hóa", "Huyện Quảng Xương", "Huyện Nga Sơn" }
        },
        { "Thừa Thiên Huế", new List<string>
            { "Thành phố Huế", "Huyện A Lưới", "Huyện Phong Điền", "Huyện Phú Lộc", "Huyện Nam Đông", "Huyện Hương Trà", "Huyện Hương Thủy", "Huyện Quảng Điền", "Huyện Phú Vang", "Thị xã Hương Thủy" }
        },
        { "Tiền Giang", new List<string>
            { "Thành phố Mỹ Tho", "Huyện Châu Thành", "Huyện Cái Bè", "Huyện Cai Lậy", "Huyện Gò Công Đông", "Huyện Gò Công Tây", "Huyện Tân Phước", "Huyện Chợ Gạo", "Huyện Tân Phú Đông", "Huyện Chợ Gạo" }
        },
        { "Trà Vinh", new List<string>
            { "Thành phố Trà Vinh", "Huyện Càng Long", "Huyện Châu Thành", "Huyện Duyên Hải", "Huyện Tiểu Cần", "Huyện Trà Cú", "Huyện Cầu Kè", "Huyện Phước Long" }
        },
        { "Tuyên Quang", new List<string>
            { "Thành phố Tuyên Quang", "Huyện Chiêm Hóa", "Huyện Hàm Yên", "Huyện Lâm Bình", "Huyện Nà Hang", "Huyện Sơn Dương", "Huyện Yên Sơn" }
        },
        { "Vĩnh Long", new List<string>
            { "Thành phố Vĩnh Long", "Huyện Bình Minh", "Huyện Long Hồ", "Huyện Tam Bình", "Huyện Trà Ôn", "Huyện Vũng Liêm", "Huyện Mang Thít" }
        },
        { "Vĩnh Phúc", new List<string>
            { "Thành phố Vĩnh Yên", "Huyện Bình Xuyên", "Huyện Lập Thạch", "Huyện Tam Dương", "Huyện Tam Đảo", "Huyện Yên Lạc", "Huyện Vĩnh Tường", "Huyện Sông Lô" }
        },
        { "Yên Bái", new List<string>
            { "Thành phố Yên Bái", "Huyện Lục Yên", "Huyện Văn Chấn", "Huyện Văn Yên", "Huyện Trấn Yên", "Huyện Mù Cang Chải", "Huyện Yên Bình" }
        }
                // Thêm các tỉnh và quận/huyện khác ở đây
            };
        }
        // Phương thức để lấy tất cả các tỉnh
        public List<string> GetAllProvinces()
        {
            return new List<string>(tinhHuyenData.Keys);
        }

        // Phương thức để lấy quận/huyện theo tỉnh
        public List<string> GetDistrictsByProvince(string province)
        {
            if (tinhHuyenData.ContainsKey(province))
            {
                return tinhHuyenData[province];
            }
            return new List<string>();
        }
    }
}
