CREATE DATABASE QLKFC

GO
--drop databasE QLKFC
USE QLKFC;

--drop database QLKFC

set dateformat dmy

GO

-- Bảng Quan Ly Nhan Vien  
CREATE TABLE NhanVien (  
    MaNhanVien VARCHAR(30) PRIMARY KEY NOT NULL,  
	AnhNhanVien  VARBINARY(MAX),
    TenNhanVien NVARCHAR(250) NOT NULL,  
    GioiTinh NVARCHAR(3),  
    NgaySinh DATETIME,  
    SoDienThoai VARCHAR(15),  
    Email VARCHAR(150),  
    DiaChi NVARCHAR(300),  
    ChucVu NVARCHAR(100),  
    SoGioLam int 
); 


-- Bảng Tinh Luong Nhan Vien  
CREATE TABLE Luong (  
    MaNhanVien VARCHAR(30) NOT NULL,  
    LuongCoBan Int,  
    Thang Int,  
    SoNgayLam INT,  
    ThuongChuyenCan Int,  
    ThuongHieuSuat Int,  
    PRIMARY KEY (MaNhanVien, Thang),  
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)  
);  
--ALTER TABLE Luong
--ALTER COLUMN LuongCoBan DECIMAL(18, 2);
--ALTER TABLE Luong
--ALTER COLUMN ThuongChuyenCan DECIMAL(18, 2);
--ALTER TABLE Luong
--ALTER COLUMN ThuongHieuSuat DECIMAL(18, 2);


-- Bảng Loai Hang  
CREATE TABLE LoaiHang (  
    MaLoaiHang VARCHAR(20) PRIMARY KEY NOT NULL,  
    TenLoaiHang NVARCHAR(150) NOT NULL  
);  

-- bảng nhà cung cấp
CREATE TABLE NhaCungCap (  
    MaNhaCungCap VARCHAR(10) PRIMARY KEY,  
    TenNhaCungCap NVARCHAR(100) NOT NULL,  
	AnhNhaCungCap  VARBINARY(MAX),
    DiaChi NVARCHAR(200),  
    SoDienThoai VARCHAR(15),  
    GhiChu NVARCHAR(200)  
);  

-- Bảng Kho  
CREATE TABLE Kho (  
    MaSanPham VARCHAR(30) PRIMARY KEY NOT NULL,  
    TenSanPham NVARCHAR(250) NOT NULL,  
    SoLuong INT NOT NULL,  
	DonViTinh NVARCHAR(50),  
	DonGia FLOAT, 
    MaLoaiHang VARCHAR(20),  
    CONSTRAINT CK_SoLuong CHECK (SoLuong >= 0),  
    FOREIGN KEY (MaLoaiHang) REFERENCES LoaiHang(MaLoaiHang) 
); 
 
-- Bảng NhapHang  
CREATE TABLE NhapHang (  
    MaNhapHang INT IDENTITY(1,1) PRIMARY KEY,  
    MaSanPham VARCHAR(30) NOT NULL,  
    SoLuong INT NOT NULL,  
    DonViTinh NVARCHAR(50),  
    DonGia FLOAT,  
    NgayNhap DATETIME NOT NULL,  
    MaLoaiHang VARCHAR(20),  
	MaNhaCungCap VARCHAR(10),
    FOREIGN KEY (MaSanPham) REFERENCES Kho(MaSanPham),  
    FOREIGN KEY (MaLoaiHang) REFERENCES LoaiHang(MaLoaiHang),
	FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);  

-- Bảng Quan Ly Combo  
CREATE TABLE Combo (  
    MaCombo VARCHAR(30) PRIMARY KEY NOT NULL,  
    TenCombo NVARCHAR(250) NOT NULL,  
    GiaCombo FLOAT,  
    ThoiGianHieuLuc DATETIME  
); 

