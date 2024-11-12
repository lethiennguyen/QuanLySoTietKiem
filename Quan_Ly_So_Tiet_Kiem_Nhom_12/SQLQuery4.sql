-- Tạo cơ sở dữ liệu
CREATE DATABASE QuanLyTietKiem;
USE QuanLyTietKiem;

-- Bảng LoaiSoTietKiem: Lưu các loại sổ tiết kiệm dựa trên kỳ hạn
CREATE TABLE LoaiSoTietKiem (
    MaLoaiSo INT PRIMARY KEY,
    TenLoaiSo NVARCHAR(50) NOT NULL
);

-- Bảng LaiSuat: Lưu lãi suất dựa theo số tháng gửi
CREATE TABLE LaiSuat (
    MaLaiSuat INT PRIMARY KEY,
    SoThang INT UNIQUE NOT NULL, -- Kỳ hạn (3, 6, 12, 24)
    LaiSuatTheoThang DECIMAL(5, 2) NOT NULL -- Lãi suất cho kỳ hạn này
);

-- Bảng KhachHang: Lưu thông tin khách hàng
CREATE TABLE KhachHang (
    MaKhachHang INT PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    CMND NVARCHAR(20) UNIQUE NOT NULL,
    DiaChi NVARCHAR(200),
    SoDienThoai NVARCHAR(15)
);

-- Bảng NhanVien: Lưu thông tin nhân viên
CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    SoDienThoai NVARCHAR(15),
    LoaiNguoiDung NVARCHAR(20) CHECK (LoaiNguoiDung IN ('NhanVien', 'QuanLy'))
);

-- Bảng Admin: Chứa thông tin đăng nhập quản lý
CREATE TABLE Admin (
    MaAdmin INT PRIMARY KEY,
    MaNhanVien INT UNIQUE, -- Khóa ngoại liên kết với NhanVien
    TenDangNhap NVARCHAR(50) UNIQUE NOT NULL,
    MatKhau NVARCHAR(50) NOT NULL,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

-- Bảng SoTietKiem: Lưu các sổ tiết kiệm khách hàng mở
CREATE TABLE SoTietKiem (
    MaSoTietKiem INT PRIMARY KEY,
    MaNhanVien INT NOT NULL, -- Khóa ngoại liên kết với nhân viên lập sổ
    MaKhachHang INT NOT NULL, -- Khóa ngoại liên kết với khách hàng
    MaLoaiSo INT NOT NULL, -- Khóa ngoại liên kết với LoaiSoTietKiem
    MaLaiSuat INT NOT NULL, -- Khóa ngoại liên kết với LaiSuat
    NgayMoSo DATE DEFAULT GETDATE(),
    NgayDenHan DATE,
    SoTienGui DECIMAL(18, 2) CHECK (SoTienGui >= 200000),
    TrangThai BIT DEFAULT 1, -- 1: Đang mở, 0: Đã đóng
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaLoaiSo) REFERENCES LoaiSoTietKiem(MaLoaiSo),
    FOREIGN KEY (MaLaiSuat) REFERENCES LaiSuat(MaLaiSuat)
);

-- Bảng GiaoDich: Lưu các giao dịch gửi tiền và tất toán
CREATE TABLE GiaoDich (
    MaGiaoDich INT PRIMARY KEY,
    MaSoTietKiem INT NOT NULL, -- Khóa ngoại liên kết với SoTietKiem
    LoaiGiaoDich NVARCHAR(20) CHECK (LoaiGiaoDich IN ('Gui', 'TatToan')),
    NgayGiaoDich DATE DEFAULT GETDATE(),
    SoTien DECIMAL(18, 2),
    FOREIGN KEY (MaSoTietKiem) REFERENCES SoTietKiem(MaSoTietKiem)
);
