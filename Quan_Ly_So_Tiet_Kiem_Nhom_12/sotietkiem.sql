-- Tạo cơ sở dữ liệu
CREATE DATABASE SoTietKiem;

-- Sử dụng cơ sở dữ liệu
USE SoTietKiem;

-- Tạo bảng Loại Sổ Tiết Kiệm
CREATE TABLE LoaiSoTietKiem (
    MaLoaiSo INT PRIMARY KEY,
    TenLoaiSo NVARCHAR(50),
    LaiSuatTheoThang DECIMAL(5, 2),
    SoThang INT
);

-- Thêm dữ liệu mẫu cho bảng Loại Sổ Tiết Kiệm
INSERT INTO LoaiSoTietKiem (MaLoaiSo, TenLoaiSo, LaiSuatTheoThang, SoThang) VALUES
(1, N'Không kỳ hạn', 0.5, 0),
(2, N'3 tháng', 1.2, 3),
(3, N'6 tháng', 1.5, 6);

-- Tạo bảng Khách Hàng
CREATE TABLE KhachHang (
    MaKhachHang INT PRIMARY KEY,
    HoTenKhachHang NVARCHAR(100),
    SoChungMinhNhanDan NVARCHAR(20),
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(15)
);

-- Tạo bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY,
    HoTen NVARCHAR(100),
    NgaySinh DATE,
    SoDienThoai NVARCHAR(15),
    MatKhau NVARCHAR(255),
    LoaiNguoiDung NVARCHAR(50)
);

-- Tạo bảng Sổ Tiết Kiệm
CREATE TABLE SoTietKiem (
    MaSoTietKiem INT PRIMARY KEY,
    MaNhanVien INT,
    MaKhachHang INT,
    MaLoaiSo INT,
    LaiSuatTheoThang DECIMAL(5, 2),
    NgayMoSo DATE,
    NgayDenHan DATE,
    SoTienGui DECIMAL(18, 2),
    NgayRut DATE,
    SoTienRut DECIMAL(18, 2),
    TrangThaiSo BIT,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaLoaiSo) REFERENCES LoaiSoTietKiem(MaLoaiSo)
);