-- Bảng Chi Tiet Combo  
CREATE TABLE ChiTietCombo (  
    MaChiTietCombo INT PRIMARY KEY IDENTITY(1,1),  
    MaCombo VARCHAR(30) NOT NULL,  
    MaSanPham VARCHAR(30) NOT NULL,  
    SoLuong INT NOT NULL,  
    FOREIGN KEY (MaCombo) REFERENCES Combo(MaCombo),  
    FOREIGN KEY (MaSanPham) REFERENCES Kho(MaSanPham)  
);

-- Bảng Quan Ly Thuc Don  
CREATE TABLE ThucDon (  
    MaSanPham VARCHAR(30) PRIMARY KEY NOT NULL,  
    TenSanPham NVARCHAR(250) NOT NULL,  
	HinhAnh VARBINARY(MAX),
    DonGia FLOAT,
	MaLoaiHang VARCHAR(20)
);  

-- Bảng Quan Ly Khuyen Mai  
CREATE TABLE KhuyenMai (  
    MaKhuyenMai VARCHAR(12) PRIMARY KEY,  
    NgayBatDau DATETIME NOT NULL,  
    NgayKetThuc DATETIME NOT NULL,  
    GiaTriGiam DECIMAL(10, 2),  
    SoLuong INT,  
    TrangThai BIT  
);  

-- Bảng Quan Ly Ban  
CREATE TABLE Ban (  
    MaBan VARCHAR(20) PRIMARY KEY NOT NULL,  
    TenBan NVARCHAR(50) NOT NULL,  
    TrangThaiBan BIT  
);  

-- Bảng Khach Hang Than Thiet  
CREATE TABLE KhachHangThanThiet (  
    MaKhachHang VARCHAR(30) PRIMARY KEY NOT NULL,  
    TenKhachHang NVARCHAR(250) NOT NULL,  
    SoDienThoai VARCHAR(15),   
    DiemTichLuy INT DEFAULT 0,  
);

-- bảng đơn đặt
CREATE TABLE DonDat (  
    MaDonDat INT IDENTITY(1,1) PRIMARY KEY,  
    MaBan VARCHAR(20) NOT NULL,  
	TongTien FLOAT,
    HinhThucThanhToan NVARCHAR(50),  
    SoTienNhan FLOAT NULL, 
    SoTienTra FLOAT NULL,  
	MaKhuyenMai VARCHAR(12) null,
	MaKhachHang VARCHAR(30) null,
    FOREIGN KEY (MaBan) REFERENCES Ban(MaBan)  ,
	FOREIGN KEY (MaKhuyenMai) REFERENCES KhuyenMai(MaKhuyenMai),
	FOREIGN KEY (MaKhachHang) REFERENCES KhachHangThanThiet(MaKhachHang)
);

-- Bảng chi tiết hóa đơn
CREATE TABLE ChiTietDonDat (  
	MaDonDat INT NOT NULL, 
    ID INT IDENTITY(1,1) PRIMARY KEY,  
    MaSanPham VARCHAR(30) NULL,  
    MaCombo VARCHAR(30) NULL,  
    SoLuong INT NOT NULL,   
	DonGia FLOAT NULL, 
	FOREIGN KEY (MaDonDat) REFERENCES DonDat(MaDonDat),
    FOREIGN KEY (MaSanPham) REFERENCES ThucDon(MaSanPham),  
    FOREIGN KEY (MaCombo) REFERENCES Combo(MaCombo)  
);


-- Bảng Hoa Don  
CREATE TABLE HoaDon (  
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY, 
	MaDonDat INT not NULL,   
    NgayThanhToan DATETIME,   
    FOREIGN KEY (MaDonDat) REFERENCES DonDat(MaDonDat)  
);   

-- Bảng Doanh Thu  
CREATE TABLE DoanhThu (  
	MaNhapHang INT,
    Thang INT NOT NULL,  
    Nam INT NOT NULL,  
    NgayGhiNhan DATE NOT NULL,  
    MaHoaDon INT,  -- Kết nối với bảng HoaDon (Hóa đơn)  
    TongChiTieu FLOAT,  -- Tổng chi tiêu  
    TongDoanhThu FLOAT,  -- Tổng doanh thu  
    PRIMARY KEY (Thang, Nam, NgayGhiNhan),  
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),  
	FOREIGN KEY (MaNhapHang) REFERENCES NhapHang(MaNhapHang)
);

INSERT INTO NhanVien (MaNhanVien, AnhNhanVien, TenNhanVien, GioiTinh, NgaySinh, SoDienThoai, Email, DiaChi, ChucVu, SoGioLam) 
VALUES 
(N'NV001', NULL, N'Nguyễn Văn A', N'Nam', '01/01/1990', '0901234567', 'vana@gmail.com', N'Hà Nội', N'Quản lý', 160),
(N'NV002', NULL, N'Trần Thị B', N'Nữ', '02/02/1992', '0902234567', 'thib@gmail.com', N'Hà Nội', N'Nhân viên', 150),
(N'NV003', NULL, N'Lê Văn C', N'Nam', '03/03/1989', '0903234567', 'vanc@gmail.com', N'Hồ Chí Minh', N'Quản lý', 170),
(N'NV004', NULL, N'Phạm Thị D', N'Nữ', '04/04/1993', '0904234567', 'thid@gmail.com', N'Hải Phòng', N'Nhân viên', 145),
(N'NV005', NULL, N'Hoàng Văn E', N'Nam', '05/05/1991', '0905234567', 'vane@gmail.com', N'Đà Nẵng', N'Nhân viên', 155),
(N'NV006', NULL, N'Nguyễn Thị F', N'Nữ', '06/06/1990', '0906234567', 'thif@gmail.com', N'Cần Thơ', N'Nhân viên', 160),
(N'NV007', NULL, N'Đỗ Văn G', N'Nam', '07/07/1994', '0907234567', 'vang@gmail.com', N'Quảng Ninh', N'Nhân viên', 165),
(N'NV008', NULL, N'Vũ Thị H', N'Nữ', '08/08/1991', '0908234567', 'thih@gmail.com', N'Thanh Hóa', N'Nhân viên', 150),
(N'NV009', NULL, N'Bùi Văn I', N'Nam', '09/09/1992', '0909234567', 'vani@gmail.com', N'Hà Nội', N'Nhân viên', 140),
(N'NV010', NULL, N'Phạm Thị K', N'Nữ', '10/10/1993', '0900234567', 'thik@gmail.com', N'Hải Phòng', N'Nhân viên', 130),
(N'NV011', NULL, N'Nguyễn Văn L', N'Nam', '11/11/1988', '0910234567', 'vanl@gmail.com', N'Hồ Chí Minh', N'Quản lý', 170),
(N'NV012', NULL, N'Lê Thị M', N'Nữ', '12/12/1990', '0911234567', 'thim@gmail.com', N'Đà Nẵng', N'Nhân viên', 160),
(N'NV013', NULL, N'Phạm Văn N', N'Nam', '13/01/1995', '0912234567', 'vann@gmail.com', N'Cần Thơ', N'Nhân viên', 140),
(N'NV014', NULL, N'Trần Thị O', N'Nữ', '14/02/1992', '0913234567', 'thio@gmail.com', N'Thanh Hóa', N'Nhân viên', 150),
(N'NV015', NULL, N'Đỗ Văn P', N'Nam', '15/03/1989', '0914234567', 'vanp@gmail.com', N'Quảng Ninh', N'Quản lý', 160),
(N'NV016', NULL, N'Vũ Thị Q', N'Nữ', '16/04/1993', '0915234567', 'thiq@gmail.com', N'Hà Nội', N'Nhân viên', 155),
(N'NV017', NULL, N'Bùi Văn R', N'Nam', '17/05/1991', '0916234567', 'vanr@gmail.com', N'Hồ Chí Minh', N'Nhân viên', 150),
(N'NV018', NULL, N'Hoàng Thị S', N'Nữ', '18/06/1990', '0917234567', 'this@gmail.com', N'Hải Phòng', N'Nhân viên', 145),
(N'NV019', NULL, N'Nguyễn Văn T', N'Nam', '19/07/1992', '0918234567', 'vant@gmail.com', N'Đà Nẵng', N'Nhân viên', 150),
(N'NV020', NULL, N'Phạm Thị U', N'Nữ', '20/08/1994', '0919234567', 'thiu@gmail.com', N'Cần Thơ', N'Nhân viên', 160);




INSERT INTO Luong (MaNhanVien, LuongCoBan, Thang, SoNgayLam, ThuongChuyenCan, ThuongHieuSuat)
VALUES
('NV001', 7000000, 7, 22, 500000, 1000000),
('NV001', 7000000, 4, 20, 300000, 800000),
('NV002', 6500000, 1, 21, 400000, 900000),
('NV002', 6500000, 8, 22, 500000, 1000000),
('NV003', 8000000, 10, 23, 500000, 1200000),
('NV003', 8000000, 2, 21, 400000, 1100000),
('NV004', 6000000, 11, 20, 300000, 800000),
('NV004', 6000000, 5, 22, 500000, 900000),
('NV005', 5500000, 9, 22, 400000, 700000),
('NV005', 5500000, 3, 21, 300000, 600000),
('NV006', 6500000, 6, 22, 500000, 900000),
('NV006', 6500000, 12, 22, 500000, 1000000),
('NV007', 7000000, 4, 23, 600000, 1200000),
('NV007', 7000000, 3, 20, 300000, 800000),
('NV008', 6000000, 8, 21, 400000, 900000),
('NV008', 6000000, 5, 22, 500000, 1000000),
('NV009', 5500000, 1, 22, 300000, 700000),
('NV009', 5500000, 6, 21, 300000, 600000),
('NV010', 5000000, 2, 20, 200000, 500000),
('NV010', 5000000, 11, 22, 400000, 700000),
('NV011', 7500000, 3, 23, 600000, 1200000),
('NV011', 7500000, 10, 22, 500000, 1100000),
('NV012', 6000000, 9, 21, 400000, 900000),
('NV012', 6000000, 12, 22, 500000, 1000000),
('NV013', 5500000, 5, 22, 300000, 700000),
('NV013', 5500000, 8, 20, 200000, 600000),
('NV014', 6500000, 4, 21, 500000, 900000),
('NV014', 6500000, 1, 22, 500000, 1000000),
('NV015', 7000000, 2, 22, 600000, 1100000),
('NV015', 7000000, 11, 22, 500000, 1200000);


INSERT INTO LoaiHang (MaLoaiHang, TenLoaiHang) VALUES
('GR', N'Gà Rán'),
('GQ', N'Gà Quay'),
('NUOC', N'Nước Uống'),
('TM', N'Món Tráng Miệng'),
('TAN', N'Thức Ăn Nhẹ'),
('BMC', N'Burger - Mì Ý - Cơm');
INSERT INTO Kho (MaSanPham, TenSanPham, SoLuong, DonViTinh, DonGia, MaLoaiHang)
VALUES
('GR01', N'Gà Rán Giòn', 100, N'Chiếc', 65000, 'GR'),
('GR02', N'Gà Rán Nguyên Tâm', 50, N'Chiếc', 70000, 'GR'),
('GQ01', N'Gà Quay Nguyên Tâm', 80, N'Chiếc', 85000, 'GQ'),
('NUOC01', N'Nước Ngọt', 200, N'Lít', 15000, 'NUOC'),
('TM01', N'Bánh Tart', 150, N'Cái', 20000, 'TM'),
('TAN01', N'Khoai Tây Chiên', 120, N'Cái', 30000, 'TAN'),
('BMC01', N'Burger Gà', 80, N'Chiếc', 50000, 'BMC'),
('BMC02', N'Mì Ý', 70, N'Dĩa', 60000, 'BMC');
INSERT INTO ThucDon (MaSanPham, TenSanPham, HinhAnh, DonGia, MaLoaiHang) VALUES
('GR01', N'Gà Rán Giòn', NULL, 65000, 'GR'),
('GR02', N'Gà Rán Nguyên Miếng', NULL, 70000, 'GR'),
('GQ01', N'Gà Quay Nguyên Miếng', NULL, 85000, 'GQ'),
('NUOC01', N'Nước Ngọt', NULL, 15000, 'NUOC'),
('TM01', N'Bánh Tart', NULL, 20000, 'TM'),
('TAN01', N'Khoai Tây Chiên', NULL, 30000, 'TAN'),
('BMC01', N'Burger Gà', NULL, 50000, 'BMC'),
('BMC02', N'Mì Ý', NULL, 60000, 'BMC');
INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, AnhNhaCungCap, DiaChi, SoDienThoai, GhiChu) VALUES
('NCC01', N'Nhà Cung Cấp A', NULL, N'Địa chỉ NCC A', '0123456789', N'Nhà cung cấp thực phẩm'),
('NCC02', N'Nhà Cung Cấp B', NULL, N'Địa chỉ NCC B', '0987654321', N'Nhà cung cấp nước uống');
INSERT INTO NhapHang (MaSanPham, SoLuong, DonViTinh, DonGia, NgayNhap, MaLoaiHang, MaNhaCungCap) VALUES
('GR01', 100, N'Chiếc', 65000, GETDATE(), 'GR', 'NCC01'),
('GQ01', 50, N'Chiếc', 85000, GETDATE(), 'GQ', 'NCC01'),
('NUOC01', 200, N'Lít', 15000, GETDATE(), 'NUOC', 'NCC02'),
('TAN01', 150, N'Chiếc', 30000, GETDATE(), 'TAN', 'NCC01'),
('BMC01', 80, N'Chiếc', 50000, GETDATE(), 'BMC', 'NCC01');
INSERT INTO Combo (MaCombo, TenCombo, GiaCombo, ThoiGianHieuLuc) VALUES
('CMB01', N'Combo Gà Rán', 95000, GETDATE()),
('CMB02', N'Combo Gà Quay', 115000, GETDATE());
INSERT INTO ChiTietCombo (MaCombo, MaSanPham, SoLuong) VALUES
('CMB01', 'GR01', 1),
('CMB01', 'NUOC01', 1),
('CMB02', 'GQ01', 1),
('CMB02', 'TAN01', 1);
INSERT INTO KhuyenMai (MaKhuyenMai, NgayBatDau, NgayKetThuc, GiaTriGiam, SoLuong, TrangThai) VALUES
('KM01', GETDATE(), DATEADD(DAY, 30, GETDATE()), 20000, 100, 1);



select * from NhapHang

select * from Kho

SELECT * FROM Luong WHERE MaNhanVien = 'NV001' AND Thang = 2;
DELETE FROM Luong WHERE MaNhanVien = 'NV001' AND Thang = 2; -- Thay MãNhânViênCầnXóa và 1 bằng giá trị cụ thể



SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Luong';

EXEC sp_help 'Luong';






























---- 11. Bảng Chi Tiet Hoa Don  
--CREATE TABLE ChiTietHoaDon (  
--    MaChiTiet INT IDENTITY(1,1) PRIMARY KEY,  
--    MaHoaDon INT NOT NULL,  
--    MaSanPham VARCHAR(30) NOT NULL,	0
--    TenSanPham NVARCHAR(250) NOT NULL,  
--    SoLuong INT,  
--    DonGia FLOAT,  
--    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),  
--    FOREIGN KEY (MaSanPham) REFERENCES ThucDon(MaSanPham)  
--);  